using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabGraphQL.DataAccess.Entity
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        [Required]
        public string? Name {  get; set; }
        [Required]
        public string? SurName { get; set; }
        [Required]
        public string? Phone { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
