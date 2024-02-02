using BookingProject.Dal.Entities;
using BookingProject.Dal.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookingProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        public ServiceController(IDatabaseSettings _databaseSettings)
        {

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(_databaseSettings.ServiceCollectionName);

        }
        public async Task<IActionResult> Index()
        {
            var values= await _serviceCollection.Find(x=>true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(Service service)
        {
            await _serviceCollection.InsertOneAsync(service);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(string id)
        {
            await _serviceCollection.DeleteOneAsync(x => x.ServiceID == id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateService(string id)
        {
            var values = await _serviceCollection.Find(x => x.ServiceID == id).FirstOrDefaultAsync();
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateService(Service service)
        {
            await _serviceCollection.FindOneAndReplaceAsync(x => x.ServiceID == service.ServiceID, service);
            return RedirectToAction("Index");
        }

    }
}
