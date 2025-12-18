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
        public List<Service> GetServiceses()
        {
            return _context.Services.ToList();
        }
        public Service GetServicesById(int id)
        {
            var services = _context.Services.Include(e=>e.Payments).Where(e=>e.ServiceId == id). FirstOrDefault();
            if(services != null) return services;
            return null!;
        }
        public decimal GetTotalCost()
        {
            return _context.Services.Sum(p => p.Price);
        }
        public async Task<Service> CreateServices(Service servic)
        {
            await _context.Services.AddAsync(servic);
            await _context.SaveChangesAsync();
            return servic;
        }
    }
}
