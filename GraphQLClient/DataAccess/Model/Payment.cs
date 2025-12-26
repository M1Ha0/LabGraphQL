using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQLClient.DataAccess.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateOnly PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public int ServicesId { get; set; }
        public Service Service { get; set; }
        public override string ToString()
        {
            return $"PaymentId: {PaymentId},\n" +
                   $"PaymentDate: {PaymentDate},\n" +
                   $"ParentId: {ParentId},\n" +
                   $"Parent: {Parent.ToString},\n" +
                   $"ServicesId: {ServicesId},\n"+
                   $"Services: {Service.ToString},\n";
        }
    }
}
