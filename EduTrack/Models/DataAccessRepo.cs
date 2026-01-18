using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EduTrack.Models
{
    public class DataAccessRepo
    {
        private static DB_SchoolManagementEntities _SchoolManagementEntities;

        internal static List<Tbl_Student> GetStudents()
        {
            using (_SchoolManagementEntities = new DB_SchoolManagementEntities())
            {
                //*** select all students from Tbl_Student table ***//
                List<Tbl_Student> _students = _SchoolManagementEntities.Tbl_Student.ToList();
                return _students;
            }
        }

        internal static  Task<List<string>> AddStudent(Tbl_Student _Student)
        {
            string sid =Guid.NewGuid().ToString("N").Substring(0,8);
            using(_SchoolManagementEntities = new DB_SchoolManagementEntities())
            {
                //*** add student to Tbl_Student table ***//
                Tbl_Student _student = new Tbl_Student
                {
                    StdID = sid,
                    StdName = _Student.StdName,
                    FatherName = _Student.FatherName,
                    DOB = _Student.DOB,
                    StdAge = _Student.StdAge,
                    Gender = _Student.Gender,
                    RegisterDate = _Student.RegisterDate,
                };
                _SchoolManagementEntities.Tbl_Student.Add(_student);
                _SchoolManagementEntities.SaveChanges();
                return Task.FromResult(new List<string> { "Success", sid });
            }
            
        }
    }
}