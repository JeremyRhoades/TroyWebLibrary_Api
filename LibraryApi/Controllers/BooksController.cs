using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryDbContext dbContext;

        public BooksController(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;


            //Generate fake data
            DataGenerator dg = new DataGenerator();
            foreach (BookRow bookRow in dg.GetFakeBooks())
                AddBookRow(dg.GetBookDTO(bookRow), bookRow.Id);

        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var contacts = dbContext.BooksTable.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddBookRow(AddBookRequestDTO request, Guid? guid = null)
        {
            //JJR 3/2/2025: Create new book based on model, and using incoming request information
            var domainModelBook = new BookRow
            {
              
                  Id = guid ?? Guid.NewGuid(), //JJR 3/2/2025: Generate new ID if not provided by fake data
                  Title = request.Title,
                  Author = request.Author,
                  Description = request.Description,
                  CoverImageUrl = request.CoverImageUrl,
                  Publisher = request.Publisher,
                  PublicationDate = request.PublicationDate,
                  Category = request.Category,
                  ISBN = request.ISBN,
                  PageCount = request.PageCount,
                  CheckedOut = request.CheckedOut,
                  CheckedOutUser = request.CheckedOutUser,
                  CheckedOutDate = request.CheckedOutDate

            };

            //JJR 3/2/2025: Create and save new book in Database
            dbContext.BooksTable.Add(domainModelBook);
            dbContext.SaveChanges();

            //JJR 3/2/2025: Return newly saved user information on success.
            return Ok(domainModelBook);
        }


        /*
        [HttpPost]
        public IActionResult CheckOutBookRow(AddBookRequestDTO request)
        {
            //WIP/TO DO: update book info
            var bookToUpdate = dbContext.BooksTable.Find();
            dbContext.BooksTable.Update(bookToUpdate);
            
            return Ok();
        }

        [HttpPost]
        public IActionResult ReturnBookRow(AddBookRequestDTO request)
        {
            return Ok();
        }*/

        [HttpDelete]
        [Route("id:guid")]
        public IActionResult DeleteBookRow(Guid id)
        {
            var bookToDelete = dbContext.BooksTable.Find(id);

            if (bookToDelete != null)
            {
                dbContext.BooksTable.Remove(bookToDelete);
                dbContext.SaveChanges();
            }


            return Ok();
        }

    }
}
