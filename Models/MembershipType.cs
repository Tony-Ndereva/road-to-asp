namespace road_to_asp.Models
{
    public class MembershipType
    {
        public byte MemberShipTypeId { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
