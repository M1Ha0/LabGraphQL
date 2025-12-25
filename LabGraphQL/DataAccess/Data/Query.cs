using LabGraphQL.DataAccess.DAO;
using LabGraphQL.DataAccess.Entity;
using HotChocolate.Subscriptions;

namespace LabGraphQL.DataAccess.Data
{
    public class Query
    {
        public List<Parent> AllParentOnly([Service] ParentRepository parentRepository) => parentRepository.GetAllParentOnly();
        public List<Child> AllChildOnly([Service] ChildRepository childRepository) => childRepository.GetChild();
        public List<Child> AllChildWithParent([Service] ChildRepository childRepository) => childRepository.GetChildWithParent();
        //сформировать личную карточку ребенка;
        public async Task<Child> GetChildById([Service] ChildRepository childRepository, [Service] ITopicEventSender eventSender, int id)
        {
            Child child = childRepository.GetChildById(id);
            await eventSender.SendAsync("ReturnedChild", child);
            return child;
        }
        //выдать информацию обо всех услугах детского сада;
        public List<Service> AllServiceOnly([Service] ServicesRepository servicesRepository) => servicesRepository.GetServices();
        public async Task<Service> GetServicesById([Service] ServicesRepository servicesRepository, [Service] ITopicEventSender eventSender, int id)
        {
            Service service = servicesRepository.GetServicesById(id);
            await eventSender.SendAsync("ReturnedService", service);
            return service;
        }
        //рассчитать общую стоимость предоставленных услуг;
        public decimal TotalCost([Service] ServicesRepository servicesRepository) => servicesRepository.GetTotalCost();
        //рассчитать общую стоимость по заданной услуге.
        public async Task<decimal> GetTotalCostById([Service] ServicesRepository servicesRepository, [Service] ITopicEventSender eventSender, int id)
        {
            decimal service = servicesRepository.GetTotalCostById(id);
            await eventSender.SendAsync("ReturnedService", service);
            return service;
        }
        //вывести справку обо всех преподавателях;
        public List<Teacher> AllTeacherOnly([Service] TeacherRepository teacherRepository) => teacherRepository.GetAllTeacher();
        //сформировать личную карточку преподавателя;
        public async Task<Teacher> GetTeacherById([Service] TeacherRepository teacherRepository, [Service] ITopicEventSender eventSender, int id)
        {
            Teacher teach = teacherRepository.GetTeacherById(id);
            await eventSender.SendAsync("ReturnedChild", teach);
            return teach;
        }
        public List<Payment> AllPaymentOnly([Service] PaymentRepository paymentRepository) => paymentRepository.GetPayments();
        public async Task<Payment> GetPaymentById([Service] PaymentRepository paymentRepository, [Service] ITopicEventSender eventSender, int id)
        {
            Payment payment = paymentRepository.GetPaymentById(id);
            await eventSender.SendAsync("ReturnedPayment", payment);
            return payment;
        }
        //вывести список детей, потребляющих заданную услугу;
        public async Task<List<Child>> GetParentsByIdServices([Service] PaymentRepository paymentRepository, [Service] ITopicEventSender eventSender, int id)
        {
            List<Child> payment = paymentRepository.GetParentsByIdServices(id);
            await eventSender.SendAsync("ReturnedPayment", payment);
            return payment;
        }
        //для ребенка вывести все выполненные платежи;
        public async Task<decimal> GetChildDebt([Service] PaymentRepository paymentRepository, [Service] ITopicEventSender eventSender, int id)
        {
            decimal payment = paymentRepository.GetChildDebt(id);
            await eventSender.SendAsync("ReturnedPayment", payment);
            return payment;
        }
        //для ребенка вывести все задолженности по платежам;
        public async Task<decimal> GetChildAmount([Service] PaymentRepository paymentRepository, [Service] ITopicEventSender eventSender, int id)
        {
            decimal payment = paymentRepository.GetTotalAmountById(id);
            await eventSender.SendAsync("ReturnedPayment", payment);
            return payment;
        }
    }
}
