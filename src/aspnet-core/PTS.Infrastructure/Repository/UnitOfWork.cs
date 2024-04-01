using Microsoft.EntityFrameworkCore;
using PTS.Data;
using PTS.Domain.IRepository;
using PTS.EntityFrameworkCore.Repository;
using PTS.Host.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed;
       public IColorRepository _colorRepository { get; }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _colorRepository = new ColorRepository(_dbContext);
        }
        //public IAllRepository<T> AllRepository<T>() where T : class
        //{
        //    return new AllRepository<T>(_dbContext);
        //}

        public Task BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    // Giải phóng các tài nguyên khác nếu cần
                }
                _disposed = true;
            }
        }

        public async Task RollbackAsync()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        public async Task<int> SaveChangesAsync()
        {
          return await _dbContext.SaveChangesAsync();

        }
    }
}
