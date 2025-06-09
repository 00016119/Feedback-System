using FeedbackSystem.Data;
using FeedbackSystem.Models;

namespace FeedbackSystem.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<User> Users { get; }
        public IRepository<Category> Categories { get; }
        public IRepository<Feedback> Feedbacks { get; }
        public IRepository<Role> Roles { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new Repository<User>(context);
            Categories = new Repository<Category>(context);
            Feedbacks = new Repository<Feedback>(context);
            Roles = new Repository<Role>(context);
        }

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
