using Bogus;
using Bogus.DataSets;
using LibraryApi.Models;
using LibraryApi.Models.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Data
{
    public class DataGenerator
    {
        public static Faker<UserRow>? FakeUser;
        public static IEnumerable<UserRow>? FakeUserList;

        public static Faker<BookRow>? FakeBook;
        public static IEnumerable<BookRow>? FakeBookList;

        public static Faker<ReviewRow>? FakeReview;
        public static IEnumerable<ReviewRow>? FakeReviewList;


        public static String[] Categories = new String[] { "Romance", "History", "Fiction", "Fantasy", "Self Help", "Mystery" };

        static DataGenerator()
        {
            Randomizer.Seed = new Random(123);

            FakeUser = new Faker<UserRow>()
                .RuleFor(u => u.Id, f => f.Random.Uuid())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.BirthDate, f => f.Date.Between(new DateTime(1960, 1, 1), new DateTime(2010, 1, 1)).Date.ToString())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.Role, f => f.Random.WeightedRandom(["Librarian", "Customer"], [0.1f, 0.9f]))
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.JoinDate, f => f.Date.Between(new DateTime(2011, 1, 1), new DateTime(2025, 1, 1)).Date);

            FakeUserList = FakeUser.GenerateForever().Take(30);

            FakeBook = new Faker<BookRow>()
                .RuleFor(u => u.Id, f => f.Random.Uuid())
                .RuleFor(u => u.Title, f => "How To Learn " + f.Lorem.Word())
                .RuleFor(u => u.Author, f => f.Name.FullName())
                .RuleFor(u => u.Description, f => f.Lorem.Paragraph())
                .RuleFor(u => u.CoverImageUrl, f => f.Image.PicsumUrl())
                .RuleFor(u => u.Publisher, f => f.Lorem.Word() + " Publishing")
                .RuleFor(u => u.PublicationDate, f => f.Date.Between(new DateTime(2011, 1, 1), new DateTime(2024, 1, 1)).Date.ToString())
                .RuleFor(u => u.Category, f => f.PickRandom(Categories))
                .RuleFor(u => u.ISBN, f => f.Random.Long(1000000000000,9999999999999))
                .RuleFor(u => u.PageCount, f => f.Random.Int(100, 700))
                .RuleFor(u => u.CheckedOut, f => f.Random.Bool())
                .RuleFor(u => u.CheckedOutUser, f => f.Random.Uuid())
                .RuleFor(u => u.CheckedOutDate, f => f.Date.Between(new DateTime(2024, 11, 11), new DateTime(2025, 1, 1)).Date.ToString());

            FakeBookList = FakeBook.GenerateForever().Take(135);

            FakeReview = new Faker<ReviewRow>()
                .RuleFor(u => u.Id, f => f.Random.Uuid())
                .RuleFor(u => u.UserId, f => f.Random.Uuid())
                .RuleFor(u => u.BookId, f => f.Random.Uuid())
                .RuleFor(u => u.Title, f => f.Lorem.Sentence())
                .RuleFor(u => u.Review, f => f.Rant.Review())
                .RuleFor(u => u.Rating, f => f.Random.Int(1, 5))
                .RuleFor(u => u.ReviewDate, f => f.Date.Between(new DateTime(2011, 1, 1), new DateTime(2025, 1, 1)).Date);

            FakeReviewList = FakeReview.GenerateForever().Take(30);

        }

        public IEnumerable<UserRow> GetFakeUsers()
        {
            return FakeUserList!;
        }

        public IEnumerable<BookRow> GetFakeBooks()
        {
            return FakeBookList!;
        }
        public IEnumerable<ReviewRow> GetFakeReviews()
        {
            return FakeReviewList!;
        }


        public AddUserRequestDTO GetUserDTO(UserRow nextUser)
        {
            AddUserRequestDTO userDTO = new AddUserRequestDTO
            {
                FirstName = nextUser.FirstName,
                LastName = nextUser.LastName,
                BirthDate = nextUser.BirthDate,
                Email = nextUser.Email,
                Password = nextUser.Password,
                Phone = nextUser.Phone,
                Role = nextUser.Role
            };

            return userDTO;
        }

        public AddBookRequestDTO GetBookDTO(BookRow nextBook)
        {
            AddBookRequestDTO bookDTO = new AddBookRequestDTO
            {
                Title = nextBook.Title,
                Author = nextBook.Author,
                Description = nextBook.Description,
                CoverImageUrl = nextBook.CoverImageUrl,
                Publisher = nextBook.Publisher,
                PublicationDate = nextBook.PublicationDate,
                Category = nextBook.Category,
                ISBN = nextBook.ISBN,
                PageCount = nextBook.PageCount,
                CheckedOut = nextBook.CheckedOut,
                CheckedOutUser = nextBook.CheckedOutUser,
                CheckedOutDate = nextBook.CheckedOutDate
            };

            return bookDTO;
        }

        public AddReviewRequestDTO GetReviewDTO(ReviewRow nextReview)
        {
            AddReviewRequestDTO reviewDTO = new AddReviewRequestDTO
            {
                Id = nextReview.Id,
                UserId = nextReview.UserId,
                BookId = nextReview.BookId,
                Title = nextReview.Title,
                Review = nextReview.Review,
                Rating = nextReview.Rating,
                ReviewDate = nextReview.ReviewDate
            };

            return reviewDTO;
        }
    }
}