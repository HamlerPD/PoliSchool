using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Entities;
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
        public ActionResult Create(InstructorViewModel instructorView)
        {
            try
            {
                Instructor InstructorToAdd = new Instructor()
                {
                    FirstName = instructorView.FirstName,
                    LastName = instructorView.LastName, 
                    HireDate = instructorView.HireDate, 
                    CreationUser = 1,
                    Id = instructorView.Id
                    
                    

                };

                this.instructorDao.SaveInstructor(InstructorToAdd);
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
            var InstructorModel = this.instructorDao.GetInstructorById(id);
            InstructorViewModel instructorViewModel = new InstructorViewModel()
            {
                HireDate = InstructorModel.HireDate, 
                FirstName = InstructorModel.FirstName,
                LastName = InstructorModel.LastName, 
                Id = InstructorModel.Id


            };

            return View(instructorViewModel);
          
        }

        // POST: InstructorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstructorViewModel instructorView)
        {
            try
            {
                Instructor instructorToUpdate = new Instructor()
                {
                    Id = instructorView.Id, 
                    HireDate = instructorView.HireDate, 
                    FirstName = instructorView.FirstName, 
                    LastName = instructorView.LastName,
                    Modifydate = DateTime.Now,
                    UserMod = 1


                };

                this.instructorDao.UpdateInstructor(instructorToUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
