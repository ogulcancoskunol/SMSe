using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMSe.BLL.ModelViews;
using SMSe.BLL.Service;
using SMSe.BLL.Service.Interface;

namespace SMSe.WUI.Controllers
{
    [RoutePrefix("teacher/{id}")]
    public class SubjectController : Controller
    {
        private readonly ISubjectService subjectService;

        public SubjectController()
        {
            subjectService = new SubjectService();
        }

        public ActionResult Index(int id)
        {
            var query = subjectService.GetAll(id);
            var subjects = query.ToList();
            return View(subjects);
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectView subject = this.subjectService.GetById(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id, name, total_hour")] SubjectView subject)
        {
            if (ModelState.IsValid)
            {
                subjectService.Create(subject, 0);
                subjectService.Save();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            SubjectView subject = subjectService.GetById(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id, name, total_hour")] SubjectView subject)
        {
            if (ModelState.IsValid)
            {
                subjectService.Update(subject);
                subjectService.Save();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        public ActionResult Delete(int id)
        {
            SubjectView subject = subjectService.GetById(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subjectService.Delete(id);
            subjectService.Save();
            return RedirectToAction("Index");
        }
    }
}