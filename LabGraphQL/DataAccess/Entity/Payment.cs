using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLProject.DataAccess.Entity
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        [Required]
        public DateOnly PaymentDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public int ServicesId { get; set; }
        public Service Services { get; set; }

    }
}
