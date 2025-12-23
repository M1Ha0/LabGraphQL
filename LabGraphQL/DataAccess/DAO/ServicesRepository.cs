using LabGraphQL.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabGraphQL.DataAccess.DAO
{
    public class ServicesRepository
    {
        private readonly SampleAppDbContext _context;
        public ServicesRepository(SampleAppDbContext context)
        {
            _context = context;
        }
        //выдать информацию обо всех услугах детского сада;
        public List<Service> GetServices()
        {
            return _context.Services.ToList();
        }
        public Service GetServicesById(int id)
        {
            var services = _context.Services.Include(e=>e.Payments).Where(e=>e.ServiceId == id). FirstOrDefault();
            if(services != null) return services;
            return null!;
        }
        //рассчитать общую стоимость предоставленных услуг;
        public decimal GetTotalCost()
        {
            return _context.Services.Sum(p => p.Price);
        }
        //рассчитать общую стоимость по заданной услуге.
        public decimal GetTotalCostById(int id)
        {
            return _context.Services.Where(p=>p.ServiceId == id).Sum(p => p.Price);
        }
        public async Task<Service> CreateServices(Service servic)
        {
            await _context.Services.AddAsync(servic);
            await _context.SaveChangesAsync();
            return servic;
        }
    }
}
