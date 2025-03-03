using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LibraryDbContext dbContext;

        public UsersController(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;

            //Generate fake data
            DataGenerator dg = new DataGenerator();
            foreach (UserRow userRow in dg.GetFakeUsers())
                AddUserRow(dg.GetUserDTO(userRow), userRow.Id, userRow.JoinDate);
            
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var contacts = dbContext.UsersTable.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddUserRow(AddUserRequestDTO request, Guid? guid = null, DateTime? joinDate = null)
        {
            //JJR 3/1/2025: Create new user based on model, and using incoming request information
            var domainModelUser = new UserRow
            {
                Id = guid ?? Guid.NewGuid(), //JJR 3/2/2025: Generate new ID if not provided by fake data
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Email = request.Email,
                Password = request.Password,
                Phone = request.Phone,
                Role = request.Role,
                JoinDate = joinDate ?? new DateTime().Date //JJR 3/1/2025: New user, join date should be set to today
            };

            //JJR 3/1/2025: Create and save new user in Database
            dbContext.UsersTable.Add(domainModelUser);
            dbContext.SaveChanges();

            //JJR 3/1/2025: Return newly saved user information on success.
            return Ok(domainModelUser);
        }


        [HttpDelete]
        [Route("id:guid")]
        public IActionResult DeleteUserRow(Guid id)
        {
            var userToDelete = dbContext.UsersTable.Find(id);

            if (userToDelete != null)
            {
                dbContext.UsersTable.Remove(userToDelete);
                dbContext.SaveChanges();
            }


            return Ok();
        }

    }
}
