using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class GradeFormatAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Grade cannot be null.");
        }

        string grade = value.ToString();
        // Regex: Matches digits (1 or more) followed by "st", "nd", "rd", or "th"
        if (Regex.IsMatch(grade, @"^\d+(st|nd|rd|th)$"))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Grade must be in the format '1st', '2nd', '3rd', '4th', etc.");
    }
}