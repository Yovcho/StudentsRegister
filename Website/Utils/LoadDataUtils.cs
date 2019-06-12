using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Utils
{
    public class LoadDataUtils
    {
        public static SelectList LoadNationalityData()
        {
            using (NationalityService.NationalityClient service = new NationalityService.NationalityClient())
            {
                return new SelectList(service.GetNationalities(), "Id", "Title");
            }
        }
        public static SelectList LoadFacultyData()
        {
            using (FaculctyService.FacultyClient service = new FaculctyService.FacultyClient())
            {
                return new SelectList(service.GetFaculties(), "Id", "Name");
            }
        }
    }
}