using BookingProject.Dal.Entities;
using BookingProject.Dal.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookingProject.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly IMongoCollection<ContactInfo> _contactInfoCollection;
        public ContactInfoController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactInfoCollection = database.GetCollection<ContactInfo>(_databaseSettings.ContactInfoCollectionName);
        }
        public async Task<IActionResult> Index()
        {
            var values = await _contactInfoCollection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContactInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactInfo(ContactInfo contactInfo)
        {
            await _contactInfoCollection.InsertOneAsync(contactInfo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteContactInfo(string id)
        {
            await _contactInfoCollection.DeleteOneAsync(x => x.ContactInfoID == id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateContactInfo(string id)
        {
            var values = await _contactInfoCollection.Find(x => x.ContactInfoID == id).FirstOrDefaultAsync();
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateContactInfo(ContactInfo contactInfo)
        {
            await _contactInfoCollection.FindOneAndReplaceAsync(x => x.ContactInfoID == contactInfo.ContactInfoID, contactInfo);
            return RedirectToAction("Index");
        }
    }
}
