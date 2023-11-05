using System.ComponentModel.DataAnnotations;

namespace road_to_asp.Models
{
    public class Min18YearsIfAMember :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object ? value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer .MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is a must");
            }
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) ?
                ValidationResult.Success
                : new ValidationResult("Customer should be atleast 18 years of age");
        }
    }
}
