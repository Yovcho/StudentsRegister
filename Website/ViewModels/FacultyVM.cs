using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website.FacultyService;

namespace Website.ViewModels
{
    public class FacultyVM
    {
        public int Id { get; set; }
        [DisplayName("City")]
        [Required(ErrorMessage = "This field is required!")]
        public string City { get; set; }
        [DisplayName("Address")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Address is too long")]
        public string Address { get; set; }
        [DisplayName("Faculty Name")]
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Name is too long")]
        public string Name { get; set; }
        public FacultyVM()
        {
        }
        public FacultyVM(FacultyDto facultyDto)
        {
            Id = facultyDto.Id;
            Name = facultyDto.Name;
            City = facultyDto.City;
            Address = facultyDto.Address;
        }
    }
}