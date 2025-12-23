using LabGraphQL.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabGraphQL.DataAccess.DAO
{
    public class ParentRepository
    {
        private readonly SampleAppDbContext _context;
        public ParentRepository(SampleAppDbContext context)
        {
            _context = context;
        }
        public List<Parent> GetAllParentOnly()
        {
            return _context.Parents.ToList();
        }
        public Parent GetParentById(int id)
        {
            var parent = _context.Parents.Where(e => e.ParentId == id).FirstOrDefault();
            if (parent != null) return parent;
            return null!;
        }
        public async Task<Parent> CreateParent(Parent parent)
        {
            await _context.Parents.AddAsync(parent);
            await _context.SaveChangesAsync();
            return parent;
        }
    }
}
