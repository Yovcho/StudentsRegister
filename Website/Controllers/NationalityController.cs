using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModels;

namespace Website.Controllers
{
    public class NationalityController : Controller
    {
        NationalitiesClientModel _service = new NationalitiesClientModel();
        // GET: Nationality
        public ActionResult Index()
        {
            List<NationalityVM> nationalityVM = new List<NationalityVM>();
            try
            {
                using (_service.Service)
                {
                    foreach (var item in _service.Service.GetNationalities())
                    {
                        nationalityVM.Add(new NationalityVM(item));
                    }
                }
            }
            catch
            {
                return View("Error");
            }
            return View(nationalityVM);
        }

        // GET: Nationality/Details/5
        public ActionResult Details(int id)
        {
            NationalityVM nationalityVM = new NationalityVM();
            try
            {
                using (_service.Service)
                {
                    var nationalityDto = _service.Service.GetNationalityByID(id);
                    nationalityVM = new NationalityVM(nationalityDto);
                }
            }
            catch
            {
                return View("Error");
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
                using (_service.Service)
                {
                    NationalityService.NationalityDto nationalityDto = new NationalityService.NationalityDto
                    {
                        Id = nationalityVM.Id,
                        Title = nationalityVM.Title
                    };
                    foreach (var item in _service.Service.GetNationalities())
                    {
                        if (item.Title == nationalityDto.Title)
                        {
                            ModelState.AddModelError("", "Nationality already exists!");
                            return View();
                        }
                    }
                    _service.Service.PostNationality(nationalityDto);
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
            try
            {
                using (_service.Service)
                {
                    var nationalityDto = _service.Service.GetNationalityByID(id);
                    nationalityVM = new NationalityVM(nationalityDto);
                }
            }
            catch
            {
                return View("Error");
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
                if (ModelState.IsValid)
                {

                    using (_service.Service)
                    {
                        NationalityService.NationalityDto nationalityDto = new NationalityService.NationalityDto
                        {
                            Id = nationalityVM.Id,
                            Title = nationalityVM.Title
                        };
                        foreach (var item in _service.Service.GetNationalities())
                        {
                            if (item.Title == nationalityDto.Title)
                            {
                                ModelState.AddModelError("", "Nationality already exists!");
                                return View();
                            }
                        }
                        _service.Service.PostNationality(nationalityDto);
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
            try
            {
                using (_service.Service)
                {
                    _service.Service.DeleteNationality(id);
                }
            }
            catch
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}
