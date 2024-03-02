using MediatR;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.EntityFrameworkCore.Repository.IRepository;

namespace PTS.Host.AppCore.Request.Voucher
{
    public class CreateOrUpdateVoucherQuery : IRequest<ServiceResponse>
    {
        public VoucherEntity? VoucherEntity { get; set; }
    }
    public class CreateOrUpdateVoucherHandler : IRequestHandler<CreateOrUpdateVoucherQuery, ServiceResponse>
    {
        private readonly IVoucherRepository _repository;
        public CreateOrUpdateVoucherHandler(IVoucherRepository repository)
        {
            _repository = repository;
        }
        public async Task<ServiceResponse> Handle(CreateOrUpdateVoucherQuery request, CancellationToken cancellationToken)
        {
            if (request.VoucherEntity.Id > 0)
            {
                //if (await _repository.Update(request.VoucherEntity))
                //{
                //    return new ServiceResponse(true, "Cập nhật thành công");
                  
                //} 
                return new ServiceResponse(false, "Cập nhật hất bại");
            }
            else
            {
                if(await _repository.Create(request.VoucherEntity))
                      return new ServiceResponse(true, "Thêm thành công");
                return new ServiceResponse(false, "Thêm thất bại");
            }


        }
    }
}
