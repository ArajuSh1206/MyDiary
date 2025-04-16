using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyDiary.Data;
using MYDIARY.Models;

namespace MyDiary.Controllers
{
    [Route("DiaryEntries")]  // Base route for this controller
    public class DiaryEntriesController : Controller
    {
        private readonly ILogger<DiaryEntriesController> _logger;
        private readonly ApplicationDbContext _db;

        // Merged constructor
        public DiaryEntriesController(ILogger<DiaryEntriesController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        // Route: /DiaryEntries
        [Route("")]
        public IActionResult Index()
        {
            List<DiaryEntry> diaryEntriesList = _db.DiaryEntries.ToList();
            return View(diaryEntriesList);
        }

        // Route: /DiaryEntries/Error
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error");
        }

        // Route: /DiaryEntries/WriteEntries
        [Route("WriteEntries")]
        public IActionResult WriteEntries()
        {
            return View();
        }

        [HttpPost]
        [Route("WriteEntries")]
        public IActionResult WriteEntries(DiaryEntry obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            _db.DiaryEntries.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
