namespace GraphQLClient.DataAccess.Model
{
    public class TeacherReturnModel
    {
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string LastName { get; set; }
        public string? Specialty { get; set; }
        public string? Phone { get; set; }
    }
}
