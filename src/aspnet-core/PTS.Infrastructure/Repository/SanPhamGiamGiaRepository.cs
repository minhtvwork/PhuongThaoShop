//using Microsoft.EntityFrameworkCore;

//using PTS.EntityFrameworkCore.Repository.IRepository;
//using PTS.Domain.Dto;
//using PTS.Domain.Entities;

//namespace PTS.EntityFrameworkCore.Repository
//{
//    public class SanPhamGiamGiaRepository : ISanPhamGiamGiaRepository
//    {
//        private readonly ApplicationDbContext _context;
//        public SanPhamGiamGiaRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<ResponseDto> Create(SanPhamGiamGiaEntity obj)
//        {
//            var checkMa = await _context.SanPhamGiamGias.AnyAsync(x => x.ProductDetailId == obj.ProductDetailId);
//            if (obj == null || checkMa == true)
//            {

//                return new ResponseDto
//                {
//                    Result = null,
//                    IsSuccess = false,
//                    Code = 400,
//                    Message = "Trùng Mã",

//                };
//            }
//            if (obj.ProductDetailId == int.Empty && obj.GiamGiaId == int.Empty)
//            {
//                return new ResponseDto
//                {
//                    Result = null,
//                    IsSuccess = false,
//                    Code = 400,
//                    Message = "Bắt buộc phải chọn mã giảm giá và mã sản phẩm",

//                };
//            }
           

//            try
//            {

//                await _context.SanPhamGiamGiaEntity.AddAsync(obj);
//                await _context.SaveChangesAsync();
//                return new ResponseDto
//                {
//                    Result = obj,
//                    IsSuccess = true,
//                    Code = 200,
//                    Message = "Thành Công",

//                };
//            }
//            catch (Exception)
//            {
//                return new ResponseDto
//                {
//                    Result = null,
//                    IsSuccess = false,
//                    Code = 500,
//                    Message = "Lỗi hệ thống",

//                };
//            }
//        }

//        public async Task<bool> Delete(int id)
//        {
//            var sanPhamGiamGia = await _context.SanPhamGiamGiaEntity.FindAsync(id);
//            if (sanPhamGiamGia == null)
//            {
//                return false;
//            }
//            try
//            {
//                _context.SanPhamGiamGiaEntity.Remove(sanPhamGiamGia);
//                await _context.SaveChangesAsync();
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }

//        public async Task<List<SanPhamGiamGiaEntity>> GetAllSanPhamGiamGias()
//        {
//            return await _context.SanPhamGiamGiaEntity.ToListAsync();
//        }

//        public async Task<bool> Update(SanPhamGiamGiaEntity obj)
//        {
//            var sanPhamGiamGia = await _context.SanPhamGiamGias.FindAsync(obj.Id);

//            if (sanPhamGiamGia == null)
//            {
//                return false;
//            }
//            try
//            {
//                //sanPhamGiamGia.DonGia = obj.DonGia;
//                //sanPhamGiamGia.SoTienConLai = obj.SoTienConLai;
//                ////sanPhamGiamGia.TrangThai = obj.TrangThai;
//                sanPhamGiamGia.ProductDetailId = obj.ProductDetailId;
//                sanPhamGiamGia.GiamGiaId = obj.GiamGiaId;

//                _context.SanPhamGiamGias.Update(sanPhamGiamGia);
//                await _context.SaveChangesAsync();
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }

//        public async Task<SanPhamGiamGiaEntity> GetById(int id)
//        {
//            return await _context..FindAsync(id);
//        }
//    }
//}
