using FeedbackSystem.Data;
using FeedbackSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem.Repositories
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllWithUserAndCategoryAsync()
        {
            return await _context.Feedbacks
                .Include(f => f.User)
                .Include(f => f.Category)
                .ToListAsync();
        }

        public async Task<Feedback?> GetByIdWithUserAndCategoryAsync(int id)
        {
            return await _context.Feedbacks
                .Include(f => f.User)
                .Include(f => f.Category)
                .FirstOrDefaultAsync(f => f.FeedbackId == id);
        }
    }
}
