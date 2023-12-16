using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Interfaces;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class InstructorController : Controller
    { 

        private readonly IInstructorDao? instructorDao;

        public InstructorController ( IInstructorDao instructorDao)
        {
            this.instructorDao = instructorDao;
        }
        // GET: InstructorController
        public ActionResult Index()
        {
            var instructor = this.instructorDao.GetInstructors().Select(ins => new Models.InstructorListModel()
            {
                Id = ins.Id,
                Name = ins.Name, 
                HireDate = ins.HireDate, 
                Creationdate  = ins.Creationdate,

            }).ToList();
            return View(instructor);
        }

        // GET: InstructorController/Details/5
        public ActionResult Details(int id)
        {
            var instructorModel = this.instructorDao.GetInstructorById(id);
            InstructorListModel instructor = new InstructorListModel()
            {
                Id = instructorModel.Id, Name = instructorModel.Name, 
                HireDate = instructorModel.HireDate,
                Creationdate = instructorModel.Creationdate,
            };
            return View(instructor);
        }

        // GET: InstructorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstructorController/Create
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

        // GET: InstructorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InstructorController/Edit/5
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

        // GET: InstructorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InstructorController/Delete/5
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
