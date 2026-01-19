using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EduTrack.Models
{
    public class StudentModel
    {
        public static List<Tbl_Student> GetAll()=>DataAccessRepo.GetStudents();
        public static Task<Tbl_Student>  GetById(string id)=>DataAccessRepo.GetStudentsById(id);

        public static async Task<string> Add(Tbl_Student student) => await DataAccessRepo.AddStudent(student);
        public static async Task<string> Edit(Tbl_Student student) => await DataAccessRepo.EditStudent(student);
        public static async Task<string> Delete(string id) => await DataAccessRepo.DeleteStudent(id);
    }
}