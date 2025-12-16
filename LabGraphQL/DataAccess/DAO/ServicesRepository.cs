using GraphQLProject.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.DataAccess.DAO
{
    public class ServicesRepository
    {
        private readonly SampleAppDbContext _context;
        public ServicesRepository(SampleAppDbContext context)
        {
            _context = context;
        }
        public List<Services> GetServiceses()
        {
            return _context.Services.ToList();
        }
        public Services GetServicesById(int id)
        {
            var services = _context.Services.Include(e=>e.Payments).Where(e=>e.ServicesId == id). FirstOrDefault();
            if(services != null) return services;
            return null!;
        }
        public List<Services> GetServicesWithPayments()
        {
            return _context.Services.Include(e => e.Payments).ToList();
        }
        public async Task<Services> CreateEmployee(Services servic)
        {
            await _context.Services.AddAsync(servic);
            await _context.SaveChangesAsync();
            return servic;
        }
    }
}
