using Microsoft.EntityFrameworkCore;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Data;

namespace PTS.EntityFrameworkCore.Repository
{
    public class ColorRepository : IColorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ColorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ColorEntity>> GetList()
        {
            return await _dbContext.ColorEntity.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<ColorEntity> GetById(int id)
        {
            return await _dbContext.ColorEntity.FindAsync(id);
        }
        public async Task<ServiceResponse> Create(ColorEntity obj)
        {
            var checkMa = await _dbContext.ColorEntity.AnyAsync(x => x.Ma == obj.Ma);
            if (obj == null || checkMa == true || obj.Ma == null || obj.Name == null)
            {
                return new ServiceResponse(false, "Thêm thất bại");
            }
            try
            {
                await _dbContext.ColorEntity.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return new ServiceResponse(true, "Thêm thành công");
            }
            catch (Exception)
            {
                return new ServiceResponse(false, "Thêm thất bại");
            }
        }
        public async Task<ServiceResponse> Update(ColorEntity obj)
        {
            var color = await _dbContext.ColorEntity.FindAsync(obj.Id);
            if (color == null)
            {
                return new ServiceResponse(false, "Cập nhật thất bại");
            }
            try
            {
                color.Name = obj.Name;
                color.Ma = obj.Ma;
                _dbContext.ColorEntity.Update(color);
                await _dbContext.SaveChangesAsync();
                return new ServiceResponse(true, "Cập nhật thành thành công");
            }
            catch (Exception)
            {
                return new ServiceResponse(true, "Cập nhật thất bại");
            }
        }
        public async Task<ServiceResponse> Delete(int id)
        {
            var color = await _dbContext.ColorEntity.FindAsync(id);
            if (color == null)
            {
                return new ServiceResponse(false, "Xóa thất bại");
            }
            try
            {
                color.IsDeleted = true;
                _dbContext.ColorEntity.Update(color);
                await _dbContext.SaveChangesAsync();
                return new ServiceResponse(true, "Xóa thành công");
            }
            catch (Exception e)
            {
                return new ServiceResponse(false, "Xóa thất bại:" + $"{e.Message}");
            }
        }
    }
}
