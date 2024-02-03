using BookingProject.Dal.Entities;
using BookingProject.Dal.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookingProject.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        public TestimonialController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
        }
        public IActionResult Index()
        {
            var values = _testimonialCollection.Find(x => true).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(Testimonial testimonial)
        {
            await _testimonialCollection.InsertOneAsync(testimonial);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x => x.TestimonialID == id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TestimonialDetail(string id)
        {
            var values = await _testimonialCollection.Find(x => x.TestimonialID == id).FirstOrDefaultAsync();
            return View(values);
        }
    }
}
