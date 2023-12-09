using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PoliSchool.Web.Controllers
{
    public class OnsiteCourseController : Controller
    {
        // GET: OnsiteCourseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OnsiteCourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
