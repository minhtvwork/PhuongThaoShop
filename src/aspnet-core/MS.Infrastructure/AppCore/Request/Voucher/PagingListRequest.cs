using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Domain.Entities;
using PTS.Data;
using PTS.EntityFrameworkCore.Repository.IRepository;

namespace PTS.Host.AppCore.Request.Voucher
{
    public class PagingListVoucherQuery : IRequest<List<VoucherEntity>>
    {

    }
    public class PagingListVoucherHandler : IRequestHandler<PagingListVoucherQuery, List<VoucherEntity>>
    {
        private readonly IVoucherRepository _repository;
        public PagingListVoucherHandler(IVoucherRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<VoucherEntity>> Handle(PagingListVoucherQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllVouchers(cancellationToken);
        }
    }
}
