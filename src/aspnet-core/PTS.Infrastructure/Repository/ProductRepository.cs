﻿using Microsoft.EntityFrameworkCore;

using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using System.Drawing.Printing;
using PTS.Data;

namespace PTS.EntityFrameworkCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ProductRepository(ApplicationDbContext applicationDb)
        {
          
            dbContext = applicationDb;  
        }
        public async Task<bool> Create(ProductEntity obj)
        {
            var x = await dbContext.ProductEntity.AnyAsync(p=>p.Name == obj.Name);
            if (x== true && obj == null)
            {
                return false;
            }
            try
            {
                await dbContext.ProductEntity.AddAsync(obj);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public async Task<bool> Delete(int idobj)
        {
            var x = await dbContext.ProductEntity.FindAsync(idobj);
            if (x == null)
            {
                return false;
            }
            try
            {
                x.Status = 0;
                dbContext.ProductEntity.Update(x);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            var list = await dbContext.ProductEntity.ToListAsync();
            var listx = list.Where(x => x.Status > 0).ToList();
            return listx;
        }

        public async Task<ProductEntity> GetById(int id)
        {
            var result = await dbContext.ProductEntity.FindAsync(id);
            return result;
        }

        public async Task<bool> Update(ProductEntity obj)
        {
            var x = await dbContext.ProductEntity.FindAsync(obj.Id);
            if (x == null)
            {
                return false;
            }
            try
            {
                x.Name = obj.Name;
                //x.Status = obj.Status;
                x.ManufacturerEntityId = obj.ManufacturerEntityId;
                x.ProductTypeEntityId = obj.ProductTypeEntityId;
                dbContext.ProductEntity.Update(x);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProductDtos(string? search, decimal? from, decimal? to, string? sortBy, int page = 1)
        {
            var query = dbContext.ProductEntity
                .AsNoTracking()
                .Where(a => a.Status > 0)
                .Select(a => new ProductDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    ProductTypeName = a.ProductTypeEntity.Name,
                    ProductTypeId = a.ProductTypeEntityId,
                    ManuName = a.ManufacturerEntity.Name,
                    ManufacturerId = a.ManufacturerEntityId,

                });

            #region Filltering
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }
            //if (from.HasValue)
            //{
            //    query = query.Where(x => x.Price >= from);
            //}
            //if (to.HasValue)
            //{
            //    query = query.Where(x => x.Price <= to);
            //}
            #endregion

            #region Sorting
            //if (!string.IsNullOrEmpty(sortBy))
            //{
            //    switch (sortBy)
            //    {
            //        case "nameproduct_desc":
            //            query = query.OrderByDescending(x => x.NameProduct);
            //            break;
            //        case "price_asc":
            //            query = query.OrderBy(x => x.Price);
            //            break;
            //        case "price_desc":
            //            query = query.OrderByDescending(x => x.Price);
            //            break;
            //        default:
            //            break;
            //    }
            //}
            #endregion

            #region Paging
            //var pageSize = Page_Size;
            //var totalItems = await query.CountAsync();
            //var totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);
            //if (page < 1)
            //{
            //    page = 1;
            //}
            //else if (page > totalPages)
            //{
            //    page = totalPages;
            //}

            //query = query.Skip((page - 1) * pageSize).Take(pageSize);
            #endregion
            var result = await query.ToListAsync();
            // Lấy danh sách mã sản phẩm để thực hiện một lần duy nhất truy vấn cơ sở dữ liệu.
            var productCodes = result.Select(p => p.Name).ToList();
            // Gán AvailableQuantity cho từng sản phẩm trong danh sách.
            //foreach (var productDetail in result)
            //{
            //    productDetail.AvailableQuantity = GetCountProductDetail(productDetail.Code);
            //}

            return result;
        }

    }
}
