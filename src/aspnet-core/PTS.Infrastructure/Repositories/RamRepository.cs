﻿using Microsoft.EntityFrameworkCore;
using PTS.Core.Repositories;
using PTS.Core.Dto;
using PTS.Core.Entities;
using PTS.Data;
using Abp.Application.Services.Dto;
using PTS.Shared.Dto;

namespace PTS.Infrastructure.Repositories
{
    public class RamRepository : IRamRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RamRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PagedResultDto<RamDto>> GetPagedAsync(PagedRequestDto request)
        {
            var query = _dbContext.RamEntity.Where(x => !x.IsDeleted);

            var totalCount = await query.CountAsync();

            var obj = await query.Skip(request.SkipCount)
                                    .Take(request.MaxResultCount)
                                    .ToListAsync();

            var objDto = obj.Select(ram => new RamDto
            {
                Id = ram.Id,
                Ma = ram.Ma,
                ThongSo = ram.ThongSo
            }).ToList();

            return new PagedResultDto<RamDto>(totalCount, objDto);
        }
        public async Task<bool> Create(RamEntity obj)
        {
            var check = await _dbContext.RamEntity.AnyAsync(x => x.Ma == obj.Ma);
            if (obj == null || check == true)
            {
                return false;
            }
            try
            {
                await _dbContext.RamEntity.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            var ram = await _dbContext.RamEntity.FindAsync(id);
            if (ram == null)
            {
                return false;
            }
            try
            {
                ram.IsDeleted = true;
                _dbContext.RamEntity.Update(ram);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<IEnumerable<RamEntity>> GetList()
        {
           return await _dbContext.RamEntity.Where(a=>!a.IsDeleted).ToListAsync();
        }

        public async Task<RamEntity> GetById(int id)
        {
            return await _dbContext.RamEntity.FindAsync(id);
        }

        public async Task<bool> Update(RamEntity obj)
        {
            var ram = await _dbContext.RamEntity.FindAsync(obj.Id);
            if (ram == null)
            {
                return false;
            }
            try
            {
                ram.Ma = obj.Ma;
                ram.ThongSo = obj.ThongSo;
                _dbContext.RamEntity.Update(ram);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}