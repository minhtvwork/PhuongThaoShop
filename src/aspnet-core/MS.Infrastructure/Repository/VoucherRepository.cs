using Microsoft.EntityFrameworkCore;

using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Data;

namespace PTS.EntityFrameworkCore.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly ApplicationDbContext _context;
        public VoucherRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(VoucherEntity obj)
        {
            var checkMa = await _context.VoucherEntity.AnyAsync(x => x.MaVoucher == obj.MaVoucher);// tìm mã, trả về true nếu đã có, false nếu chưa có
            if (obj == null || checkMa == true)
            {
                return false;
            }
            try
            {
                await _context.VoucherEntity.AddAsync(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //public async Task<ResponseDto> Create(VoucherEntity obj)
        //{
        //    var checkMa = await _context.VoucherEntity.AnyAsync(x => x.MaVoucher == obj.MaVoucher);

        //    if (obj == null || checkMa)
        //    {
        //        return new ResponseDto
        //        {
        //            IsSuccess = false,
        //            Code = 400,
        //            Message = "Thêm thất bại - Mã voucher đã tồn tại hoặc thông tin không hợp lệ.",
        //            Result = null
        //        };
        //    }

        //    if (obj.EndDay <= obj.StarDay)
        //    {
        //        return new ResponseDto
        //        {
        //            IsSuccess = false,
        //            Code = 400,
        //            Message = "Thêm thất bại - Ngày hết hạn phải lớn hơn ngày bắt đầu.",
        //            Result = null
        //        };
        //    }

        //    // Other validations...

        //    try
        //    {
        //        await _context.VoucherEntity.AddAsync(obj);
        //        await _context.SaveChangesAsync();

        //        return new ResponseDto
        //        {
        //            Result = obj,
        //            Message = "Thêm thành công"
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        return new ResponseDto
        //        {
        //            IsSuccess = false,
        //            Code = 500,
        //            Message = "Thêm thất bại - Lỗi hệ thống.",
        //            Result = null
        //        };
        //    }
        //}

        public async Task<bool> Delete(int id)
        {
            var vou = await _context.VoucherEntity.FindAsync(id);
            if (vou == null)
            {
                return false;
            }
            try
            {
                vou.Status = 0;
                _context.VoucherEntity.Update(vou);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<VoucherEntity>> GetAllVouchers(CancellationToken cancellationToken)
        {
              return await _context.VoucherEntity.AsNoTracking().Where(v=>!v.IsDeleted).ToListAsync(cancellationToken);
        }

        public async Task<ResponseDto> Update(VoucherEntity obj)
        {
            var vou = await _context.VoucherEntity.FindAsync(obj.Id);
            if (vou == null)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Code = 400,
                    Message = "Sửa thất bại - Không Tìm Thấy Voucher ",
                    Result = null
                };
            }
            if (obj.EndDay <= obj.StarDay)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Code = 400,
                    Message = "Sửa thất bại - Ngày hết hạn phải lớn hơn ngày bắt đầu.",
                    Result = null
                };
            }
            try
            {

                vou.Status = obj.Status;
                vou.TenVoucher = obj.TenVoucher;

                vou.StarDay = obj.StarDay;
                vou.SoLuong = obj.SoLuong;
                vou.EndDay = obj.EndDay;
                vou.GiaTri = obj.GiaTri;



                _context.VoucherEntity.Update(vou);
                await _context.SaveChangesAsync();
                return new ResponseDto
                {
                    Result = obj,
                    Message = "Sửa thành công"
                };
            }
            catch (Exception)
            {
                return new ResponseDto
                {
                    Result = obj,
                    Message = "Lỗi hệ thống "
                };
            }
        }
        public async Task<bool> UpdateSL(string codeVoucher)
        {
            var vou =await _context.VoucherEntity.FirstOrDefaultAsync(x => x.MaVoucher == codeVoucher);
            if (vou == null)
            {
                return false;
            }
            try
            {
                vou.SoLuong--;

                _context.VoucherEntity.Update(vou);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<VoucherEntity> GetByCode(string codeVoucher)
        {
            var result = await _context.VoucherEntity.FirstOrDefaultAsync(x => x.MaVoucher == codeVoucher);
            return result;
        }
        public async Task<bool> Duyet(int Id)
        {
            var vou = await _context.VoucherEntity.FindAsync(Id);

            if (vou == null)
            {
                return false;
            }
            else
            {
                try
                {
                    vou.Status = 1;
                    _context.VoucherEntity.Update(vou);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public async Task<bool> HuyDuyet(int Id)
        {
            var vou = await _context.VoucherEntity.FindAsync(Id);
            if (vou == null)
            {
                return false;
            }
            else
            {
                try
                {
                    vou.Status = 0;
                    _context.VoucherEntity.Update(vou);
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
}

