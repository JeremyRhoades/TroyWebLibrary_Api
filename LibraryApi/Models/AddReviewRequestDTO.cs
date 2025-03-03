using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models
{

    public class AddReviewRequestDTO
    {
        public Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public required Guid BookId { get; set; }
        public required string Title { get; set; }
        //Text review
        public required string Review { get; set; }
        //1-5 stars
        public required int Rating { get; set; }

        [Column(TypeName = "date")]
        public required DateTime ReviewDate { get; set; }
    }
}
