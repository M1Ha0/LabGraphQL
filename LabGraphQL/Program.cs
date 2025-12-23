using LabGraphQL.DataAccess.DAO;
using LabGraphQL.DataAccess.Data;
using LabGraphQL.DataAccess.Entity;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddDbContext<SampleAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer().AddQueryType<Query>().
    AddMutationType<Mutation>().AddSubscriptionType<Subscription>().AddInMemorySubscriptions();
builder.Services.AddScoped<ChildRepository, ChildRepository>();
builder.Services.AddScoped<ParentRepository, ParentRepository>();
builder.Services.AddScoped<TeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ServicesRepository, ServicesRepository>();
builder.Services.AddScoped<PaymentRepository, PaymentRepository>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(cors => cors
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials()
);
app.UseWebSockets();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<SampleAppDbContext>();
    DataSeeder.SeedData(db);
}
app.MapGraphQL("/graphql");
app.Run();