﻿using Microsoft.EntityFrameworkCore;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using System.Net.NetworkInformation;
using PTS.Data;

namespace PTS.EntityFrameworkCore.Repository
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public static int Page_Size { get; set; } = 10;
        private readonly ResponseDto responseDto;
        public ProductDetailRepository(ApplicationDbContext context)
        {
            _context = context;
            responseDto = new ResponseDto();
        }
        public async Task<List<ProductDetailEntity>> GetAll()
        {

            return await _context.ProductDetailEntity.Where(x => x.Status > 0).ToListAsync();
        }
        public async Task<bool> Create(ProductDetailEntity obj)
        {
            var checkMa = await _context.ProductDetailEntity.AnyAsync(x => x.Code == obj.Code);
            if (obj == null || checkMa == true)
            {
                return false;
            }
            try
            {

                await _context.ProductDetailEntity.AddAsync(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> CreateMany(List<ProductDetailEntity> list)
        {
            foreach (var i in list)
            {
                var checkMa = await _context.ProductDetailEntity.AnyAsync(x => x.Code == i.Code);
                if (checkMa == true)
                {
                    return false;
                }
            }
            try
            {
                await _context.ProductDetailEntity.AddRangeAsync(list);
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
            var productDetail = await _context.ProductDetailEntity.FindAsync(id);
            if (productDetail == null)
            {
                return false;
            }
            try
            {
                productDetail.Status = 0;
                _context.ProductDetailEntity.Update(productDetail);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private int GetCountProductDetail(string codeProductDetail)
        {
            int getCount = _context.ProductDetailEntity.Where(x => x.Status > 0 && x.Code == codeProductDetail)
           .Join(_context.SerialEntity, a => a.Id, b => b.ProductDetailEntityId, (a, b) => new ProductDetailEntity
           {
               Id = a.Id
           })
           .Count();
            return getCount;
        }
        public async Task<IEnumerable<ProductDetailDto>> PGetProductDetail(int? getNumber, string? codeProductDetail, int? status, string? search, decimal? from, decimal? to, string? sortBy, int? page,string? productType, string? namufacturer,string? ram, string? CPU, string? cardVGA)
        {
            var query = _context.ProductDetailEntity
                .AsNoTracking()
                .Include(a => a.ImageEntities)
                .Where(a => (status == null || a.Status == status) && (codeProductDetail != null ? a.Code == codeProductDetail : true))
                .Select(a => new ProductDetailDto
                {
                    Id = a.Id,
                    Code = a.Code,
                    OldPrice = a.OldPrice,
                    Price = a.Price,
                    Status = a.Status,
                    Upgrade = a.Upgrade,
                    Description = a.Description,
                    AvailableQuantity = 1,
                    ThongSoRam = a.RamEntity.ThongSo,
                    MaRam = a.RamEntity.Ma,
                    TenCpu = a.CpuEntity.Ten,
                    MaCpu = a.CpuEntity.Ma,
                    ThongSoHardDrive = a.HardDriveEntity.ThongSo,
                    MaHardDrive = a.HardDriveEntity.Ma,
                    NameColor = a.ColorEntity.Name,
                    MaColor = a.ColorEntity.Ma,
                    MaCardVGA = a.CardVGAEntity.Ma,
                    TenCardVGA = a.CardVGAEntity.Ten,
                    ThongSoCardVGA = a.CardVGAEntity.ThongSo,
                    MaManHinh = a.ScreenEntity.Ma,
                    KichCoManHinh = a.ScreenEntity.KichCo,
                    TanSoManHinh = a.ScreenEntity.TanSo,
                    ChatLieuManHinh = a.ScreenEntity.ChatLieu,
                    NameProduct = a.ProductEntity.Name,
                    NameProductType = a.ProductEntity.ProductTypeEntity.Name,
                    NameManufacturer = a.ProductEntity.ManufacturerEntity.Name,
                    LinkImage = (a.ImageEntities.FirstOrDefault(image => image.Ma == "Anh1") != null) ? a.ImageEntities.FirstOrDefault(image => image.Ma == "Anh1").LinkImage : null,
                    OtherImages = (a.ImageEntities.Where(image => image.Ma != "Anh1").Select(image => image.LinkImage).ToList()),
                });

            if (getNumber > 0)
            {
                query = query.Take(Convert.ToInt32(getNumber));
            }
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.NameProduct.Contains(search));
            }
            if (from.HasValue)
            {
                query = query.Where(x => x.Price >= from);
            }
            if (to.HasValue)
            {
                query = query.Where(x => x.Price <= to);
            }
            if (!string.IsNullOrEmpty(productType))
            {
                query = query.Where(x => x.NameProductType.Contains(productType));
            };

            if (!string.IsNullOrEmpty(namufacturer))
            {
                query = query.Where(x => x.NameManufacturer.Contains(namufacturer));
            };

            if (!string.IsNullOrEmpty(ram))
            {
                query = query.Where(x => x.ThongSoRam.Contains(ram));
            };

            if (!string.IsNullOrEmpty(CPU))
            {
                query = query.Where(x => x.TenCpu.Contains(CPU));
            };

            if (!string.IsNullOrEmpty(cardVGA))
            {
                query = query.Where(x => x.TenCardVGA.Contains(cardVGA));
            }; 
           


            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "nameproduct_desc":
                        query = query.OrderByDescending(x => x.NameProduct);
                        break;
                    case "price_asc":
                        query = query.OrderBy(x => x.Price);
                        break;
                    case "price_desc":
                        query = query.OrderByDescending(x => x.Price);
                        break;
                }
            }

            var pageSize = Page_Size;
            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);
            //page = Math.Clamp((byte)page, 1, totalPages);
            //query = query.Skip((int)((page - 1) * pageSize)).Take(pageSize);

            var result = await query.ToListAsync();

            foreach (var productDetail in result)
            {
                productDetail.AvailableQuantity = GetCountProductDetail(productDetail.Code);
            }

            return result;
        }


        public async Task<bool> Update(ProductDetailEntity obj)
        {
            var productDetail = await _context.ProductDetailEntity.FindAsync(obj.Id);
            if (productDetail == null)
            {
                return false;
            }
            try
            {
                productDetail.OldPrice = obj.OldPrice;
                productDetail.Price = obj.Price;
                productDetail.Upgrade = obj.Upgrade;
                productDetail.Description = obj.Description;
                productDetail.Status = obj.Status;
                _context.ProductDetailEntity.Update(productDetail);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateSoLuong(int id, int soLuong)
        // truyền vào 1 id + sl sản phẩm bán ra trong billdetail, giảm sl sp sau khi thanh toán
        {
            try
            {
                var productDetail = await _context.ProductDetailEntity.FindAsync(id);
                if (productDetail == null)
                {
                    return false;
                }
                //productDetail.AvailableQuantity -= soLuong;
                _context.ProductDetailEntity.Update(productDetail);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<ProductDetailDto> GetById(int id)
        {
            var query = await _context.ProductDetailEntity
              .AsNoTracking()
            .Include(a => a.ImageEntities)
            .Where(x=>x.Id == id)
            .Select(a => new ProductDetailDto
            {
                Id = a.Id,
                  Code = a.Code,
                  OldPrice = a.OldPrice,
                  Price = a.Price,
                  Status = a.Status,
                  Upgrade = a.Upgrade,
                  Description = a.Description,
                  AvailableQuantity = 1,
                  ThongSoRam = a.RamEntity.ThongSo,
                  MaRam = a.RamEntity.Ma,
                  TenCpu = a.CpuEntity.Ten,
                  MaCpu = a.CpuEntity.Ma,
                  ThongSoHardDrive = a.HardDriveEntity.ThongSo,
                  MaHardDrive = a.HardDriveEntity.Ma,
                  NameColor = a.ColorEntity.Name,
                  MaColor = a.ColorEntity.Ma,
                  MaCardVGA = a.CardVGAEntity.Ma,
                  TenCardVGA = a.CardVGAEntity.Ten,
                  ThongSoCardVGA = a.CardVGAEntity.ThongSo,
                  MaManHinh = a.ScreenEntity.Ma,
                  KichCoManHinh = a.ScreenEntity.KichCo,
                  TanSoManHinh = a.ScreenEntity.TanSo,
                  ChatLieuManHinh = a.ScreenEntity.ChatLieu,
                  NameProduct = a.ProductEntity.Name,
                  NameProductType = a.ProductEntity.ProductTypeEntity.Name,
                  NameManufacturer = a.ProductEntity.ManufacturerEntity.Name,
                  LinkImage = (a.ImageEntities.FirstOrDefault(image => image.Ma == "Anh1") != null) ? a.ImageEntities.FirstOrDefault(image => image.Ma == "Anh1").LinkImage : null,
                  OtherImages = (a.ImageEntities.Where(image => image.Ma != "Anh1").Select(image => image.LinkImage).ToList()),
              }).FirstOrDefaultAsync();
            return query;
        }
    }
}