using Faker;
using GraphQLProject.DataAccess.Entity;

namespace LabGraphQL.DataAccess.Data
{
    public class DataSeeder
    {
        public static void SeedData(SampleAppDbContext db)
        {
            if (!db.Teachers.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var teach = new Teacher
                    {
                        Name = Name.First(),
                        SurName = Name.Last(),
                        Phone = Faker.Phone.Number()
                    };
                    db.Teachers.Add(teach);
                    for (int j = 0; j < 5; j++)
                    {
                        var ser = Service{
                        ServiceName = Lorem.Sentence()
                                
                        }
                    }
                }
            }
        }
    }
}
