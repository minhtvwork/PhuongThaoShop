using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Domain.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        //  IAllRepository<T> AllRepository<T>() where T : class;
        IColorRepository _colorRepository { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
