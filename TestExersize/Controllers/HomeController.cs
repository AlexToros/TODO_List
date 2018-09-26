using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestExersize.Models;
using System.Web.Mvc;
using TestExersize.Infrastructure;
using Microsoft.AspNet.Identity.Owin;

namespace TestExersize.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        TaskRepository repository = TaskRepository.RepositoryInstance;

        public ViewResult Index()
        {
            return View(repository.GetUserOpenTasks(User.Identity.Name));
        }

        public async System.Threading.Tasks.Task<ActionResult> Add(Task newTask)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindByNameAsync(User.Identity.Name);
                newTask.User = user;
                repository.Add(newTask, User.Identity.Name);
                ViewBag.Message = "Задача добавлена!";
                return PartialView("Success");
            }
            else
                return PartialView(newTask);
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
            {
                ViewBag.Message = "Задача отредактирована!";
                return PartialView("Success");
            }
            else
                return PartialView("Edit", task);
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

        private AppUserManager UserManager { get => HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
    }
}