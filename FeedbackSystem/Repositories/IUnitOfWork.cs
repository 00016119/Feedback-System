using FeedbackSystem.Models;

namespace FeedbackSystem.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Category> Categories { get; }
        IRepository<Feedback> Feedbacks { get; }
        IRepository<Role> Roles { get; }
        Task<int> CommitAsync();
    }
}
