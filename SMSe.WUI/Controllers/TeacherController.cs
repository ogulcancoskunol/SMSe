using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMSe.BLL.ModelViews;
using SMSe.BLL.Service;
using SMSe.BLL.Service.Interface;
using SMSe.DAL;

namespace SMSe.WUI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;

        public TeacherController()
        {
            teacherService = new TeacherService();
        }

        public ActionResult Index()
        {
            var query = teacherService.GetAll();
            var teachers = query.ToList();
            return View(teachers);
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherView teacher = this.teacherService.GetById(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        public ActionResult Subjects()
        {
            return RedirectToAction("Index", "Subject");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id, fname, lname")] TeacherView teacher)
        {
            if (ModelState.IsValid)
            {
                teacherService.Create(teacher);
                teacherService.Save();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            TeacherView teacher = teacherService.GetById(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id, fname, lname")] TeacherView teacher)
        {
            if (ModelState.IsValid)
            {
                teacherService.Update(teacher);
                teacherService.Save();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        public ActionResult Delete(int id)
        {
            TeacherView teacher = teacherService.GetById(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teacherService.Delete(id);
            teacherService.Save();
            return RedirectToAction("Index");
        }
    }
}