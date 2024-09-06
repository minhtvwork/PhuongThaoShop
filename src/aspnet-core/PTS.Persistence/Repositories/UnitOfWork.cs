using Microsoft.EntityFrameworkCore;
using PTS.Data;
using PTS.Application.Interfaces.Repositories;
using PTS.Persistence.Repositories;
using PTS.Host.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

using PTS.Domain.Common;
using System.Collections;

namespace PTS.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
		private Hashtable _repositories;
		private bool _disposed;
        public IProductDetailRepository _productDetailRepository { get; }
        public ISerialRepository _serialRepository { get; }
        public IVoucherRepository _voucherRepository { get; }
        public IRoleRepository _roleRepository { get; }
        public UnitOfWork(
        ApplicationDbContext dbContext, IProductDetailRepository productDetailRepository,
        ISerialRepository serialRepository, IVoucherRepository voucherRepository, IRoleRepository roleRepository
        )
        {
            _dbContext = dbContext;
            _productDetailRepository = productDetailRepository;
            _serialRepository = serialRepository;
            _voucherRepository = voucherRepository;
            _roleRepository = roleRepository;

        }
        
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

		public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity
		{
			if (_repositories == null)
				_repositories = new Hashtable();

			var type = typeof(T).Name;

			if (!_repositories.ContainsKey(type))
			{
				var repositoryType = typeof(GenericRepository<>);

				var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

				_repositories.Add(type, repositoryInstance);
			}

			return (IGenericRepository<T>)_repositories[type];
		}

		public Task Rollback()
		{
			_dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
			return Task.CompletedTask;
		}

		public Task ChangeTrackerClear()
		{
			_dbContext.ChangeTracker.Clear();
			return Task.CompletedTask;
		}

		public async Task<int> Save(CancellationToken cancellationToken)
		{
			return await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
		{
			throw new NotImplementedException();
		}
	}
}
