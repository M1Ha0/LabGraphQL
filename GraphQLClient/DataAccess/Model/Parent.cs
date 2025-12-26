using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQLClient.DataAccess.Model
{
    public class Parent
    {
        public int ParentId { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string LastName { get; set; }
        public string? Phone { get; set; }
        public ICollection<Child> Childs { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public override string ToString()
        {
            return $"ParentId: {ParentId},\n" +
                   $"Name: {Name},\n" +
                   $"SurName: {SurName},\n" +
                   $"LastName: {LastName},\n" +
                   $"Phone: {Phone},\n";
        }
    }
}
