using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.StudentService;

namespace Website.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBrith { get; set; }
        public string Comment { get; set; }
        public int NationalityId { get; set; }
        public NationalityVM NationalityVM { get; set; }
        public int FacultyId { get; set; }
        public FacultyVM FacultyVM { get; set; }

        public StudentVM()
        {
        }
        public StudentVM(StudentDto studentDto)
        {
            Id = studentDto.Id;
            FirstName = studentDto.FirstName;
            LastName = studentDto.LastName;
            DateOfBrith = studentDto.DateOfBirth;
            Comment = studentDto.Comment;
            NationalityId = studentDto.Nationality.Id;
            NationalityVM = new NationalityVM
            {
                Id = studentDto.Nationality.Id,
                Title = studentDto.Nationality.Title
            };
            FacultyId = studentDto.Faculty.Id;
            FacultyVM = new FacultyVM
            {
                Id = studentDto.Faculty.Id,
                Name = studentDto.Faculty.Name,
                City = studentDto.Faculty.City,
                Address = studentDto.Faculty.Address
            };
        }
    }
}