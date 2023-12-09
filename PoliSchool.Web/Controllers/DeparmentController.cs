using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PoliSchool.Web.Controllers
{
    public class DeparmentController : Controller
    {
        // GET: DeparmentControllerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DeparmentControllerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
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
