using MediatR;
using PTS.Core.Dto;
using PTS.Core.Entities;
using PTS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Infrastructure.AppCore.Request.Voucher
{
    public class DeleteVoucherQuery : IRequest<ServiceResponse>
    {
        public int Id {  get; set; }
    }
    public class DeleteVoucherHandler : IRequestHandler<DeleteVoucherQuery, ServiceResponse>
    {
        private readonly IVoucherRepository _repository;
        public DeleteVoucherHandler(IVoucherRepository repository)
        {
            _repository = repository;
        }
        public async Task<ServiceResponse> Handle(DeleteVoucherQuery request, CancellationToken cancellationToken)
        {
           
                if (await _repository.Delete(request.Id))
                    return new ServiceResponse(true, "Xóa thành công");
                return new ServiceResponse(false, "Xóa thất bại");
         
        }
    }
}
