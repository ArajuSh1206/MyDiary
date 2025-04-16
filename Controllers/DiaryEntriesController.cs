using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyDiary.Data;
using MYDIARY.Models; // Fixed namespace casing consistency

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
            // First check null to avoid null reference exceptions
            if (obj == null)
            {
                return View();
            }

            // Custom validations
            if (string.IsNullOrEmpty(obj.Title) || obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too short. Must be min 3 characters long.");
            }

            if (string.IsNullOrEmpty(obj.Content) || obj.Content.Length < 20)
            {
                ModelState.AddModelError("Content", "Content too short. Must be min 20 characters long.");
            }

            // Check ModelState after all validations
            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            // If validation fails, return to the form with the model to show errors
            return View(obj);
        }

        [Route("Edit/{id}")]
        public IActionResult Edit(int? id) {

            if(id == null || id == 0){
                return NotFound();
            }
            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if(diaryEntry == null){
                return NotFound();
            }

            return View(diaryEntry);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(DiaryEntry obj)
        {
            // First check null to avoid null reference exceptions
            if (obj == null)
            {
                return View();
            }

            // Custom validations
            if (string.IsNullOrEmpty(obj.Title) || obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too short. Must be min 3 characters long.");
            }

            if (string.IsNullOrEmpty(obj.Content) || obj.Content.Length < 20)
            {
                ModelState.AddModelError("Content", "Content too short. Must be min 20 characters long.");
            }

            // Check ModelState after all validations
            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            // If validation fails, return to the form with the model to show errors
            return View(obj);
        }
    }
}