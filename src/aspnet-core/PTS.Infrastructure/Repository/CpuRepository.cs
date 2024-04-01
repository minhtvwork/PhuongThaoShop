using Microsoft.EntityFrameworkCore;
using PTS.Domain.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Data;

namespace PTS.EntityFrameworkCore.Repository
{
    public class CpuRepository : ICpuRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CpuRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(CpuEntity obj)
        {
            var checkMa = await _dbContext.CpuEntity.AnyAsync(x => x.Ma == obj.Ma);
            if (obj == null || checkMa == true)
            {
                return false;
            }
            try
            {
                await _dbContext.CpuEntity.AddAsync(obj);
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
            var ram = await _dbContext.CpuEntity.FindAsync(id);
            if (ram == null)
            {
                return false;
            }
            try
            {
                ram.IsDeleted = true;
                _dbContext.CpuEntity.Update(ram);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<CpuEntity>> GetAllCpuEntity()
        {
            var list = await _dbContext.CpuEntity.ToListAsync();
            var listCpu = list.Where(x => !x.IsDeleted).ToList();
            return listCpu;
        }

        public async Task<CpuEntity> GetById(int id)
        {
            var result = await _dbContext.CpuEntity.FindAsync(id);
            return result;
        }

        public async Task<bool> Update(CpuEntity obj)
        {
            var cpu = await _dbContext.CpuEntity.FindAsync(obj.Id);
            if (cpu == null)
            {
                return false;
            }
            try
            {
                cpu.Ten = obj.Ten;
                //cpu.TrangThai = obj.TrangThai;
                _dbContext.CpuEntity.Update(cpu);
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

