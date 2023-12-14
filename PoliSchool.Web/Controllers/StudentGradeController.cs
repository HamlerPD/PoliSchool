using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Interfaces;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class StudentGradeController : Controller
    {
        private readonly IStudentGradeDao studentGradeDao;

        public StudentGradeController(IStudentGradeDao studentGradeDao)
        {
            this.studentGradeDao = studentGradeDao;
        }

        // GET: StudentGradeController
        public ActionResult Index()
        {
            var studentGrade = this.studentGradeDao.GetStudentGrades().Select(cd => new Models.StudentGradeModel()
            {
                EnrollmentId = cd.EnrollmentId, 
                CourseId = cd.CourseId, 
                Grade = cd.Grade, 
                StudentId = cd.StudentId

            }).ToList();
            return View(studentGrade);
        }

        // GET: StudentGradeController/Details/5
        public ActionResult Details(int id)
        {
            var studentGradeModel = this.studentGradeDao.GetStudentGradeById(id);
            StudentGradeModel studentGrade = new StudentGradeModel()
            {
                EnrollmentId = studentGradeModel.EnrollmentId, 
                CourseId = studentGradeModel.CourseId, 
                StudentId = studentGradeModel.StudentId, 
                Grade = studentGradeModel.Grade
            };
            return View(studentGrade);
           
        }

        // GET: StudentGradeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentGradeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentGradeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentGradeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentGradeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentGradeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
