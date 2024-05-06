 using MediatR;
using PTS.Core.Dto;
using PTS.Core.Entities;
using PTS.Core.Repositories;
using PTS.Core.Services;

namespace PTS.Host.AppCore.Request.Cart
{
    public class CreateOrUpdateCartQuery : IRequest<ServiceResponse>
    {
        public string? Username { get; set; }
        public int IdProductDetail { get; set; }
    }
    public class CreateOrUpdateCartHandler : IRequestHandler<CreateOrUpdateCartQuery, ServiceResponse>
    {
        private readonly ICartService _service;
        public CreateOrUpdateCartHandler(ICartService service)
        {
            _service = service;
        }
        public async Task<ServiceResponse> Handle(CreateOrUpdateCartQuery request, CancellationToken cancellationToken)
        {
            if (request.Username != null)
            {
                return await _service.AddCart(request.Username, request.IdProductDetail);
            }
            else
            {
                return await _service.AddCart(request.Username, request.IdProductDetail);
            }


        }
    }
}
