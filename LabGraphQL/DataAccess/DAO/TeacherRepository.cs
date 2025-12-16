using GraphQLProject.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.DataAccess.DAO
{
    public class TeacherRepository
    {
        private readonly SampleAppDbContext _context;
        public TeacherRepository(SampleAppDbContext context)
        {
            _context = context;
        }
        public List<Teacher> GetAllTeacherOnly()
        {
            return _context.Teachers.ToList();
        }
        public List<Teacher> GetAllTeacherWithServices()
        {
            return _context.Teachers.Include(d => d.Serviceses).ToList();
        }
        public async Task<Teacher> CreateDepartment(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}
