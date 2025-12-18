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
            var payment = _context.Payments.Include(e=>e.Services).Where(e=>e.PaymentId == id).FirstOrDefault();
            if(payment != null) return payment;
            return null!;
        }
        public List<Child> GetParentsByIdServices(int id)
        {
            var query = from child in _context.Children
                        join parent in _context.Parents on child.ParentId equals parent.ParentId
                        join payment in _context.Payments on parent.ParentId equals payment.ParentId
                        where payment.ServicesId == id
                        select child;
            return query.ToList();
        }
        public List<Payment> GetPaymentsChild()
        {

        }
        public List<Payment> GetPaymentWithServices()
        {
            return _context.Payments.Include(e => e.Services).ToList();
        }
        public async Task<Payment> CreatePayment(Payment paym)
        {
            await _context.Payments.AddAsync(paym);
            await _context.SaveChangesAsync();
            return paym;
        }
    }
}
