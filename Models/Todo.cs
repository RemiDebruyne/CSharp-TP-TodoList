using ToDoList.Enum;

namespace ToDoList.Models
{
    public class Todo
    {
        public int Id {  get; set; }
        public string Titre {  get; set; }
        public string Description {  get; set; }
        public TodoStatus status { get; set; } = TodoStatus.A_FAIRE;
    }


}
