using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Host.AppCore.Request.Voucher;
using PTS.Host.Controllers;
namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : PTSBaseController
    {
        private readonly IProductDetailRepository _repository;
        private readonly ResponseDto _reponse;
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductDetailController(IProductDetailRepository repository, IConfiguration config, IMediator mediator, IMapper mapper)
        {
            _repository = repository;
            _reponse = new ResponseDto();
            _config = config;
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetAllPDD")]

        public async Task<IActionResult> GetAllPDD()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            _reponse.Result = await _repository.GetById(id);
            _reponse.Count = 1;
            return Ok(_reponse);
        }
        [AllowAnonymous]
        [HttpGet("PGetProductDetail")]
        public async Task<IActionResult> PGetProductDetail(int? getNumber, string? codeProductDetail, int? status, string? search, decimal? from, decimal? to, string? sortBy, int? page,string? productType,string? hangsx, string? ram, string? CPU, string? cardVGA)
        {
            
            var listProductDetail = await _repository.PGetProductDetail(getNumber, codeProductDetail, status, search, from, to, sortBy, page, productType, hangsx, ram,CPU,cardVGA);
            _reponse.Result = listProductDetail;
            _reponse.Count = listProductDetail.ToList().Count;
            return Ok(_reponse);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto objDto)
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

        //[HttpPut("UpdateProductDetail")]
        //public async Task<IActionResult> UpdateProductDetail(ProductDetail obj)
        //{
        //    string apiKey = _config.GetSection("ApiKey").Value;
        //    if (apiKey == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
        //    if (keyDomain != apiKey.ToLower())
        //    {
        //        return Unauthorized();
        //    }
        //    if (await _repository.Update(obj))
        //    {
        //        _reponse.Result = obj;
        //        return Ok(_reponse);
        //    }
        //    _reponse.Result = null;
        //    _reponse.IsSuccess = false;
        //    _reponse.Message = "Thất bại";
        //    return BadRequest(_reponse);
        //}
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProductDetail(int id)
        {
            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            if (await _repository.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");

        }

        //[HttpGet("ProductDetailById")]
        //public async Task<IActionResult> ProductDetailById(Guid guid)
        //{

        //    string apiKey = _config.GetSection("ApiKey").Value;
        //    if (apiKey == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
        //    if (keyDomain != apiKey.ToLower())
        //    {
        //        return Unauthorized();
        //    }
        //    _reponse.Result = await _repository.GetById(guid);
        //    return Ok(await _repository.GetById(guid));
        //}

    }
}
