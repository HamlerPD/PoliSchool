using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Interfaces;

namespace PoliSchool.Web.Controllers
{
    public class OfficeAssignmentController : Controller
    {

        private readonly IOfficeAssignmentDao officeAssignmentDao;

        public OfficeAssignmentController(IOfficeAssignmentDao officeAssignmentDao)
        {
            this.officeAssignmentDao = officeAssignmentDao;
        }

        // GET: OfficeAssignmentModelController
        public ActionResult Index()
        {
            var OfficeAssigment = this.officeAssignmentDao.GetOfficeAssignmens().Select(of => new Models.OfficeAssignmentListModel()
            {
                InstructorId = of.InstructorId, 
                Location = of.Location

            }).ToList();
            return View(OfficeAssigment);
        }

        // GET: OfficeAssignmentModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OfficeAssignmentModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfficeAssignmentModelController/Create
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

        // GET: OfficeAssignmentModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OfficeAssignmentModelController/Edit/5
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

        // GET: OfficeAssignmentModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OfficeAssignmentModelController/Delete/5
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
