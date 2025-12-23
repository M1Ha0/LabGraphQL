using LabGraphQL.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabGraphQL.DataAccess.DAO
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
        //вывести список детей, потребляющих заданную услугу;
        public List<Child> GetParentsByIdServices(int id)
        {
            var query = from child in _context.Children
                        join parent in _context.Parents on child.ParentId equals parent.ParentId
                        join payment in _context.Payments on parent.ParentId equals payment.ParentId
                        where payment.ServicesId == id
                        select child;
            return query.ToList();
        }
        //для ребенка вывести все выполненные платежи;
        public decimal GetChildDebt(int childId)
        {
 
            var servicesCost = _context.Payments
                .Include(p => p.Services)
                .Where(p => p.Parent.Childs.Any(c => c.ChildId == childId))
                .Select(p => p.Services.Price)
                .Sum();
          
            var paid = _context.Payments
                .Where(p => p.Parent.Childs.Any(c => c.ChildId == childId))
                .Sum(p => p.Amount);
            decimal childDebt = servicesCost - paid;
            return childDebt;
        }
        //для ребенка вывести все задолженности по платежам;
        public decimal GetTotalAmountById(int id)
        {
            return _context.Payments.Where(p => p.ParentId == id).Sum(p => p.Amount);
        }
        public async Task<Payment> CreatePayment(Payment paym)
        {
            await _context.Payments.AddAsync(paym);
            await _context.SaveChangesAsync();
            return paym;
        }
    }
}
