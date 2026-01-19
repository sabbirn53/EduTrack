using EduTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EduTrack.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Tbl_Student> _students = StudentModel.GetAll();
            return View(_students);
        }

        public ActionResult Add()
        {

            return View();
        }

        [HttpPost, ActionName("Add")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Tbl_Student _Student)
        {
            if (!ModelState.IsValid) return View(_Student);

            string isSuccess = await StudentModel.Add(_Student);
            ViewBag.Message = isSuccess;
            return View(_Student);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index");
            Tbl_Student _student = await StudentModel.GetById(id);
            return View(_student);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Tbl_Student _Student)
        {
            if (!ModelState.IsValid) return View(_Student);
            string isSuccess = await StudentModel.Edit(_Student);
            ViewBag.Message = isSuccess;
            return View(_Student);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Index");
            Tbl_Student _Student = await StudentModel.GetById(id);
            return View(_Student);
        }

        [HttpPost, ActionName("ConfirmDelete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Tbl_Student std)
        {
            if(string.IsNullOrEmpty(std.StdID)) return View("Index");
            string isDeleted = await StudentModel.Delete(std.StdID);
            return RedirectToAction("Index");
        }
    }
}