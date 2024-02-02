using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    public class TodoController : Controller
    {
        public ITodoRepository<Todo> Repository { get; set; }
        public TodoController(ITodoRepository<Todo> repository)
        {
            Repository = repository;
        }
        public IActionResult Index()
        {
            return View(Repository.GetAll());
        }

        public IActionResult Form(int id)
        {
            if(id == 0)
                return View();

            var todo = Repository.GetById(id);  
            return View(todo);
        }

        public IActionResult Add(Todo todo)
        {
            if (todo.Id == 0)
                Repository.Add(todo);
            else
                Repository.Update(todo);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(Todo todo)
        {
            Repository.Update(todo);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            
            Repository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateStatus(Todo todo)
        {
            Repository.UpdateStatus(todo);

            return RedirectToAction(nameof(Index));
        }
    }
}
