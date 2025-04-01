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

        // Merging both dependencies into a single constructor
        public DiaryEntriesController(ILogger<DiaryEntriesController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        // Explicit route for Index action: /DiaryEntries
        //Extremely important if routing other views folderfiles.
        [Route("")]  // This is equivalent to /DiaryEntries
        public IActionResult Index()
        {
            List<DiaryEntry> diaryEntriesList = _db.DiaryEntries.ToList();

            return View(diaryEntriesList);
        }

        // Explicit route for Error action: /DiaryEntries/Error
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
