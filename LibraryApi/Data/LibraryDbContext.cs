using LibraryApi.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data
{
    //JJR 3/2/2025: Definition before adding ASP.NET Identity:
    //public class LibraryDbContext : DbContext

    public class LibraryDbContext : IdentityDbContext<IdentityUser>
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserRow> UsersTable { get; set; }
        public DbSet<BookRow> BooksTable { get; set; }
        public DbSet<ReviewRow> ReviewsTable { get; set; }

    }
}
