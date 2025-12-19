using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQLClient.DataAccsess.Model
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string LastName { get; set; }
        public string? Specialty { get; set; }
        public string? Phone { get; set; }
        public ICollection<Service> Services { get; set; }
        public override string ToString()
        {
            return $"TeacherId: {TeacherId},\n" +
                   $"Name: {Name},\n" +
                   $"SurName: {SurName},\n" +
                   $"LastName: {LastName},\n" +
                   $"Specialty: {Specialty},\n" +
                   $"Phone: {Phone},\n";
        }
    }
}
