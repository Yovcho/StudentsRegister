﻿using ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApplicationServices.Implementations;

namespace StudentRegister
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Nationality" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Nationality.svc or Nationality.svc.cs at the Solution Explorer and start debugging.
    public class Nationality : INationality
    {
        private  NationalityServiceApplication nationalityService = new NationalityServiceApplication();

        //vrushta list s obekti
        public List<NationalityDto> GetNationalities()
        {
            return nationalityService.Get();
        }

        public NationalityDto GetNationalityByID(int id)
        {
            return nationalityService.GetById(id);
        }

        public string PostNationality(NationalityDto nationalityDto)
        {
            if (!nationalityService.Save(nationalityDto))
                return "Nationality is not inserted";

            return "Nationality is inserted";
        }

        public string PutNationality(NationalityDto nationalityDto)
        {
            throw new NotImplementedException();
        }

        public string DeleteNationality(int id)
        {
            if (!nationalityService.Delete(id))
                return "Nationality is not deleted";

            return "Nationality is deleted";
        }
    }
}
