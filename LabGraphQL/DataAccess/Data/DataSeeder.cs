using Faker;
using LabGraphQL.DataAccess.Entity;

namespace LabGraphQL.DataAccess.Data
{
    public static class DataSeeder
    {
        public static void SeedData(SampleAppDbContext db)
        {
            if (db.Parents.Any())
                return;

            var random = new Random();

            // ---------- Teachers + Services ----------
            var teachers = new List<Teacher>();

            for (int i = 0; i < 5; i++)
            {
                var teacher = new Teacher
                {
                    Name = Name.First(),
                    SurName = Name.Last(),
                    Phone = Phone.Number()
                };

                db.Teachers.Add(teacher);
                teachers.Add(teacher);

                for (int j = 0; j < 3; j++)
                {
                    var service = new Service
                    {
                        ServiceName = Lorem.Sentence(3),
                        Price = random.Next(1000, 5000),
                        Teacher = teacher
                    };

                    db.Services.Add(service);
                }
            }

            // ---------- Parents + Childs ----------
            var parents = new List<Parent>();

            for (int i = 0; i < 5; i++)
            {
                var parent = new Parent
                {
                    Name = Name.First(),
                    SurName = Name.Last(),
                    Phone = Phone.Number(),
                    Childs = new List<Child>(),
                    Payments = new List<Payment>()
                };

                db.Parents.Add(parent);
                parents.Add(parent);

                for (int j = 0; j < random.Next(1, 4); j++)
                {
                    var child = new Child
                    {
                        Name = Name.First(),
                        BirhDate = DateOnly.FromDateTime(
                            DateTime.Now.AddYears(-random.Next(3, 12))
                        ),
                        Parent = parent
                    };

                    db.Children.Add(child);
                }
            }

            db.SaveChanges();

            // ---------- Payments ----------
            var services = db.Services.ToList();

            foreach (var parent in parents)
            {
                for (int i = 0; i < random.Next(1, 4); i++)
                {
                    var service = services[random.Next(services.Count)];

                    var payment = new Payment
                    {
                        PaymentDate = DateOnly.FromDateTime(
                            DateTime.Now.AddDays(-random.Next(1, 60))
                        ),
                        Amount = service.Price,
                        ParentId = parent.ParentId,
                        ServicesId = service.ServiceId
                    };

                    db.Payments.Add(payment);
                }
            }

            db.SaveChanges();
        }
    }
}