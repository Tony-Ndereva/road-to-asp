using System.ComponentModel.DataAnnotations;
namespace road_to_asp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}
