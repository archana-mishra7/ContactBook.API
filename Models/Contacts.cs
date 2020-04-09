using System.ComponentModel.DataAnnotations;
namespace ContactBook.API.Models
{
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string? contactGroupID { get; set; }
    }
}