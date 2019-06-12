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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Faculty" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Faculty.svc or Faculty.svc.cs at the Solution Explorer and start debugging.
    public class Faculty : IFaculty
    {
        private FacultyApplicationService facultyService = new FacultyApplicationService();

        public string DeleteFaculty(int id)
        {
            if (!facultyService.Delete(id))
            {
                return "Faculty is not deleted";
            }
            return "Faculty is deleted";
        }

        public List<FacultyDto> GetFaculties()
        {
            return facultyService.Get();
        }

        public FacultyDto GetFacultyById(int id)
        {
            return facultyService.GetFacultyById(id);
        }

        public string Message()
        {
            return "WCF client is up!";
        }

        public string PostFaculty(FacultyDto facultyDto)
        {
            if (!facultyService.Save(facultyDto))
            {
                return "Faculty is not inserted";
            }
            return "Faculty is inserted";
        }

        public string PutFaculty(FacultyDto facultyDto)
        {
            throw new NotImplementedException();
        }
    }
}
