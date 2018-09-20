using System.Collections.Generic;
using System.Linq;

namespace TestExersize.Models
{
    public class TaskRepository
    {
        private static TaskRepository rep;

        public static TaskRepository RepositoryInstance { get => rep ?? new TaskRepository(); }

        private EFDbContext context;

        private TaskRepository()
        {
            context = new EFDbContext();
            rep = this;
        }

        public IEnumerable<Task> GetAllTasks() => context.Tasks;

        public IEnumerable<Task> GetUserOpenTasks(string UserId) => context.Tasks.Where(t => !t.IsDone && t.UserId == UserId);

        public IEnumerable<Task> GetOpenTasks() => context.Tasks.Where(t => !t.IsDone);

        public Task Get(int Id) => context.Tasks.FirstOrDefault(x => x.Id == Id);

        public void Add(Task newTask)
        {
            context.Tasks.Add(newTask);
            context.SaveChanges();
        }

        public void Remove(int Id)
        {
            Task item = Get(Id);
            if (item != null)
            {
                context.Tasks.Remove(item);
                context.SaveChanges();
            }
        }

        public void CloseTask(int Id)
        {
            Task item = Get(Id);
            if (item != null)
            {
                item.IsDone = true;
                context.SaveChanges();
            }
        }

        public bool Update(Task Task)
        {
            Task updatingTask = Get(Task.Id);
            if (updatingTask != null)
            {
                updatingTask.IsDone = Task.IsDone;
                updatingTask.Content = Task.Content;
                context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}