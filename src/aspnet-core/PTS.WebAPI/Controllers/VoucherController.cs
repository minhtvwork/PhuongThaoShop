
using AutoMapper;
using IC.Application.Features.PhapDienDocs.Fields.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MS.Infrastructure.AppCore.Request.Voucher;
using PTS.Application.Dto;
using PTS.Domain.Entities;
using PTS.Host.AppCore.Request.Voucher;
using PTS.Host.Request.Voucher;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VoucherController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

		//[HttpPost("GetPaged")]
		//public async Task<IActionResult> GetPaged(VoucherPagingListRequest request)
		// {
		//    var vouchers = await _mediator.Send(request);
		//    return Ok(vouchers);
		//}
		[HttpPost("GetPaged")]
		public async Task<IActionResult> GetPaged(VoucherGetPageQuery request)
		{
			var vouchers = await _mediator.Send(request);
			return Ok(vouchers);
		}
		[HttpPost("GetVoucherById")]
        public async Task<IActionResult> GetVoucherById(int id)
        {
          //  GetVoucherByIdRequest request = new GetVoucherByIdRequest();
          //  var vouchers = await _mediator.Send(request);
            return Ok();
        }
        [HttpPost("CreateOrUpdateVoucher")]
        public async Task<IActionResult> CreateOrUpdateVoucher(VoucherDto objDto)
        {
             var obj = _mapper.Map<VoucherEntity>(objDto);
            CreateOrUpdateVoucherQuery query = new CreateOrUpdateVoucherQuery();
            query.VoucherEntity = obj;
            var vouchers = await _mediator.Send(query);
            return Ok(vouchers);
        }
        [HttpPost("DeleteVoucher")]
        public async Task<IActionResult> DeleteVoucher(int id)
        {
            DeleteVoucherQuery query = new DeleteVoucherQuery();
            query.Id = id;
            return Ok(await _mediator.Send(query));
        }
    }
}
