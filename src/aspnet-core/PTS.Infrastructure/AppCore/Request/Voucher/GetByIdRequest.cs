//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using PTS.Domain.Entities;
//using PTS.Data;
//using PTS.EntityFrameworkCore.Repository.IRepository;
//using PTS.Domain.Dto;
//using PTS.Host.Service.IService;

//namespace PTS.Host.AppCore.Request.Voucher
//{
//    public class GetVoucherByIdQuery : IRequest<ResponseDto>
//    {
//       public int Id { get; set; }
//    }
//    public class GetVoucherByIdHandler : IRequestHandler<GetVoucherByIdQuery, ResponseDto>
//    {
//        private readonly IVoucherRepository _repo;
//        public GetVoucherByIdHandler(IVoucherRepository repo)
//        {
//            _repo = repo;
//        }
//        public async Task<ResponseDto> Handle(GetVoucherByIdQuery request, CancellationToken cancellationToken)
//        {
//            return await _repo
//        }
//    }
//}
