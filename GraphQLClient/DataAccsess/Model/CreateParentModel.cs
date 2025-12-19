using System.ComponentModel.DataAnnotations;

namespace GraphQLClient.DataAccsess.Model
{
    public class CreateParentModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "SurName is required")]
        public string? SurName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string? Phone { get; set; }

    }
}
