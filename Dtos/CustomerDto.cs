using System.ComponentModel.DataAnnotations;

namespace road_to_asp.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        // [Min18YearsIfAMember]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}
