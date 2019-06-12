using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Utils;
using Website.ViewModels;

namespace Website.Controllers
{
    public class StudentsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<StudentVM> studentVMs = new List<StudentVM>();
            using(StudentService.StudentClient service = new StudentService.StudentClient())
            {
                foreach (var item in service.GetStudents())
                {
                    studentVMs.Add(new StudentVM(item));
                }
            }
            return View(studentVMs);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            StudentVM studentVM = new StudentVM();
            using (StudentService.StudentClient service = new StudentService.StudentClient())
            {
                var studentDto = service.GetStudentById(id);
                studentVM = new StudentVM(studentDto);
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
                using (StudentService.StudentClient service = new StudentService.StudentClient())
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
                    service.PostStudent(studentDto);
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
            using (StudentService.StudentClient service = new StudentService.StudentClient())
            {
                var studentDto = service.GetStudentById(id);
                studentVM = new StudentVM(studentDto);
            }
            ViewBag.Nationalities = LoadDataUtils.LoadNationalityData();
            ViewBag.Faculties = LoadDataUtils.LoadFacultyData();
            return View(studentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentVM studentVM)
        {
            try
            {
                using (StudentService.StudentClient service = new StudentService.StudentClient())
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
                    service.PostStudent(studentDto);
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
            using (StudentService.StudentClient service = new StudentService.StudentClient())
            {
                service.DeleteStudent(id);
            }
            return RedirectToAction("Index");
        }
    }
}
