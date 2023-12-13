using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliSchool.DAL.Daos;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Interfaces;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseDao courseDao;
        private readonly IDeparment departmentDao;

        public CourseController(ICourseDao courseDao, IDeparment departmentDao)
        {
            this.courseDao = courseDao;
            this.departmentDao = departmentDao;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            var course = this.courseDao.GetCourses().Select(co => new Models.CourseListModel()
            {
                CourseId = co.CourseId,
                CreationdateDisplay= co.CreationdateDisplay,
                Title = co.Title,
                Creationdate = co.Creationdate,
                DepartmentId = co.DepartmentId,
                Credits = co.Credits,
                DepartmentName = co.DepartmentName,
                Name = co.Name,

               
            });
            return View(course);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            var departments = this.departmentDao.GetDeparments();
            ViewData["Departments"] = new SelectList(departments, "DepartmentId", "Name", "Title");

            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseListModel courseView)
        {
            try
            {
                Course courseToAdd = new Course()
                {
                     CourseId= courseView.CourseId,
                     Title = courseView.Title,
                     DepartmentId = courseView.DepartmentId,
                     Credits = courseView.Credits,
                     Creationdate = courseView.Creationdate,


                };

               
                this.courseDao.SaveCourse(courseToAdd);
                return RedirectToAction(nameof(Index)); ;
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int courseId)
        {
            var courseModel = this.courseDao.GetCourseById(courseId);
            CourseListModel courseListModel = new CourseListModel()
            {
                CourseId= courseModel.CourseId,
                Title = courseModel.Title, 
                DepartmentId = courseModel.DepartmentId, 
                Credits = courseModel.Credits, 
                Creationdate = courseModel.Creationdate,
                
            };

            return View(courseListModel);

        
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseListModel courseListModel)
        {
            try
            {
                Course courseToUpdate = new Course()
                {
                    CourseId = courseListModel.CourseId,
                    Title = courseListModel.Title, 
                    DepartmentId = courseListModel.DepartmentId, 
                    Credits = courseListModel.Credits,
                    Creationdate = courseListModel.Creationdate,
                    Modifydate = DateTime.Now,
                    UserMod = 1


                };

                this.courseDao.UpdateCourse(courseToUpdate);

                return RedirectToAction(nameof(Index));

            }

            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
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
