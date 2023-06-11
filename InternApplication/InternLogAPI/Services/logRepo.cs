using InternLogAPI.Interfaces;
using InternLogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InternLogAPI.Services
{
    public class logRepo : IRepo<Log, int>
    {
        private readonly logContext _context;
        private readonly ILogger<logRepo> _logger;

        public logRepo(logContext context, ILogger<logRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Log?> Add(Log item)
        {
            try
            {
                _context.logs.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Log?> Delete(int key)
        {
            var log = await Get(key);
            if (log != null)
            {
                _context.logs.Remove(log);
                await _context.SaveChangesAsync();
                return log;
            }
            return null;
        }

        public async Task<Log?> Get(int key)
        {
            var log = await _context.logs.FirstOrDefaultAsync(x => x.logId == key);
            return log;
        }

        public async Task<ICollection<Log>> GetAll()
        {
            var logs = await _context.logs.ToListAsync();
            return logs;
        }
    }
}
