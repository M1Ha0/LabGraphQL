using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLProject.DataAccess.Entity
{
    public class Parent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParentId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? SurName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string?  Phone { get; set; }
        public ICollection<Child> Childs { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
