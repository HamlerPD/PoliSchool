using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Interfaces;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class DeparmentController : Controller
    {

        private readonly IDeparment deparmentDao;

        public DeparmentController(IDeparment deparmentDao)
        {
            this.deparmentDao = deparmentDao;
        }

        // GET: DeparmentControllerController
        public ActionResult Index()
        {
            var deparments = this.deparmentDao.GetDeparments().Select(de => new Models.DeparmentListModel()
            {
                DepartmentID = de.DepartmentID,
                Name = de.Name,
                StartDate = de.StartDate,
                Administrator = de.Administrator,
                Creationdate = de.Creationdate,
            }).ToList();
            return View(deparments);

        }

        // GET: DeparmentControllerController/Details/5
        public ActionResult Details(int Id)
        {
            var deparmentModel = this.deparmentDao.GetDeparmentById(Id);
            DeparmentListModel deparment = new DeparmentListModel()
            {
                DepartmentID = deparmentModel.DepartmentID,
                Creationdate = deparmentModel.Creationdate,
                Name = deparmentModel.Name,
                StartDate = deparmentModel.StartDate
            };
            return View(deparment);

        }

        // GET: DeparmentControllerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeparmentControllerController/Create
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

        // GET: DeparmentControllerController/Edit/5
        public ActionResult Edit(int courseId)
        {
            return View();
        }

        // POST: DeparmentControllerController/Edit/5
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

        // GET: DeparmentControllerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeparmentControllerController/Delete/5
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
