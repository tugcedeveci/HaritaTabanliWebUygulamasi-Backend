using Microsoft.EntityFrameworkCore;
using project.Data_Access;
using project.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace project.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DoorDbContext _context;
        private bool disposed = false;

        public IRepository<Door> DoorRepository { get; }

        public UnitOfWork(DoorDbContext context)
        {
            _context = context;
            DoorRepository = new DoorRepository<Door>(context);
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                
                throw;
            }
            catch (DbUpdateException ex)
            {
                
                throw;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }
    }
}
