using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoListController : Controller
    {
        private ITodoListData db;

        public TodoListController(ITodoListData db)
        {
            this.db = db;
        }
        // GET: TodoList
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TodoList.Models.TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                db.Add(todoList);
                TempData["Message"] = "The Task has been added to the List!";
                return RedirectToAction("Details", new { id = todoList.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TodoList.Models.TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                db.Update(todoList);
                TempData["Message"]="The Task has been changed!";
                return RedirectToAction("Details", new { id = todoList.Id });
            }
            return View(todoList);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            TempData["Message"] = "The Task has been deleted!";
            return RedirectToAction("Index");
        }
    }
}