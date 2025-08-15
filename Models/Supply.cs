using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Supply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId{ get; set; }
        public int StudentId{ get; set; }
        public string ItemName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int QuantityAvailable{ get; set; }

        // Navigation property for the student
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
