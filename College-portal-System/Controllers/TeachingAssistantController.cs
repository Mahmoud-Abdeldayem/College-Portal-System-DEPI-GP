using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace College_portal_System.Controllers
{
    public class TeachingAssistantController : Controller
    {
        // GET: TeachingAssistantController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Assignments()
        {
            return View();
        }

        public ActionResult EditAssignments()
        {
            return View();
        }
        public ActionResult CreateQuiz()
        {
            return View();
        }

        public ActionResult Results()
        {
            return View();
        }

        // GET: TeachingAssistantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeachingAssistantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeachingAssistantController/Create
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

        // GET: TeachingAssistantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeachingAssistantController/Edit/5
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

        // GET: TeachingAssistantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeachingAssistantController/Delete/5
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
