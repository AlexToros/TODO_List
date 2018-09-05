using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestExersize.Models;
using System.Web.Mvc;

namespace TestExersize.Controllers
{
    public class HomeController : Controller
    {
        TaskRepository repository = TaskRepository.RepositoryInstance;

        public ViewResult Index()
        {
            return View(repository.GetAllTasks());
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