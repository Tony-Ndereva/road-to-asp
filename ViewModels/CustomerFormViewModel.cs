using road_to_asp.Models;

namespace road_to_asp.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public CustomerFormViewModel()
        {
            MembershipTypes = new List<MembershipType>();
        }
    }
}
