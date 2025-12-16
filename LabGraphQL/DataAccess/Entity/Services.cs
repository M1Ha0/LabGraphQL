using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLProject.DataAccess.Entity
{
    public class Services
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServicesId { get; set; }
        [Required]
        public string? ServicesName {  get; set; }
        [Required]
        public decimal Price { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
