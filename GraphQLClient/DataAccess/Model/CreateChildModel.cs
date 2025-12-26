using System.ComponentModel.DataAnnotations;

namespace GraphQLClient.DataAccess.Model
{
    public class CreateChildModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "BirhDate is required")]
        public DateOnly BirhDate { get; set; }
        [Required(ErrorMessage = "Parent Id is required")]
        public int ParentId { get; set; }

    }
}
