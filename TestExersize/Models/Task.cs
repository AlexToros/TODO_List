namespace TestExersize.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        public bool IsDone { get; set; }
        public string Content { get; set; }

        public void Foo() => Content = "111";
    }
}