﻿using MediatR;
using PTS.Domain.Dto;
using PTS.Host.Service.IService;

namespace PTS.Host.AppCore.Request.Bill
{
    public class CreateOrUpdateBillQuery : IRequest<ResponseDto>
    {
       public RequestBillDto? RequestBillDto { get; set; }
    }
    public class CreateOrUpdateBillHandler : IRequestHandler<CreateOrUpdateBillQuery, ResponseDto>
    {
        private readonly IBillService _service;
        public CreateOrUpdateBillHandler(IBillService service)
        {
            _service = service;
        }
        public async Task<ResponseDto> Handle(CreateOrUpdateBillQuery request, CancellationToken cancellationToken)
        {
            return await _service.CreateBill(request.RequestBillDto);
        }
    }
}
