using FeedbackSystem.Models;

namespace FeedbackSystem.Repositories
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Task<IEnumerable<Feedback>> GetAllWithUserAndCategoryAsync();
        Task<Feedback?> GetByIdWithUserAndCategoryAsync(int id);
    }
}

