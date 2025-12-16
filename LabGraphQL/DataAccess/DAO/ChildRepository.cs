using GraphQLProject.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.DataAccess.DAO
{
    public class ChildRepository
    {
        private readonly SampleAppDbContext _context;
        public ChildRepository(SampleAppDbContext context)
        {
            _context = context;
        }
        public List<Child> GetChild()
        {
            return _context.Child.ToList();
        }
        public Child GetChildById(int id)
        {
            var child = _context.Child.Include(e=>e.Parent).Where(e=>e.ChildId == id). FirstOrDefault();
            if(child != null) return child;
            return null!;
        }
        public List<Child> GetChildWithParent()
        {
            return _context.Child.Include(e => e.Parent).ToList();

        }
        public async Task<Child> CreateEmployee(Child chil)
        {
            await _context.Child.AddAsync(chil);
            await _context.SaveChangesAsync();
            return chil;
        }
    }
}
