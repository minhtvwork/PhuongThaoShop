﻿using AutoMapper;
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
        [HttpPost("UpdateQuantity")]
        public async Task<ServiceResponse> UpdateQuantity(UpdateQuantityCartItemQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
