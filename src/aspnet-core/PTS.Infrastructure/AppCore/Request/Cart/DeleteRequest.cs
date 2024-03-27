using MediatR;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.EntityFrameworkCore.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Infrastructure.AppCore.Request.Cart
{
    public class DeleteCartDetailQuery : IRequest<ServiceResponse>
    {
        public int Id {  get; set; }
    }
    public class DeleteCartDetailHandler : IRequestHandler<DeleteCartDetailQuery, ServiceResponse>
    {
        private readonly ICartDetailRepository _repository;
        public DeleteCartDetailHandler(ICartDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<ServiceResponse> Handle(DeleteCartDetailQuery request, CancellationToken cancellationToken)
        {
           
                if (await _repository.Delete(request.Id))
                    return new ServiceResponse(true, "Xóa thành công");
                return new ServiceResponse(false, "Xóa thất bại");
         
        }
    }
}
