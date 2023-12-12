using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentDao studentDao;

        public StudentController(IStudentDao studentDao)
        {
            this.studentDao = studentDao;
        }

        // GET: StudentController1
        public ActionResult Index()
        {
            var students = this.studentDao.GetStudents().Select(cd => new Models.StudentListModel() 
            { 
                CreationdateDisplay = cd.CreationdateDisplay,
                EnrollmentDate = cd.EnrollmentDate,
                EnrollmentDateDisplay = cd.EnrollmentDateDisplay,
                Id = cd.Id,
                Name = cd.Name

            }).ToList();
            return View(students);
        }
        // GET: StudentController1/Details/5
        public ActionResult Details(int id)
        {
            var studentsmodel = this.studentDao.GetStudentById(id);
            StudentListModel student = new StudentListModel() 
            { 
                EnrollmentDate = studentsmodel.EnrollmentDate,
                Id = studentsmodel.Id,
                Name = studentsmodel.Name
            };
            return View();
        }

        // GET: StudentController1/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: StudentController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentView)
        {
            try
            {
                Student studentToAdd = new Student()
                {
                    FirstName = studentView.FirstName,
                    LastName = studentView.LastName,
                    EnrollmentDate = DateTime.Now,
                    CreationUser = 1

                };

                this.studentDao.SaveStudent(studentToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController1/Edit/5
        public ActionResult Edit(int id)
        {
            var studentModel = this.studentDao.GetStudentById(id);
            StudentViewModel studentViewModel = new StudentViewModel()
            {
               EnrollmentDate = studentModel.EnrollmentDate, 
                FirstName = studentModel.FirstName, 
                LastName = studentModel.LastName,
                Id = studentModel.Id
            };

            return View(studentViewModel);
        }

        // POST: StudentController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel studentView)
        {
            try
            {
                Student studentToUpdate = new Student()
                {
                    Id = studentView.Id,
                    FirstName = studentView.FirstName,
                    LastName = studentView.LastName,
                    EnrollmentDate = studentView.EnrollmentDate,
                    Modifydate = DateTime.Now,
                    UserMod = 1

                    
                };

                this.studentDao.UpdateStudent(studentToUpdate);

                return RedirectToAction(nameof(Index));
            }
      
            catch
            {
                return View();
            }
        }

    }
}
