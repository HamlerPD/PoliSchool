using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PoliSchool.Web.Controllers
{
    public class StudentController1 : Controller
    {
        // GET: StudentController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentController1/Details/5
        public ActionResult Details(int id)
        {
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

        // GET: StudentController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController1/Edit/5
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

    }
}
