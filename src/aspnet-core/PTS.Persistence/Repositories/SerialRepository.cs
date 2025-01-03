﻿using Microsoft.EntityFrameworkCore;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Data;
namespace PTS.Persistence.Repositories
{
    public class SerialRepository : ISerialRepository
    {
        private readonly ApplicationDbContext _context;
        public SerialRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(SerialEntity obj)
        {
            var checkMa = await _context.SerialEntity.AnyAsync(x => x.SerialNumber == obj.SerialNumber);
            if (obj == null || checkMa == true)
            {
              return false;
            }
            try
            {
                await _context.SerialEntity.AddAsync(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> CreateMany(List<SerialEntity> listObj)
        {
            foreach (var obj in listObj)
            {
                var check = await _context.SerialEntity.AnyAsync(x => x.SerialNumber == obj.SerialNumber);
                if (check == true)
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
            var obj = await _context.SerialEntity.FindAsync(id);
            if (obj == null)
            {
                return false;
            }
            try
            {
           //    obj.Status = 0
                _context.SerialEntity.Update(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<IEnumerable<SerialEntity>> GetList()
        {
         return await _context.SerialEntity.ToListAsync();
        }

        public async Task<bool> Update(SerialEntity obj)
        {
            var serial = await _context.SerialEntity.FindAsync(obj.Id);
            if (serial == null)
            {
               return true;
            }
            try
            {
                serial.SerialNumber = obj.SerialNumber;
                serial.BillDetailEntityId = obj.BillDetailEntityId;
                serial.ProductDetailEntityId = obj.ProductDetailEntityId;
                serial.Status = obj.Status;
                _context.SerialEntity.Update(serial);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<SerialEntity> GetById(int id)
        {
            return await _context.SerialEntity.FindAsync(id);
        }
        public async Task<SerialEntity> FindBySerialNumberAsync(string serialNumber)
        {
            return await _context.SerialEntity
                .FirstOrDefaultAsync(s => s.SerialNumber == serialNumber);
        }
    }
}
