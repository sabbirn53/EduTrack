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


        internal static Task<string> AddStudent(Tbl_Student _Student)
        {
            try
            {
                string sid = Guid.NewGuid().ToString("N").Substring(0, 10);
                using (_SchoolManagementEntities = new DB_SchoolManagementEntities())
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
                    return Task.FromResult("Success");
                }
            }
            catch
            {
                return Task.FromResult("Error");
            }



        }

        internal static Task<Tbl_Student> GetStudentsById(string id)
        {
            using (_SchoolManagementEntities = new DB_SchoolManagementEntities())
            {
                //*** select student by id from Tbl_Student table ***//
                Tbl_Student _student = _SchoolManagementEntities.Tbl_Student.Find(id);
                return Task.FromResult(_student);
            }
        }

        internal static Task<string> EditStudent(Tbl_Student student)
        {
            using (_SchoolManagementEntities = new DB_SchoolManagementEntities())
            {
                //*** update student in Tbl_Student table ***//
                Tbl_Student _student = _SchoolManagementEntities.Tbl_Student.Find(student.StdID);
                _student.StdName = student.StdName;
                _student.FatherName = student.FatherName;
                _student.DOB = student.DOB;
                _student.StdAge = student.StdAge;
                _student.Gender = student.Gender;
                _student.RegisterDate = student.RegisterDate;
                _SchoolManagementEntities.SaveChanges();
                return Task.FromResult("Success");
            }
        }

        internal static Task<string> DeleteStudent(string id)
        {
            try
            {
                using (_SchoolManagementEntities = new DB_SchoolManagementEntities())
                {
                    //*** delete student from Tbl_Student table ***//
                    Tbl_Student _student = _SchoolManagementEntities.Tbl_Student.Find(id);
                    _SchoolManagementEntities.Tbl_Student.Remove(_student);
                    _SchoolManagementEntities.SaveChanges();
                    return Task.FromResult("Success");
                }
            }
            catch
            {
                return Task.FromResult("Error");
            }
        }
    }
}