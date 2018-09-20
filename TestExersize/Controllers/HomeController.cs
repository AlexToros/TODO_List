using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestExersize.Models;
using System.Web.Mvc;

namespace TestExersize.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        TaskRepository repository = TaskRepository.RepositoryInstance;

        public ViewResult Index()
        {
            return View(repository.GetOpenTasks());
        }

        public ActionResult Add(Task newTask)
        {
            if (ModelState.IsValid)
            {
                repository.Add(newTask);
                return RedirectToAction("Index");
            }
            else
                return View("Index");
        }

        public ActionResult CloseTask(int Id)
        {
            Task task = repository.Get(Id);
            if (task != null)
            {
                task.IsDone = true;
                repository.Update(task);
                return RedirectToAction("Index");
            }
            else
                return View("Index");
        }

        public ActionResult GetEditor(int Id)
        {
            return PartialView("Edit", repository.Get(Id));
        }

        public ActionResult GetAdder()
        {
            return PartialView("Add",new Task());
        }
        
        public ActionResult Update(Task task)
        {
            if (ModelState.IsValid && repository.Update(task))
                return RedirectToAction("Index");
            else
                return View("Index");
        }

        public ActionResult Remove(int Id)
        {
            if (ModelState.IsValid)
            {
                repository.Remove(Id);
                return RedirectToAction("Index");
            }
            else
                return View("Index");
        }
    }
}