using BookingProject.Dal.Entities;
using BookingProject.Dal.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookingProject.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IMongoCollection<Subscribe> _subscribeColection;
        public SubscribeController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _subscribeColection = database.GetCollection<Subscribe>(_databaseSettings.SubscribeCollectionName);
        }
        public async Task<IActionResult> Index()
        {
            var values = await _subscribeColection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSubscribe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(Subscribe subscribe)
        {
            await _subscribeColection.InsertOneAsync(subscribe);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSubscribe(string id)
        {
            await _subscribeColection.DeleteOneAsync(x => x.SubscribeID == id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateSubscribe(string id)
        {
            var values = await _subscribeColection.Find(x => x.SubscribeID == id).FirstOrDefaultAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscribe(Subscribe subscribe)
        {
            await _subscribeColection.FindOneAndReplaceAsync(x => x.SubscribeID == subscribe.SubscribeID, subscribe);
            return RedirectToAction("Index");
        }
    }
}
