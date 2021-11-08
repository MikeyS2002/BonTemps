using System;
using System.ComponentModel.DataAnnotations;

namespace BonTemps.Models
{
    public class ReservationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _dateStartReservation = Convert.ToDateTime(value);
            if (_dateStartReservation >= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}