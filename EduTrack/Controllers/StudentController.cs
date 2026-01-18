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
        [HttpPost,ActionName("Add")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Tbl_Student _Student)
        {
            if (!ModelState.IsValid) return View(_Student);
         
            string isSuccess = await StudentModel.Add(_Student);
            ViewBag.Message = isSuccess;
            return View(_Student);
        }
    }
}