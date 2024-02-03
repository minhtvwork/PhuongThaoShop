using Microsoft.EntityFrameworkCore;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository
{
    public class ColorRepository : IColorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ColorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(ColorEntity obj)
        {
            var checkMa = await _dbContext.ColorEntity.AnyAsync(x => x.Ma == obj.Ma);
            if (obj == null || checkMa == true || obj.Ma == null || obj.Name == null)
            {
                return false;
            }
            try
            {
                await _dbContext.ColorEntity.AddAsync(obj);
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
            var color = await _dbContext.ColorEntity.FindAsync(id);
            if (color == null)
            {
                return false;
            }
            try
            {
                color.IsDeleted = false;
                _dbContext.ColorEntity.Update(color);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ColorEntity>> GetAllColors()
        {
            var list = await _dbContext.ColorEntity.ToListAsync();
            var listColor = list.Where(x => !x.IsDeleted).ToList();
            return listColor;
        }

        public async Task<ColorEntity> GetById(int id)
        {
            var result = await _dbContext.ColorEntity.FindAsync(id);
            return result;
        }

        public async Task<bool> Update(ColorEntity obj)
        {
            var color = await _dbContext.ColorEntity.FindAsync(obj.Id);
            if (color == null)
            {
                return false;
            }
            try
            {
                color.Name = obj.Name;
                color.Ma = obj.Ma;
                //color.TrangThai = obj.TrangThai;
                _dbContext.ColorEntity.Update(color);
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
