using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Utils
{
    public class LoadDataUtils
    {
        public static SelectList LoadNationalityData()
        {
            NationalitiesClientModel _service = new NationalitiesClientModel();

            using (_service.Service)
            {
                return new SelectList(_service.Service.GetNationalities(), "Id", "Title");
            }
        }
        public static SelectList LoadFacultyData()
        {
            FacultiesClientModel _service = new FacultiesClientModel();
            using (_service.Service)
            {
                return new SelectList(_service.Service.GetFaculties(), "Id", "Name");
            }
        }
    }
}