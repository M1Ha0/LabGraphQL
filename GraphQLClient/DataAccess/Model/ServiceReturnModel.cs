namespace GraphQLClient.DataAccess.Model
{
    public class ServiceReturnModel
    {
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public decimal Price { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
