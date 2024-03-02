using Microsoft.EntityFrameworkCore;

using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Data;

namespace PTS.EntityFrameworkCore.Repository
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ManufacturerRepository(ApplicationDbContext applicationDb)
        {
            dbContext = applicationDb;
        }

        public async Task<ResponseDto> Create(ManufacturerEntity obj)
        {
            var checktt = await dbContext.ManufacturerEntity.AnyAsync(p => p.Name == obj.Name);
            if (obj == null || checktt == true)
            {
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = false,
                    Code = 400,
                    Message = "Trùng Mã",
                };
            }
            try
            {
                await dbContext.ManufacturerEntity.AddAsync(obj);
                await dbContext.SaveChangesAsync();
                return new ResponseDto
                {
                    Result = obj,
                    IsSuccess = true,
                    Code = 200,
                    Message = "Thêm thành công",
                }; 
            }
            catch (Exception)
            {
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = false,
                    Code = 500,
                    Message = "Lỗi Hệ Thống",
                };

            }
        }

        public async Task<bool> Delete(int id)
        {
            var manu = await dbContext.ManufacturerEntity.FindAsync(id);
            if (manu == null)
            {
                return false;
            }
            try
            {

                manu.Status = 0;
                dbContext.ManufacturerEntity.Update(manu);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ManufacturerEntity> GetById(int id)
        {
            var result = await dbContext.ManufacturerEntity.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<ManufacturerEntity>> GetAll()
        {
            var list = await dbContext.ManufacturerEntity.ToListAsync();
            var listx = list.Where(x => x.Status > 0).ToList();
            return listx;
        }

        public async Task<bool> Update(ManufacturerEntity obj)
        {
            var manu = await dbContext.ManufacturerEntity.FindAsync(obj.Id);
            if (manu == null)
            {
                return false;
            }
            try
            {
                manu.Name = obj.Name;
                manu.Status = obj.Status;
                dbContext.ManufacturerEntity.Update(manu);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
