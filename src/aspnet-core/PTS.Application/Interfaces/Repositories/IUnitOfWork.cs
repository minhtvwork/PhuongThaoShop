using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        //  IAllRepository<T> AllRepository<T>() where T : class;
        IProductDetailRepository _productDetailRepository { get; }
        ISerialRepository _serialRepository { get; }
        IVoucherRepository _voucherRepository { get; }
        //	IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
        IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
        Task<int> Save(CancellationToken cancellationToken);

        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);

        Task Rollback();
        Task ChangeTrackerClear();
    }
}
