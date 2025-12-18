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
            return _context.Children.ToList();
        }
        public Child GetChildById(int id)
        {
            var child = _context.Children.Include(e=>e.Parent).Where(e=>e.ChildId == id). FirstOrDefault();
            if(child != null) return child;
            return null!;
        }
        public async Task<Child> CreateChild(Child chil)
        {
            await _context.Children.AddAsync(chil);
            await _context.SaveChangesAsync();
            return chil;
        }
    }
}
