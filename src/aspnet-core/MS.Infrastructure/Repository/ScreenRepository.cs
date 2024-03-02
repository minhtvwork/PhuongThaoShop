using Microsoft.EntityFrameworkCore;

using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Entities;
using PTS.Data;

namespace PTS.EntityFrameworkCore.Repository
{
    public class ScreenRepository : IScreenRepository
    {
        private readonly ApplicationDbContext _context;
        public ScreenRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(ScreenEntity obj)
        {
            var checkMa = await _context.ScreenEntity.AnyAsync(x => x.Ma == obj.Ma);// tìm mã, trả về true nếu đã có, false nếu chưa có
            if (obj == null || checkMa == true)
            {
                return false;
            }
            try
            {
                await _context.ScreenEntity.AddAsync(obj);
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
            var screen = await _context.ScreenEntity.FindAsync(id);
            if (screen == null)
            {
                return false;
            }
            try
            {
                screen.IsDeleted = true;
                _context.ScreenEntity.Update(screen);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ScreenEntity>> GetAll()
        {
            var list = await _context.ScreenEntity.ToListAsync();// lấy tất cả ram
            var listScreen = list.Where(x => !x.IsDeleted).ToList();// lấy tất cả ram với điều kiện trạng thái khác 0
            return listScreen;
        }

        public async Task<ScreenEntity> GetById(int id)
        {
            var result = await _context.ScreenEntity.FindAsync(id);
            return result;
        }

        public async Task<bool> Update(ScreenEntity obj)
        {
            var screen = await _context.ScreenEntity.FindAsync(obj.Id);
            if (screen == null)
            {
                return false;
            }
            try
            {
                screen.KichCo = obj.KichCo;
                screen.TanSo = obj.TanSo;
                screen.ChatLieu = obj.ChatLieu;
                //screen.TrangThai = obj.TrangThai;
                _context.ScreenEntity.Update(screen);
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
