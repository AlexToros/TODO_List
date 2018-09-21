namespace TestExersize.Models
{
    public class Task
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public bool IsDone { get; set; }
        public string Content { get; set; }
    }
}