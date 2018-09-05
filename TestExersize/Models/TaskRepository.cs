using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestExersize.Models
{
    public class TaskRepository
    {
        private static TaskRepository rep;

        public static TaskRepository RepositoryInstance { get => rep ?? new TaskRepository(); }

        private List<Task> tasks;

        private TaskRepository()
        {
            tasks = new List<Task>
            {
                new Task { TaskID = 1, Content = "Доделать во вторник, начатое в понедельник", IsDone = false},
                new Task { TaskID = 2, Content = "Купить хлеб", IsDone = false},
                new Task { TaskID = 3, Content = "Постричься", IsDone = true},
            };
            rep = this;
        }

        public IEnumerable<Task> GetAllTasks() => tasks;

        public Task Get(int Id) => tasks.FirstOrDefault(x => x.TaskID == Id);

        public void Add(Task newTask) => tasks.Add(newTask);

        public void Remove(int Id)
        {
            Task item = Get(Id);
            if (item != null)
                tasks.Remove(item);
        }

        public bool Update(Task Task)
        {
            Task updatingTask = Get(Task.TaskID);
            if (updatingTask != null)
            {
                updatingTask.IsDone = Task.IsDone;
                updatingTask.Content = Task.Content;
                return true;
            }
            else
                return false;
        }
    }
}