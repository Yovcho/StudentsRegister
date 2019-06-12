using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website.NationalityService;

namespace Website.ViewModels
{
    public class NationalityVM
    {
        public int Id { get; set; }
        [DisplayName("Title")]
        [Required(ErrorMessage = "This field is required!")]
        public string Title { get; set; }

        public NationalityVM()
        {
        }
        public NationalityVM(NationalityDto nationalityDto)
        {
            Id = nationalityDto.Id;
            Title = nationalityDto.Title;
        }
    }
}