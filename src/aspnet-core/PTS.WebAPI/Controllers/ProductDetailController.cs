using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Shared.Dto;
using PTS.Application.Dto;
using PTS.Domain.Entities;
using PTS.Core.Repositories;
using PTS.Host.AppCore.Request.Voucher;
using PTS.Host.Controllers;
using PTS.Host.Request.Voucher;
using IC.Application.Features.PhapDienDocs.Fields.Queries;
namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : BaseController
    {
        private readonly IProductDetailRepository _repository;
        private readonly ResponseDto _reponse;
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductDetailController(IProductDetailRepository repository, IConfiguration config, IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _reponse = new ResponseDto();
            _config = config;
            _mediator = mediator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetListAsync")]
        public async Task<IActionResult> GetListAsync()
        {
            return Ok(await _unitOfWork._productDetailRepository.GetListAsync());
        }
        [HttpPost("GetPagedAsync")]
        public async Task<IActionResult> GetPagedAsync(PagedRequestDto request)
        {
            return Ok(await _unitOfWork._productDetailRepository.GetPagedAsync(request));
        }
		[HttpPost("GetPagedq")]
		public async Task<IActionResult> GetPaged(ProductDetailGetPageQuery request)
		{
			var vouchers = await _mediator.Send(request);
			return Ok(vouchers);
		}
		[AllowAnonymous]
        [HttpPost("PublicGetList")]
        public async Task<IActionResult> PublicGetList(GetProductDetailRequest request)
        {
            return Ok(await _unitOfWork._productDetailRepository.PublicGetList(request));
        }
        [AllowAnonymous]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            _reponse.Result = await _unitOfWork._productDetailRepository.GetById(id);
            return Ok(_reponse);
        }
        [AllowAnonymous]
        [HttpGet("PGetProductDetail")]
        public async Task<IActionResult> PGetProductDetail(int? getNumber, string? codeProductDetail, int? status, string? search, decimal? from, decimal? to, string? sortBy, int? page,string? productType,string? hangsx, string? ram, string? CPU, string? cardVGA)
        {
            
            var listProductDetail = await _repository.PGetProductDetail(getNumber, codeProductDetail, status, search, from, to, sortBy, page, productType, hangsx, ram,CPU,cardVGA);
            _reponse.Result = listProductDetail;
            return Ok(_reponse);
        }
        [HttpPost("CreateOrUpdateAsync")]
        public async Task<IActionResult> CreateOrUpdateAsync(CreateProductDetailDto objDto)
        {
            var obj = _mapper.Map<ProductDetailEntity>(objDto);
            CreateOrUpdateProductDetailQuery query = new CreateOrUpdateProductDetailQuery();
            query.ProductDetailEntity = obj;
            return Ok(await _mediator.Send(query));
        }
        [HttpPost("CreateMany")]
        public async Task<IActionResult> CreateMany(List<ProductDetailEntity> list)
        {
          
            return BadRequest("Lỗi");
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProductDetail(int id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
