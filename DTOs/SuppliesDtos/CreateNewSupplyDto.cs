using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTOs.SuppliesDtos
{
    public class CreateNewSupplyDto
    {
        public int StudentId { get; set; }
        public string ItemName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int QuantityAvailable { get; set; }
    }
}
