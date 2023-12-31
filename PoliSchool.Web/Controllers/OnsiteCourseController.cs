using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class OnsiteCourseController : Controller
    {
        private readonly IOnsiteCourseDao onsiteCourseDao;

        public OnsiteCourseController(IOnsiteCourseDao onsiteCourseDao)
        {
            this.onsiteCourseDao = onsiteCourseDao;
        }
        // GET: OnsiteCourseController
        public ActionResult Index()
        {
            var onsiteCourse = this.onsiteCourseDao.GetOnsiteCourse().Select(Ons => new Models.OnsiteCourseListModel()
            {
               CourseId = Ons.CourseId,
                Location = Ons.Location,
                Days = Ons.Days

            }).ToList();
            return View(onsiteCourse);
           
        }

        // GET: OnsiteCourseController/Details/5
        public ActionResult Details(int id)
        {
            var onsiteCourseModel = this.onsiteCourseDao.GetIOnsiteCourseById(id);
            OnsiteCourseListModel onsiteCourse = new OnsiteCourseListModel()
            {
                CourseId = onsiteCourseModel.CourseId,
                Location = onsiteCourseModel.Location, 
                Days = onsiteCourseModel.Days, 
                Time = onsiteCourseModel.Time

            };
            return View(onsiteCourse);
         
        }

        // GET: OnsiteCourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OnsiteCourseController/Create
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

        // GET: OnsiteCourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OnsiteCourseController/Edit/5
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

        // GET: OnsiteCourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OnsiteCourseController/Delete/5
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
