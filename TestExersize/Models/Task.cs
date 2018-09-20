namespace TestExersize.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IsDone { get; set; }
        public string Content { get; set; }
    }
}