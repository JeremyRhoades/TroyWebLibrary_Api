using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly LibraryDbContext dbContext;

        public ReviewsController(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
            //Generate fake data
            DataGenerator dg = new DataGenerator();
            foreach (ReviewRow reviewRow in dg.GetFakeReviews())
                AddReviewRow(dg.GetReviewDTO(reviewRow), reviewRow.Id);
        }

        [HttpGet]
        public IActionResult GetAllReviews()
        {
            var contacts = dbContext.ReviewsTable.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddReviewRow(AddReviewRequestDTO request, Guid? guid = null)
        {
            //JJR 3/2/2025: Create new review based on model, and using incoming request information
            var domainModelReview = new ReviewRow
            {
                Id = guid ?? Guid.NewGuid(), //JJR 3/2/2025: Generate new ID if not provided by fake data
                UserId = request.UserId,
                BookId = request.BookId,
                Title = request.Title,
                Review = request.Review,
                Rating = request.Rating,
                ReviewDate = new DateTime().Date
            };

            //JJR 3/2/2025: Create and save new review in Database
            dbContext.ReviewsTable.Add(domainModelReview);
            dbContext.SaveChanges();

            //JJR 3/2/2025: Return newly saved review information on success.
            return Ok(domainModelReview);
        }

    }
}
