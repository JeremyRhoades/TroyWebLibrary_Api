using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Models.Domain
{
    [Table("Users")]
    public class UserRow
    {
        [Key]
        public Guid Id { get; set; }

        //JJR 3/1/2025: First name/Last name over a custom username - feels standard for libary accounts
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        
        [Column(TypeName = "date")]
        public required string BirthDate { get; set; }

        //JJR 3/1/2025: Assumed to be required for account management
        public required string Email { get; set; }
        public required string Password { get; set; }

        //JJR 3/1/2025: Assumed to be required for account management
        //public required bool EmailVerified { get; set; }
        //public required int EmailVerificationCode { get; set; }


        //Assumed to be required for account management
        public string? Phone { get; set; }
        
        //JJR 3/1/2025: 
        //TO DO: Set Roles via lookup table/foreign key. (Research needed to determine if required)
        //0 = Librarian
        //1 = Customer
        //2 = Publisher
        //public required int RoleId { get; set; }
        
        public required string Role { get; set; }
        
        [Column(TypeName = "date")]
        public required DateTime JoinDate { get; set; }

        //JJR 3/1/2025:
        //TO DO: Set Profile Image via ID in lookup table/foreign key.
        // public string ProfilePictureId { get; set; }


    }
}
