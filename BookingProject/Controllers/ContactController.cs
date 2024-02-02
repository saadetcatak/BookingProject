using BookingProject.Dal.Entities;
using BookingProject.Dal.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookingProject.Controllers
{
    public class ContactController : Controller
    {

        private readonly IMongoCollection<Contact> _contactColection;
        public ContactController(IDatabaseSettings _databaseSettings)
        {

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactColection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);

        }

        public async Task<IActionResult> Index()
        {
            var values=await _contactColection.Find(x=> true).ToListAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactColection.DeleteOneAsync(x => x.ContactID == id);
            return RedirectToAction("Index");
        }


        
        public async Task<IActionResult> DetailContact(string id)
        {
            var values = await _contactColection.Find(x => x.ContactID == id).FirstOrDefaultAsync();
            return View(values);
        }
    }
}
