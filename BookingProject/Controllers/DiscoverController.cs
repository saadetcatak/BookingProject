using BookingProject.Dal.Entities;
using BookingProject.Dal.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookingProject.Controllers
{
    public class DiscoverController : Controller
    {
        private readonly IMongoCollection<Discover> _discoverCollection;
        public DiscoverController(IDatabaseSettings _databaseSettings)
        {
           var client=new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
          _discoverCollection=database.GetCollection<Discover>(_databaseSettings.DiscoverCollectionName);
        }
        public async Task<IActionResult> Index()
        {
            var values = await _discoverCollection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateDiscover()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscover(Discover discover)
        {
            await _discoverCollection.InsertOneAsync(discover);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDiscover(string id)
        {
            await _discoverCollection.DeleteOneAsync(x => x.DiscoverID == id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateDiscover(string id)
        {
            var values = await _discoverCollection.Find(x => x.DiscoverID == id).FirstOrDefaultAsync();
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateDiscover(Discover discover)
        {
            await _discoverCollection.FindOneAndReplaceAsync(x => x.DiscoverID == discover.DiscoverID, discover);
            return RedirectToAction("Index");
          
        }
    }
}
