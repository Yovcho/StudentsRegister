using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApplicationServices.DTOs;
using ApplicationServices.Implementations;

namespace StudentRegister
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Student" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Student.svc or Student.svc.cs at the Solution Explorer and start debugging.
    public class Student : IStudent
    {
        private StudentServiceApplication studentService = new StudentServiceApplication();
        public string DeleteStudent(int id)
        {
            if(!studentService.Delete(id))
            {
                return "Student is not deleted";
            }
            return "Student is deleted";
        }

        public StudentDto GetStudentById(int id)
        {
            return studentService.GetById(id);
        }

        public List<StudentDto> GetStudents()
        {
            return studentService.Get();
        }

        public string Message()
        {
            return "WCF service is up!";
        }

        public string PostStudent(StudentDto studentDto)
        {
            if(!studentService.Save(studentDto))
            {
                return "Student is not inserted";
            }
            return "Student is inserted";
        }

        public string PutStudent(StudentDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}
