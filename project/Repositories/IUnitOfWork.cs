using project.Models;

namespace project.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Door> DoorRepository { get; }

        int SaveChanges();
    }
}
