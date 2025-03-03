using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models.Domain
{

    /**
     * APPLICATION REQUIREMENTS:
     *   Ensure the Book table includes:
     *      Title,
     *      Author,
     *      Description,
     *      Cover Image,
     *      Publisher,
     *      Publication Date,
     *      Category,
     *      ISBN,
     *      Page Count
     *      
     *      Include any other relevant columns as you see fit
     */
    [Table("Books")]
    public class BookRow
    {
        [Key]
        public Guid Id { get; set; }

        //Book info
        public required string Title { get; set; }

        public required string Author { get; set; }

        public required string Description { get; set; }

        //JJR 3/1/2025:
        //TO DO: Set Image via ID in lookup table/foreign key.
        //       This can allow for other images (profile pictures, etc.).
        // public string CoverImageId { get; set; }
        public string? CoverImageUrl { get; set; }
        

        //JJR 3/1/2025: NOTE: Could be moved to a publisher table/role using PublisherId in place of a name
        public required string Publisher { get; set; }

        public required string PublicationDate { get; set; }

        //JJR 3/1/2025: NOTE: Could be moved to a Category ID with a lookup table
        public required string Category { get; set; }

        public required long ISBN { get; set; }

        public required int PageCount { get; set; }

        //JJR 3/2/2025: NOTE: This information could be moved to a separate table to keep track of checkouts
        //Leaving in this table for simplicity, and because the requirements state that there is only one copy of each book
        public required bool CheckedOut { get; set; }

        public Guid? CheckedOutUser { get; set; }
        public string? CheckedOutDate { get; set; }

    }
}
