 using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Base.Application.Dto;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.EntityFrameworkCore.Repository.IRepository;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace PTS.Host.Request.Voucher
{
    public class VoucherPagingListRequest : PagedFullInputDto, IRequest<PagedResultDto<VoucherDto>>
    {
    }

    public class PagingListVoucherRequestHandler : IRequestHandler<VoucherPagingListRequest, PagedResultDto<VoucherDto>>
    {
        private readonly IVoucherRepository _repos;

        public PagingListVoucherRequestHandler(IVoucherRepository repos)
        {
            _repos = repos;
        }

        [Obsolete]
        public async Task<PagedResultDto<VoucherDto>> Handle(VoucherPagingListRequest input, CancellationToken cancellationToken)
        {
            var vouchers = await _repos.GetAll();
            var query = vouchers.Select(voucher => new VoucherDto
            {
                Id = voucher.Id,
                MaVoucher = voucher.MaVoucher,
                TenVoucher = voucher.TenVoucher,
                GiaTri = voucher.GiaTri,
                SoLuong = voucher.SoLuong,
                StarDay = voucher.StarDay,
                EndDay = voucher.EndDay,
                CreationTime = voucher.CreationTime,
                IsDeleted = voucher.IsDeleted,

            });
            if (!string.IsNullOrEmpty(input.Filter))
            {
                query = query.Where(u => u.TenVoucher.Contains(input.Filter) || u.MaVoucher == input.Filter);
            }
            var totalCount = query.Count();
            var items = query
                .OrderBy(voucher => voucher.MaVoucher)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToList();

            return new PagedResultDto<VoucherDto>(totalCount, items);
        }
    }
}

