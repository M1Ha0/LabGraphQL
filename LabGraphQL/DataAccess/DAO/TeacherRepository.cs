using LabGraphQL.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabGraphQL.DataAccess.DAO
{
    public class TeacherRepository
    {
        private readonly SampleAppDbContext _context;
        public TeacherRepository(SampleAppDbContext context)
        {
            _context = context;
        }
        public List<Teacher> GetAllTeacher()
        {
            return _context.Teachers.ToList();
        }
        public Teacher GetTeacherById(int id)
        {
            var teacher = _context.Teachers.Where(e => e.TeacherId == id).FirstOrDefault();
            if (teacher != null) return teacher;
            return null!;
        }
        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}
