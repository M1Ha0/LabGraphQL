namespace GraphQLClient.DataAccess.Model
{
    public class ChildReturnModel
    {
        public int ChildId { get; set; }
        public string? Name { get; set; }
        public DateOnly BirhDate { get; set; }
        public int ParentId { get; set; }
       public Parent Parent { get; set; }
    }
}
