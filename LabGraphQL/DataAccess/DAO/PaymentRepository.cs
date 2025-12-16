using GraphQLProject.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.DataAccess.DAO
{
    public class PaymentRepository
    {
        private readonly SampleAppDbContext _context;
        public PaymentRepository(SampleAppDbContext context)
        {
            _context = context;
        }
        public List<Payment> GetPayments()
        {
            return _context.Payments.ToList();
        }
        public Payment GetPaymentById(int id)
        {
            var payment = _context.Payments.Include(e=>e.Services).Where(e=>e.PaymentId == id). FirstOrDefault();
            if(payment != null) return payment;
            return null!;
        }
        public List<Payment> GetEmployeeWithDepartment()
        {
            return _context.Payments.Include(e => e.Services).ToList();
        }
        public async Task<Payment> CreateEmployee(Payment paym)
        {
            await _context.Payments.AddAsync(paym);
            await _context.SaveChangesAsync();
            return paym;
        }
    }
}
