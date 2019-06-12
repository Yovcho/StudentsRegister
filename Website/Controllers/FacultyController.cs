using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModels;

namespace Website.Controllers
{
    public class FacultyController : Controller
    {
        // GET: Faculty
        public ActionResult Index()
        {
            List<FacultyVM> facultyVMs = new List<FacultyVM>();
            using (FaculctyService.FacultyClient service = new FaculctyService.FacultyClient())
            {
                foreach (var item in service.GetFaculties())
                {
                    facultyVMs.Add(new FacultyVM(item));
                }
            }
            return View(facultyVMs);
        }

        // GET: Faculty/Details/5
        public ActionResult Details(int id)
        {
            FacultyVM facultyVM = new FacultyVM();
            using (FaculctyService.FacultyClient service = new FaculctyService.FacultyClient())
            {
                var facultyDto = service.GetFacultyById(id);
                facultyVM = new FacultyVM(facultyDto);
            }
            return View(facultyVM);
        }

        // GET: Faculty/Create
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
                using (FaculctyService.FacultyClient service = new FaculctyService.FacultyClient())
                {
                    FaculctyService.FacultyDto facultyDto = new FaculctyService.FacultyDto
                    {
                        Id = facultyVM.Id,
                        Name = facultyVM.Name,
                        City = facultyVM.City,
                        Address = facultyVM.Address
                    };
                    foreach (var item in service.GetFaculties())
                    {
                        if(item.Name==facultyDto.Name)
                        {
                            ModelState.AddModelError("", "Faculty already exists!");
                            return View();
                        }
                    }
                    service.PostFaculty(facultyDto);
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
            using (FaculctyService.FacultyClient service = new FaculctyService.FacultyClient())        
            {
                var facultyDto = service.GetFacultyById(id);
                facultyVM = new FacultyVM(facultyDto);
            }
            return View(facultyVM);
        }

        // POST: Faculty/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacultyVM facultyVM )
        {
            try
            {
                using (FaculctyService.FacultyClient service = new FaculctyService.FacultyClient())
                {
                    FaculctyService.FacultyDto facultyDto = new FaculctyService.FacultyDto
                    {
                        Id = facultyVM.Id,
                        Name = facultyVM.Name,
                        City = facultyVM.City,
                        Address = facultyVM.Address
                    };
                    foreach (var item in service.GetFaculties())
                    {
                        if (item.Name == facultyDto.Name)
                        {
                            ModelState.AddModelError("", "Faculty already exists!");
                            return View();
                        }
                    }
                    service.PostFaculty(facultyDto);
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
            using (FaculctyService.FacultyClient service = new FaculctyService.FacultyClient())
            {
                service.DeleteFaculty(id);
            }
            return RedirectToAction("Index");
        }
    }
}
