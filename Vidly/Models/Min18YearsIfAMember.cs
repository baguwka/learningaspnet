using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
   public class Min18YearsIfAMember : ValidationAttribute
   {
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
         var customer = validationContext.ObjectInstance as Customer;
         if (customer == null) return ValidationResult.Success;

         if (customer.MembershipTypeId == MembershipType.Unknown 
            || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            return ValidationResult.Success;

         if (customer.Birtday == null)
            return new ValidationResult("Birthday is required.");

         var age = DateTime.Today.Year - customer.Birtday.Value.Year;

         return age >= 18 
            ? ValidationResult.Success 
            : new ValidationResult("Customer should be a least 18 years old");
      }
   }
}