using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.Serial.DTOs;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Enums;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.Serial.Queries
{
    public record SerialGetByCodeProductDetailQuery : IRequest<Result<List<SerialDto>>>
	{
		public string CodeProductDetail {  get; set; }	
    }
	internal class SerialGetByCodeProductDetailQueryHandler : IRequestHandler<SerialGetByCodeProductDetailQuery, Result<List<SerialDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public SerialGetByCodeProductDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
		public async Task<Result<List<SerialDto>>> Handle(SerialGetByCodeProductDetailQuery queryInput, CancellationToken cancellationToken)
		{
			var productId = _unitOfWork.Repository<ProductDetailEntity>().Entities
				.AsNoTracking().FirstOrDefault(x => x.Code == queryInput.CodeProductDetail).Id;

            var result = await _unitOfWork.Repository<SerialEntity>().Entities
				.AsNoTracking()
				.Where(x => x.Status != (int)StatusEnum.Delete && x.BillDetailEntityId == null && x.ProductDetailEntityId == productId)
				.ProjectTo<SerialDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
			return await Result<List<SerialDto>>.SuccessAsync(result);
		}
	}
}
