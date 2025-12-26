using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraphQLClient.DataAccess.Model
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public decimal Price { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public override string ToString()
        {
            return $"ServiceId: {ServiceId},\n" +
                   $"ServiceName: {ServiceName},\n" +
                   $"Price: {Price},\n" +
                   $"TeacherId: {TeacherId},\n" +
                   $"Teacher: {Teacher.ToString},\n";
        }
    }
}
