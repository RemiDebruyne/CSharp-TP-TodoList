namespace ToDoList.Models
{
    public class Todo
    {
        public int Id {  get; set; }
        public string Titre {  get; set; }
        public string Description {  get; set; }
        public status status { get; set; } = status.EN_COURS;


    }

    public enum status
    {
        TERMINEE,
        EN_COURS,
    }

}
