using Microsoft.EntityFrameworkCore;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository
{
    public class HardDriveRepository : IHardDriveRepository
    {
        private readonly ApplicationDbContext _context;

        public HardDriveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(HardDriveEntity obj)
        {
            var checkMa = await _context.HardDriveEntity.AnyAsync(x => x.Ma == obj.Ma);
            if (obj == null || checkMa)
            {
                return false;
            }
            try
            {
                await _context.HardDriveEntity.AddAsync(obj);
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
            var hardDrive = await _context.HardDriveEntity.FindAsync(id);
            if (hardDrive == null)
            {
                return false;
            }
            try
            {
                hardDrive.IsDeleted = true;
                _context.HardDriveEntity.Update(hardDrive);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<HardDriveEntity>> GetAllHardDrives()
        {
            var list = await _context.HardDriveEntity.ToListAsync();
            var listHardDrives = list.Where(x => !x.IsDeleted).ToList();
            return listHardDrives;
        }

        public async Task<HardDriveEntity> GetById(int id)
        {
            var result = await _context.HardDriveEntity.FindAsync(id);
            return result;
        }

        public async Task<bool> Update(HardDriveEntity obj)
        {
            var hardDrive = await _context.HardDriveEntity.FindAsync(obj.Id);
            if (hardDrive == null)
            {
                return false;
            }
            try
            {
                hardDrive.ThongSo = obj.ThongSo;
                //hardDrive.TrangThai = obj.TrangThai;
                _context.HardDriveEntity.Update(hardDrive);
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
