using ApplicationServices.DTOs;
using Data.Entities;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Implementations
{
    public class StudentServiceApplication
    {
        public List<StudentDto> Get()
        {
            List<StudentDto> studentDtos = new List<StudentDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.StudentsRepository.Get())
                {
                    studentDtos.Add(new StudentDto
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Comment = item.Comment,
                        DateOfBirth = item.DateOfBirth,
                        Nationality = new NationalityDto
                        {
                            Id=item.Nationality.Id,
                            Title=item.Nationality.Title
                        },
                        Faculty =  new FacultyDto
                        {
                            Id= item.Faculty.Id,
                            Name=item.Faculty.Name,
                            City=item.Faculty.City,
                            Address=item.Faculty.Address
                        }
                    });
                }
            }
            return studentDtos;
        }
        public StudentDto GetById(int id)
        {
            StudentDto studentDto = new StudentDto();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Student student = unitOfWork.StudentsRepository.GetById(id);
                if(student!=null)
                {
                    studentDto = new StudentDto
                    {
                        Id = student.Id,
                        Comment = student.Comment,
                        DateOfBirth = student.DateOfBirth,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Nationality = new NationalityDto
                        {
                            Id = student.NationalityId,
                            Title = student.Nationality.Title
                        },
                        Faculty = new FacultyDto
                        {
                            Id=student.FacultyId,
                            Name=student.Faculty.Name,
                            City=student.Faculty.City,
                            Address = student.Faculty.Address
                        }
                    };
                }
            }
            return studentDto;

        }
        public bool Save(StudentDto studentDto)
        {
            if (studentDto.Nationality == null || studentDto.Nationality.Id == 0 ||
                studentDto.Faculty == null || studentDto.Faculty.Id == 0)
            {
                return false;
            }

            Nationality nationality = new Nationality
            {
                Title = studentDto.Nationality.Title,
                Id = studentDto.Nationality.Id
            };
            Faculty faculty = new Faculty
            {
                Id = studentDto.Faculty.Id,
                Name = studentDto.Faculty.Name,
                City = studentDto.Faculty.City,
                Address = studentDto.Faculty.Address
            };
           
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                     nationality = unitOfWork.NationalityRepositroy.GetById(studentDto.Nationality.Id);
                    faculty = unitOfWork.FacultyRepository.GetById(studentDto.Faculty.Id);
                    Student student = new Student
                    {
                        Id = studentDto.Id,
                        FirstName = studentDto.FirstName,
                        LastName = studentDto.LastName,
                        DateOfBirth = studentDto.DateOfBirth,
                        Comment = studentDto.Comment,
                        Nationality = nationality,
                        Faculty = faculty
                    };
                    unitOfWork.StudentsRepository.Insert(student);
                    unitOfWork.Save();
                }
                    return true;
            }
            catch 
            {

                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Student student = unitOfWork.StudentsRepository.GetById(id);
                    unitOfWork.StudentsRepository.Delete(student);
                    unitOfWork.Save();

                }
                return true;
            }
            catch 
            {

                return false;
            }
        }
    }
}
