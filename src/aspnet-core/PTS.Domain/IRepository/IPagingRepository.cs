using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
{
    public interface IPagingRepository   /* public interface IPagingRepository<T> where T : class*/
    {
       

        List<PagingDto> GetAll(string search, decimal? from, decimal? to, string sortBy, int page);
		List<PagingDto> GetAllColor(string? search, decimal? from, decimal? to, string? sortBy, int page);
		List<ProductDto> GetAllProduct(string? search, decimal? from, decimal? to, string? sortBy, int page);
		List<PagingDto> GetAllRam(string? search, decimal? from, decimal? to, string? sortBy, int page);
        List<PagingDto> GetAllScreen(string? search, decimal? from, decimal? to, string? sortBy, int page);
        List<PagingDto> GetAllHardDrive(string? search, decimal? from, decimal? to, string? sortBy, int page);
        List<PagingDto> GetAllCardVGA(string? search, decimal? from, decimal? to, string? sortBy, int page);
        List<PagingDto> GetAllManufacturer(string? search, decimal? from, decimal? to, string? sortBy, int page);
        List<PagingDto> GetAllCpu(string? search, decimal? from, decimal? to, string? sortBy, int page);
        List<UserDto> GetAllUser(string? search, decimal? from, decimal? to, string? sortBy, int page);
        List<SerialDto> GetAllSerial(string? search, decimal? from, decimal? to, string? sortBy, int page);
        List<VoucherEntity> GetAllVoucherPG(string? search, decimal? from, decimal? to, string? sortBy, int? page);
        List<GiamGiaEntity> GetAllGiamGia(string? search, decimal? from, decimal? to, string? sortBy, int page);
        List<SanPhamGiamGiaDto> GetAllSPGGPGs(string? codeProductDetail, string? search, decimal? from, decimal? to, string? sortBy, int? page);

    }
}
