using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQLClient.DataAccsess.Model
{
    public class Child
    {
        public int ChildId { get; set; }
        public string? Name { get; set; }
        public DateOnly BirhDate { get; set; }
        public int ParentId { get; set; }
        public Parent? Parent { get; set; }
        public override string ToString()
        {
            return $"ChildId: {ChildId},\n" +
                   $"Name: {Name},\n" +
                   $"BirhDate: {BirhDate},\n" +
                   $"ParentId: {ParentId},\n" +
                   $"Parent: {Parent!.ToString},\n";
        }
    }
}
