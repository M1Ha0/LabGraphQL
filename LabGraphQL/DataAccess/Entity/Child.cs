using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLProject.DataAccess.Entity
{
    public class Child
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChildId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateOnly BirhDate { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        
    }
}
