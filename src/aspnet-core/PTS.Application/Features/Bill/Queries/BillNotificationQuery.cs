using AutoMapper;
using AutoMapper.QueryableExtensions;
using PTS.Application.DTOs;
using PTS.Application.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using PTS.Application.Features.Bill.DTOs;
using PTS.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace PTS.Application.Features.Bill.Queries
{
    public record BillNotificationQuery : BaseGetPageQuery, IRequest<BillNotificeDto>
    {
    }
    internal class BillNotificationQueryHandler : IRequestHandler<BillNotificationQuery, BillNotificeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
        public BillNotificationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserEntity> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<BillNotificeDto> Handle(BillNotificationQuery queryInput, CancellationToken cancellationToken)
        {
            var listUser = _userManager.Users.AsNoTracking().ToList();
            var query = from listObj in _unitOfWork.Repository<BillEntity>().Entities.Where(x => x.Status != (int)StatusEnum.Delete).AsNoTracking() select listObj;
            var resultVar = new BillNotificeDto();
            resultVar.TotalStatus2 = query.Count(x => x.Status == 2);
            //resultVar.TotalStatus3 = query2.Count(x => x.Status == 3);
            //resultVar.TotalStatus4 = query2.Count(x => x.Status == 4);
            //resultVar.TotalStatus5 = query2.Count(x => x.Status == 5);
            //resultVar.TotalStatus6 = query2.Count(x => x.Status == 6);
            //resultVar.TotalStatus7 = query2.Count(x => x.Status == 7);
            //resultVar.TotalStatus8 = query2.Count(x => x.Status == 8);

            return resultVar;
        }
    }
}
