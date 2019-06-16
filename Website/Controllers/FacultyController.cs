using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModels;

namespace Website.Controllers
{
    public class FacultyController : Controller
    {
        FacultiesClientModel _service = new FacultiesClientModel();
        // GET: Faculty
        public ActionResult Index()
        {
            List<FacultyVM> facultyVMs = new List<FacultyVM>();
            try
            {
                using (_service.Service)
                {
                    foreach (var item in _service.Service.GetFaculties())
                    {
                        facultyVMs.Add(new FacultyVM(item));
                    }
                }
                return View(facultyVMs);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Faculty/Details/5
        public ActionResult Details(int id)
        {
            FacultyVM facultyVM = new FacultyVM();
            try
            {

                using (_service.Service)
                {
                    var facultyDto = _service.Service.GetFacultyById(id);
                    facultyVM = new FacultyVM(facultyDto);
                }
                return View(facultyVM);
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculty/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacultyVM facultyVM)
        {
            try
            {
                using (_service.Service)
                {
                    FaculctyService.FacultyDto facultyDto = new FaculctyService.FacultyDto
                    {
                        Id = facultyVM.Id,
                        Name = facultyVM.Name,
                        City = facultyVM.City,
                        Address = facultyVM.Address
                    };
                    foreach (var item in _service.Service.GetFaculties())
                    {
                        if (item.Name == facultyDto.Name)
                        {
                            ModelState.AddModelError("", "Faculty already exists!");
                            return View();
                        }
                    }
                    _service.Service.PostFaculty(facultyDto);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Faculty/Edit/5
        public ActionResult Edit(int id)
        {
            FacultyVM facultyVM = new FacultyVM();
            try
            {
                using (_service.Service)
                {
                    var facultyDto = _service.Service.GetFacultyById(id);
                    facultyVM = new FacultyVM(facultyDto);
                }
            }
            catch
            {
                return View("Error");
            }

            return View(facultyVM);
        }

        // POST: Faculty/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacultyVM facultyVM)
        {
            try
            {
                using (_service.Service)
                {
                    FaculctyService.FacultyDto facultyDto = new FaculctyService.FacultyDto
                    {
                        Id = facultyVM.Id,
                        Name = facultyVM.Name,
                        City = facultyVM.City,
                        Address = facultyVM.Address
                    };
                    foreach (var item in _service.Service.GetFaculties())
                    {
                        if (item.Name == facultyDto.Name)
                        {
                            ModelState.AddModelError("", "Faculty already exists!");
                            return View();
                        }
                    }
                    _service.Service.PostFaculty(facultyDto);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Faculty/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (_service.Service)
                {
                    _service.Service.DeleteFaculty(id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
