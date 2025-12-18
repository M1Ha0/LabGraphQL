using GraphQLProject.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.DataAccess.DAO
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
        public List<Parent> GetAllParentWithChild()
        {
            return _context.Parents.Include(d=>d.Childs).ToList();
        }
        public async Task<Parent> CreateParent(Parent parent)
        {
            await _context.Parents.AddAsync(parent);
            await _context.SaveChangesAsync();
            return parent;
        }
    }
}
