using MediatR;
using PTS.Application.Dto;
using PTS.Core.Repositories;
using PTS.Core.Services;

namespace PTS.Host.AppCore.Request.Bill
{
    public class GetListBillQuery : IRequest<ResponseDto>
    {
    }
    public class GetListBillHandler : IRequestHandler<GetListBillQuery, ResponseDto>
    {
        private readonly IBillRepository _repo;
        public GetListBillHandler(IBillRepository repo)
        {
            _repo = repo;
        }
        public async Task<ResponseDto> Handle(GetListBillQuery request, CancellationToken cancellationToken)
        {
            return new ResponseDto
            {
                Result = await _repo.GetAll(),
                IsSuccess = true,
                Code = 200,
                Message = ""
            };
        }
    }
}
