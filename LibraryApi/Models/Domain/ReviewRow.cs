using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models.Domain
{
    [Table("Reviews")]
    public class ReviewRow
    {
        //Id
        //UserId
        //BookId
        //Rating
        //Review
        //ReviewDate
        //

        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public required string Title { get; set; }
        //Text review
        public required string Review { get; set; }
        //1-5 stars
        public required int Rating{ get; set; }

        [Column(TypeName = "date")]
        public required DateTime ReviewDate { get; set; }

    }
}
