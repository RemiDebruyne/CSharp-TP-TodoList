using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Linq.Expressions;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class todoRepository : ITodoRepository<Todo>
    {
        private ApplicationDbContext _context;
        public todoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Todo todo)
        {

            var todoFromDb = GetById(todo.Id);

            if (todoFromDb == null)
                return false;

            if(todoFromDb.Titre != todo.Titre)
                todoFromDb.Titre = todo.Titre;
            if (todoFromDb.Description != todo.Description)
                todoFromDb.Description = todo.Description;
            if (todoFromDb.status != todo.status)
                todoFromDb.status = todo.status;

            return _context.SaveChanges() > 0;
        }

        public bool UpdateStatus(Todo todo)
        {
            var todoFromDb = GetById(todo.Id);

            if (todoFromDb == null)
                return false;

            if (todoFromDb.status != todo.status)
                todoFromDb.status = todo.status;

            return _context.SaveChanges() > 0; 
        }

        public Todo? GetById(int id)
        {
            return _context.Todos.Find(id);
        }
        public bool Delete(int id)
        {
            var todo = GetById(id);
            if (todo == null)
                return false;
            _context.Todos.Remove(todo);
          return  _context.SaveChanges() > 0;
        }

        public List<Todo> GetAll()
        {
            return _context.Todos.ToList();
        }

        public Todo? Get(Expression<Func<Todo, bool>> predicate)
        {
            return _context.Todos.FirstOrDefault(predicate);

        }

        public List<Todo> GetAll(Expression<Func<Todo, bool>> predicate)
        {
            return _context.Todos.Where(predicate).ToList();

        }
    }
}
