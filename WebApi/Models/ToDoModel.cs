namespace WebApi.Models
{
    public class ToDoModel
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string due_date { get; set; }
    }
}
