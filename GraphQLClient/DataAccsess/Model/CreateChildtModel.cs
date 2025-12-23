using System.ComponentModel.DataAnnotations;

namespace GraphQLClient.DataAccsess.Model
{
    public class CreateChildtModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "BirhDate is required")]
        public DateOnly BirhDate { get; set; }
        [Required(ErrorMessage = "Parent Id is required")]
        public int ParentId { get; set; }

    }
}
