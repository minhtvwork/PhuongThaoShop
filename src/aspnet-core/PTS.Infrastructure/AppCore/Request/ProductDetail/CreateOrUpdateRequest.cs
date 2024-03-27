using MediatR;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.EntityFrameworkCore.Repository.IRepository;

namespace PTS.Host.AppCore.Request.Voucher
{
    public class CreateOrUpdateProductDetailQuery : IRequest<ServiceResponse>
    {
        public ProductDetailEntity? ProductDetailEntity { get; set; }
    }
    public class CreateOrUpdateProductDetailHandler : IRequestHandler<CreateOrUpdateProductDetailQuery, ServiceResponse>
    {
        private readonly IProductDetailRepository _repository;
        public CreateOrUpdateProductDetailHandler(IProductDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<ServiceResponse> Handle(CreateOrUpdateProductDetailQuery request, CancellationToken cancellationToken)
        {
            if (request.ProductDetailEntity.Id > 0)
            {
                if (await _repository.Update(request.ProductDetailEntity))
                {
                    return new ServiceResponse(true, "Cập nhật thành công");

                }
                return new ServiceResponse(false, "Cập nhật hất bại");
            }
            else
            {
                if(await _repository.Create(request.ProductDetailEntity))
                      return new ServiceResponse(true, "Thêm thành công");
                return new ServiceResponse(false, "Thêm thất bại");
            }


        }
    }
}
