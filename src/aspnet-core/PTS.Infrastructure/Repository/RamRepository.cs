using Microsoft.EntityFrameworkCore;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Data;

namespace PTS.EntityFrameworkCore.Repository
{
    public class RamRepository : IRamRepository
    {
        private readonly ApplicationDbContext _context;
        public RamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(RamEntity obj)
        {
            var checkMa = await _context.RamEntity.AnyAsync(x => x.Ma == obj.Ma);// tìm mã, trả về true nếu đã có, false nếu chưa có
            if (obj == null || checkMa == true)
            {
                return false;
            }
            try
            {
                await _context.RamEntity.AddAsync(obj);
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
            var ram = await _context.RamEntity.FindAsync(id);
            if (ram == null)
            {
                return false;
            }
            try
            {
                ram.IsDeleted = true;
                _context.RamEntity.Update(ram);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<RamEntity>> GetAllRams()
        {
            var list = await _context.RamEntity.ToListAsync();// lấy tất cả ram
            var listRam = list.Where(x => !x.IsDeleted).ToList();// lấy tất cả ram với điều kiện trạng thái khác 0
            return listRam;
        }

        public async Task<RamEntity> GetById(int id)
        {
            var result = await _context.RamEntity.FindAsync(id);
            return result;
        }

        public async Task<bool> Update(RamEntity obj)
        {
           
            var ram = await _context.RamEntity.FindAsync(obj.Id);
            if (ram == null)
            {
                return false;
            }
            try
            {
                ram.Ma = obj.Ma;
                ram.ThongSo = obj.ThongSo;
                //ram.TrangThai = obj.TrangThai;
                _context.RamEntity.Update(ram);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
