using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Host.AppCore.Request.Cart;
using PTS.Host.AppCore.Request;
using PTS.Host.Service.IService;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using MS.Infrastructure.AppCore.Request.Cart;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : PTSBaseController
    {
        //private readonly ICartService _cartService;
        //private readonly ICartDetailRepository _cartDetailRepository;
        //private readonly ICartRepository _cartRepository;
        //private readonly IUserRepository _userRepository;
        //private readonly ResponseDto _reponse;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CartController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [AllowAnonymous]// For client
        [HttpPost("GetCartByUser")]
        public async Task<IActionResult> GetCartByUser(string username)
        {
            GetCartByUserQuery query = new GetCartByUserQuery();
            query.Username = username;
            return Ok(await _mediator.Send(query));
        }
        [AllowAnonymous]// For client
        [HttpDelete("DeleteCartDetail")]
        public async Task<IActionResult> DeleteCartDetail(int Id)
        {
            DeleteCartDetailQuery query = new DeleteCartDetailQuery();
            query.Id = Id;
            return Ok(await _mediator.Send(query));
        }
        [HttpPost("AddToCart")]
        public async Task<ServiceResponse> AddToCart(CreateOrUpdateCartQuery query)
        {
            return await _mediator.Send(query);
        }

        //public CartController(ICartService cartService, ICartDetailRepository cartDetailRepository, ICartRepository cartRepository, IUserRepository userRepository)
        //{
        //    _cartService = cartService;
        //    _cartDetailRepository = cartDetailRepository;
        //    _cartRepository = cartRepository;
        //    _userRepository = userRepository;
        //    _reponse = new ResponseDto();
        //}
        //[AllowAnonymous]// For admin
        //[HttpGet("GetListCarts")]
        //public async Task<IActionResult> GetListCarts()
        //{
        //    var reponse = await _cartService.GetListCarts();
        //    if (reponse.IsSuccess)
        //    {
        //        return Ok(reponse);
        //    }
        //    else
        //    {
        //        return BadRequest(reponse);
        //    }
        //}
        //[AllowAnonymous]// For admin
        //[HttpGet("GetCartById")]
        //public async Task<IActionResult> GetCartById(int id)
        //{
        //    var username = User.Identity.Name;
        //    var reponse = await _cartService.GetCartById(id);
        //    if (reponse.IsSuccess)
        //    {
        //        return Ok(reponse);
        //    }
        //    else
        //    {
        //        return BadRequest(reponse);
        //    }

        //}
        //[AllowAnonymous]// For client
        //[HttpPut("CongQuantity")]
        //public async Task<IActionResult> CongQuantityCartDetail(int idCartDetail)
        //{
        //    var reponse = await _cartService.CongQuantityCartDetail(idCartDetail);
        //    if (reponse.IsSuccess)
        //    {
        //        return Ok(reponse);
        //    }
        //    else
        //    {
        //        return BadRequest(reponse);
        //    }
        //}
        //[AllowAnonymous]
        //[HttpPut("TruQuantityCartDetail")]
        //public async Task<IActionResult> TruQuantityCartDetail(int idCartDetail)
        //{
        //    var reponse = await _cartService.TruQuantityCartDetail(idCartDetail);
        //    if (reponse.IsSuccess)
        //    {
        //        return Ok(reponse);
        //    }
        //    else
        //    {
        //        return BadRequest(reponse);
        //    }
        //}
        //[AllowAnonymous]
        //[HttpDelete("Delete")]
        //public async Task<IActionResult> Delete(string username)
        //{
        //    var userId = _userRepository.GetAllUsers().Result.FirstOrDefault(x => x.Username == username).Id;

        //    if (await _cartRepository.Delete(userId))
        //        return Ok();
        //    return BadRequest();

        //}
    }
}
