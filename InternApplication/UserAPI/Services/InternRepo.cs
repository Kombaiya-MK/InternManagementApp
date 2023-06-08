using Microsoft.EntityFrameworkCore;
using UserAPI.Interfaces;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class InternRepo : IRepo<Intern, int>
    {
        private readonly UserContext _context;
        private readonly ILogger<Intern> _logger;

        public InternRepo(UserContext context , ILogger<Intern> logger) 
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Intern?> Add(Intern item)
        {
            _context.interns.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Intern?> Delete(int Key)
        {
            var item = Get(Key);
            _context.interns.Remove(await item);
            await _context.SaveChangesAsync();
            return await item;
        }

        public async Task<Intern?> Get(int Key)
        {
            var intern = await _context.interns.FirstOrDefaultAsync(i => i.Id==Key);
            return intern;
        }

        public async Task<ICollection<Intern>?> GetAll()
        {
            var interns = await _context.interns.ToListAsync();
            if (interns.Count > 0)
                return interns;
            return null;
        }

        public async Task<Intern> Update(Intern item)
        {
            var intern = await Get(item.Id);
            if(intern != null)
            {
                intern.Age = item.Age;
                intern.User = item.User;
                intern.Email = item.Email;
                intern.Phone = item.Phone;
                intern.DateOfBirth = item.DateOfBirth;
                await _context.SaveChangesAsync();
            }
            return intern;
        }
    }
}
