using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.Utils;
using Website.ViewModels;

namespace Website.Controllers
{
    public class StudentsController : Controller
    {
        StudentsClientModel _service = new StudentsClientModel();
        [HttpGet]
        public ActionResult Index()
        {
            List<StudentVM> studentVMs = new List<StudentVM>();
            try
            {
                using (_service.Service)
                {
                    foreach (var item in _service.Service.GetStudents())
                    {
                        studentVMs.Add(new StudentVM(item));
                    }
                }
            }
            catch
            {
                return View("Error");
            }
            return View(studentVMs);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            StudentVM studentVM = new StudentVM();
            try
            {
                using (_service.Service)
                {
                    var studentDto = _service.Service.GetStudentById(id);
                    studentVM = new StudentVM(studentDto);
                }
            }
            catch
            {
                return View("Error");
            }
            return View(studentVM);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Nationalities = LoadDataUtils.LoadNationalityData();
            ViewBag.Faculties = LoadDataUtils.LoadFacultyData();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentVM studentVM)
        {
            try
            {
                using (_service.Service)
                {
                    StudentService.StudentDto studentDto = new StudentService.StudentDto
                    {
                        Id = studentVM.Id,
                        FirstName = studentVM.FirstName,
                        LastName = studentVM.LastName,
                        DateOfBirth = studentVM.DateOfBrith,
                        Comment = studentVM.Comment,
                        Faculty = new StudentService.FacultyDto
                        {
                            Id = studentVM.FacultyId
                        },
                        Nationality = new StudentService.NationalityDto
                        {
                            Id = studentVM.NationalityId
                        }
                    };
                    _service.Service.PostStudent(studentDto);
                }
                ViewBag.Nationalities = LoadDataUtils.LoadNationalityData();
                ViewBag.Faculties = LoadDataUtils.LoadFacultyData();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            StudentVM studentVM = new StudentVM();
            try
            {
                using (_service.Service)
                {
                    var studentDto = _service.Service.GetStudentById(id);
                    studentVM = new StudentVM(studentDto);
                }
                ViewBag.Nationalities = LoadDataUtils.LoadNationalityData();
                ViewBag.Faculties = LoadDataUtils.LoadFacultyData();
            }
            catch
            {
                return View("Error");
            }
            return View(studentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentVM studentVM)
        {
            try
            {
                using (_service.Service)
                {
                    StudentService.StudentDto studentDto = new StudentService.StudentDto
                    {
                        Id = studentVM.Id,
                        FirstName = studentVM.FirstName,
                        LastName = studentVM.LastName,
                        DateOfBirth = studentVM.DateOfBrith,
                        Comment = studentVM.Comment,
                        Faculty = new StudentService.FacultyDto
                        {
                            Id = studentVM.FacultyId
                        },
                        Nationality = new StudentService.NationalityDto
                        {
                            Id = studentVM.NationalityId
                        }
                    };
                    _service.Service.PostStudent(studentDto);
                }
                ViewBag.Nationalities = LoadDataUtils.LoadNationalityData();
                ViewBag.Faculties = LoadDataUtils.LoadFacultyData();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {

            try
            {
                using (_service.Service)
                {
                    _service.Service.DeleteStudent(id);
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
