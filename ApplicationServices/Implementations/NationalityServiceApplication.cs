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
    public class NationalityServiceApplication
    {
        public List<NationalityDto> Get()
        {
            List<NationalityDto> nationalityDtos = new List<NationalityDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork() )
            {
                foreach (var item in unitOfWork.NationalityRepositroy.Get())
                {
                    nationalityDtos.Add(new NationalityDto
                    {
                        Id = item.Id,
                        Title = item.Title
                    });
                }

            }
            return nationalityDtos;
        }
        public NationalityDto GetById(int id)
        {
            NationalityDto nationalityDto = new NationalityDto();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Nationality nationality = unitOfWork.NationalityRepositroy.GetById(id);

               if(nationality!=null)
                {
                    nationalityDto = new NationalityDto
                    {
                        Id = nationality.Id,
                        Title = nationality.Title
                    };
                }
            }
            return nationalityDto;
        }
        public bool Save(NationalityDto nationalityDto)
        {
            Nationality nationality = new Nationality
            {
                Title = nationalityDto.Title
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (nationalityDto.Id == 0)
                    {
                        unitOfWork.NationalityRepositroy.Insert(nationality);
                    }
                    else
                    {
                        unitOfWork.NationalityRepositroy.Update(nationality);
                    }
                        unitOfWork.Save();
                }
                    return true;
            }
            catch 
            {
                Console.WriteLine(nationality);
                return false;
            }
        }
        public bool Delete(int id)
        {

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Nationality nationality = unitOfWork.NationalityRepositroy.GetById(id);
                    unitOfWork.NationalityRepositroy.Delete(nationality);
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
