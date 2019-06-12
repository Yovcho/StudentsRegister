using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModels;

namespace Website.Controllers
{
    public class NationalityController : Controller
    {
        // GET: Nationality
        public ActionResult Index()
        {
            List<NationalityVM> nationalityVM = new List<NationalityVM>();
            using (NationalityService.NationalityClient service = new NationalityService.NationalityClient())
            {
                foreach (var item in service.GetNationalities())
                {
                    nationalityVM.Add(new NationalityVM(item));
                }
            }
            return View(nationalityVM);
        }

        // GET: Nationality/Details/5
        public ActionResult Details(int id)
        {
            NationalityVM nationalityVM = new NationalityVM();

            using (NationalityService.NationalityClient service = new NationalityService.NationalityClient())
            {
                var nationalityDto = service.GetNationalityByID(id);
                nationalityVM = new NationalityVM(nationalityDto);
            }
            return View(nationalityVM);
        }

        // GET: Nationality/Create
        [HttpGet]
        public ActionResult Create()
        {
                return View();
        }

        // POST: Nationality/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NationalityVM nationalityVM)
        {
            try
            {
                using (NationalityService.NationalityClient service = new NationalityService.NationalityClient())
                {
                    NationalityService.NationalityDto nationalityDto = new NationalityService.NationalityDto
                    {
                        Id = nationalityVM.Id,
                        Title = nationalityVM.Title
                    };                 
                    foreach (var item in service.GetNationalities())
                    {
                        if(item.Title==nationalityDto.Title)
                        {
                            ModelState.AddModelError("", "Nationality already exists!");
                            return View();
                        }
                    }
                    service.PostNationality(nationalityDto);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Nationality/Edit/5
        public ActionResult Edit(int id)
        {
            NationalityVM nationalityVM = new NationalityVM();
            using(NationalityService.NationalityClient service = new NationalityService.NationalityClient())
            {
                var nationalityDto = service.GetNationalityByID(id);
                nationalityVM = new NationalityVM(nationalityDto);
            }
            return View(nationalityVM);
        }

        // POST: Nationality/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NationalityVM nationalityVM)
        {
            try
            {
                if(ModelState.IsValid)
                {

                    using (NationalityService.NationalityClient service = new NationalityService.NationalityClient())
                    {
                        NationalityService.NationalityDto nationalityDto = new NationalityService.NationalityDto
                        {
                            Id = nationalityVM.Id,
                            Title = nationalityVM.Title
                        };
                        foreach (var item in service.GetNationalities())
                        {
                            if (item.Title == nationalityDto.Title)
                            {
                                ModelState.AddModelError("", "Nationality already exists!");
                                return View();
                            }
                        }
                        service.PostNationality(nationalityDto);
                    }

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Nationality/Delete/5
        public ActionResult Delete(int id)
        {
            NationalityVM nationalityVM = new NationalityVM();

            using (NationalityService.NationalityClient service = new NationalityService.NationalityClient() )
            {
                service.DeleteNationality(id);
            }
            return RedirectToAction("Index");
        }
    }
}
