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

        public IEnumerable<Task> GetOpenTasks() => tasks.Where(t => !t.IsDone);

        public Task Get(int Id) => tasks.FirstOrDefault(x => x.TaskID == Id);

        public void Add(Task newTask)
        {
            newTask.TaskID = tasks.Count + 1;
            tasks.Add(newTask);
        }

        public void Remove(int Id)
        {
            Task item = Get(Id);
            if (item != null)
                tasks.Remove(item);
        }

        public void CloseTask(int Id)
        {
            Task item = Get(Id);
            if (item != null)
                item.IsDone = true;
        }

        public bool Update(Task Task)
        {
            Task updatingTask = Get(Task.TaskID);
            if (updatingTask != null)
            {
                updatingTask.Content = Task.Content;
                return true;
            }
            else
                return false;
        }
    }
}