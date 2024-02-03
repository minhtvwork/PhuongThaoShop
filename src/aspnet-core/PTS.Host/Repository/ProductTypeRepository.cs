using Microsoft.EntityFrameworkCore;

using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(ProductTypeEntity obj)
        {
            var check = await _context.ProductTypeEntity.AnyAsync(x => x.Name == obj.Name);
            if (check || obj == null)
            {
                return false;
            }
            try
            {
                await _context.ProductTypeEntity.AddAsync(obj);
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
            var productType = await _context.ProductTypeEntity.FindAsync(id);
            if (productType == null)
            {
                return false;
            }
            try
            {
                productType.Status = 0;
                _context.ProductTypeEntity.Update(productType);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductTypeEntity>> GetAll()
        {
            var listAll = await _context.ProductTypeEntity.ToListAsync();
            var list = listAll.Where(x => x.Status > 0).ToList();
            return list;
        }

        public async Task<ProductTypeEntity> GetById(int id)
        {
            var result = await _context.ProductTypeEntity.FindAsync(id);
            return result;
        }

        public async Task<bool> Update(ProductTypeEntity obj)
        {
            obj.Name = obj.Name.TrimEnd();
            var productType = await _context.ProductTypeEntity.FindAsync(obj.Id);
            if (obj == null || productType == null)
            {
                return false;
            }
            try
            {
                productType.Name = obj.Name;
                productType.Status = obj.Status;
                _context.ProductTypeEntity.Update(productType);
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
