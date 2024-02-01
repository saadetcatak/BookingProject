using BookingProject.Dal.Entities;
using BookingProject.Dal.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookingProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly IMongoCollection<About> _aboutColection;
        public AboutController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutColection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
        }

        public async Task<IActionResult> Index()
        {
            var values=await _aboutColection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(About about)
        {
            await _aboutColection.InsertOneAsync(about);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutColection.DeleteOneAsync(x=>x.AboutID == id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var values = await _aboutColection.Find(x => x.AboutID == id).FirstOrDefaultAsync();
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAbout(About about)
        {
            await _aboutColection.FindOneAndReplaceAsync(x => x.AboutID == about.AboutID, about);
            return RedirectToAction("Index");
        }

    }
}
