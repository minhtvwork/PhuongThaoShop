using Microsoft.EntityFrameworkCore;

using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Data;

namespace PTS.EntityFrameworkCore.Repository
{
    public class SerialRepository : ISerialRepository
    {
        private readonly ApplicationDbContext _context;
        public SerialRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseDto> Create(SerialEntity obj)
        {
            var checkMa = await _context.SerialEntity.AnyAsync(x => x.SerialNumber == obj.SerialNumber);
            if (obj == null || checkMa == true)
            {
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = false,
                    Code = 400,
                    Message = "Trùng Serial",
                };
            }
            try
            {
                await _context.SerialEntity.AddAsync(obj);
                await _context.SaveChangesAsync();
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
        public async Task<bool> CreateMany(List<SerialEntity> listObj)
        {
            foreach (var obj in listObj)
            {
                var checkMa = await _context.SerialEntity.AnyAsync(x => x.SerialNumber == obj.SerialNumber);
                if (checkMa == true)
                {
                    return false;
                }
            }

            try
            {
                await _context.SerialEntity.AddRangeAsync(listObj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            var Serial = await _context.SerialEntity.FindAsync(id);
            if (Serial == null)
            {
                return false;
            }
            try
            {
                Serial.Status = 0;
                _context.SerialEntity.Update(Serial);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SerialEntity>> GetAll()
        {
            var list = await _context.SerialEntity.ToListAsync();
            var listSerial = list.Where(x => x.Status > 0).ToList();
            return listSerial;
        }

        public async Task<ResponseDto> Update(SerialEntity obj)
        {
            var Serial = await _context.SerialEntity.FindAsync(obj.Id);
            if (Serial == null)
            {
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = false,
                    Code = 400,
                    Message = "Không Tìm Thấy Serial",
                };
            }
            try
            {
                Serial.SerialNumber = obj.SerialNumber;
                //Serial.Status = 1;
                Serial.BillDetailEntityId = obj.BillDetailEntityId;
                Serial.ProductDetailEntityId = obj.ProductDetailEntityId;
                _context.SerialEntity.Update(Serial);
                await _context.SaveChangesAsync();
                return new ResponseDto
                {
                    Result = obj,
                    IsSuccess = true,
                    Code = 200,
                    Message = "Sửa thành công",
                };
            }
            catch (Exception)
            {
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = false,
                    Code = 500,
                    Message = "Lỗi hệ thống",
                };
            }
        }
    }
}
