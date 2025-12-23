using LabGraphQL.DataAccess.DAO;
using LabGraphQL.DataAccess.Entity;
using HotChocolate.Subscriptions;

namespace LabGraphQL.DataAccess.Data
{
    public class Query
    {
        public List<Parent> AllParentOnly([Service] ParentRepository parentRepository) => parentRepository.GetAllParentOnly();
        public List<Child> AllChildOnly([Service] ChildRepository childRepository) => childRepository.GetChild();

        public List<Employee> AllEmployeeWithDepartment([Service] EmployeeRepository employeeRepository) => employeeRepository.GetEmployeeWithDepartment();

        public async Task<Employee> GetEmployerById([Service] EmployeeRepository employeeRepository, [Service] ITopicEventSender eventSender,int id)
        {
            Employee emp=employeeRepository.GetEmployeeById(id);
            await eventSender.SendAsync("ReturnedEmployee", emp);
            return emp;
        }
        public List<Department> AllDepartmentOnly([Service] DepartmentRepository departmentRepository) => departmentRepository.GetAllDepartmentOnly();

        public List<Department> AllDepartmentWithEmployee([Service] DepartmentRepository departmentRepository)=>departmentRepository.GetAllDepartmentsWithEmployee();
    }
}
