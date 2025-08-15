using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class RoomNumberFormatAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Room number cannot be null.");
        }

        string roomNumber = value.ToString();
        // Regex: At least one letter and one number, any combination of letters and numbers
        if (Regex.IsMatch(roomNumber, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$"))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Room number must contain both letters and numbers.");
    }
}