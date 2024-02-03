using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IVoucherRepository
    {
        //Task<bool> Create(Voucher obj);
        Task<ResponseDto> Create(VoucherEntity obj);
        Task<ResponseDto> Update(VoucherEntity obj);
        Task<bool> Delete(int id);
        Task<bool> UpdateSL(string codeVoucher);
        Task<IEnumerable<VoucherEntity>> GetAllVouchers();
        Task<VoucherEntity> GetByCode(string codeVoucher);
        Task<bool> Duyet(int Id);
        Task<bool> HuyDuyet(int Id);
    }
}
