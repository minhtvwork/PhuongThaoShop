using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Host.AppCore.Request.Voucher;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VoucherController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Gửi một yêu cầu (query) đến handler tương ứng để lấy dữ liệu
            var vouchers = await _mediator.Send(new PagingListVoucherQuery());

            // Trả về dữ liệu
            return Ok(vouchers);
        }
        [HttpPost]
        public async Task<IActionResult> Create(VoucherDto objDto)
        {
             var obj = _mapper.Map<VoucherEntity>(objDto);
            CreateOrUpdateVoucherQuery query = new CreateOrUpdateVoucherQuery();
            query.VoucherEntity = obj;
            // Gửi một yêu cầu (query) đến handler tương ứng để lấy dữ liệu
            var vouchers = await _mediator.Send(query);

            // Trả về dữ liệu
            return Ok(vouchers);
        }
    }
}
