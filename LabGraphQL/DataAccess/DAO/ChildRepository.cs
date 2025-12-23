using LabGraphQL.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabGraphQL.DataAccess.DAO
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
        //сформировать личную карточку ребенка;
        public Child GetChildById(int id)
        {
            var child = _context.Children.Where(e=>e.ChildId == id). FirstOrDefault();
            if(child != null) return child;
            return null!;
        }
        public async Task<Child> CreateChild(Child chil)
        {
            await _context.Children.AddAsync(chil);
            await _context.SaveChangesAsync();
            return chil;
        }
        public async Task<Child> EditChild(Child child)
        {
            try
            {
                var childToUpdate = GetChildById(child.ChildId);
                if (childToUpdate == null) return null!;
                childToUpdate.Name = child.Name;
                childToUpdate.BirhDate = child.BirhDate;
                childToUpdate.ParentId = child.ParentId;
                await _context.SaveChangesAsync();
                return childToUpdate;
            }
            catch (Exception) { throw; }
        }
        public async Task<Child> DeleteChild(int id)
        {
            var childDel = await _context.Children.FindAsync(id);
            if (childDel == null) return null!;
            _context.Children.Remove(childDel);
            await _context.SaveChangesAsync();
            return childDel;
        }
    }
}
