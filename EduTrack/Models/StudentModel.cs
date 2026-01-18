using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduTrack.Models
{
    public class StudentModel
    {
        public static List<Tbl_Student> GetAll()=>DataAccessRepo.GetStudents();

        public static async List<string> Add(Tbl_Student student) => await DataAccessRepo.AddStudent(student);
    }
}