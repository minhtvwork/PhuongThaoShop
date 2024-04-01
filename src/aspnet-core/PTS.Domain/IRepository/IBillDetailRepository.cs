using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
{
    public interface IBillDetailRepository
    {
        Task<bool> CreateBillDetail(BillDetailEntity obj);
        Task<bool> UpdateBillDetail(BillDetailEntity obj);
        Task<bool> DeleteBillDetail(int id);
        Task<List<BillDetailEntity>> GetAllBillDetails();
        Task<BillDetailEntity> GetBillDetailById(int id);
    }
}
