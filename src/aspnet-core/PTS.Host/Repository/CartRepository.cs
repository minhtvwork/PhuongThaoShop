using Microsoft.EntityFrameworkCore;

using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(CartEntity obj)
        {
            var checkId = await _context.CartEntity.AnyAsync(x => x.IdUser == obj.IdUser);
            if (obj == null || checkId == true)
            {
                return false;
            }
            try
            {
                await _context.CartEntity.AddAsync(obj);
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
            var cart = await _context.CartEntity.FindAsync(id);
            if (cart == null)
            {
                return false;
            }
            try
            {
                _context.CartEntity.Remove(cart);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CartEntity>> GetAll()
        {
            return await _context.CartEntity.ToListAsync();
        }

        public async Task<CartEntity> GetCartById(int id)
        {
            try
            {

                var cart = await _context.CartEntity.FirstOrDefaultAsync(x => x.IdUser == id);
                return cart;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<IEnumerable<CartItemDto>> GetCartItem(string username)
        {
            // Truyền vào tên tào khoản của người dùng
            try
            {
                var user = await _context.UserEntity.FirstOrDefaultAsync(x => x.Username == username);// lấy danh sách người dùng trong database
                // Chú ý lấy trước rồi mới tìm để phân biệt được chữ hoa, chữ thường
                // Nếu tìm trực tiếp sẽ không phân biệt được chữ hoa, chữ thường
                // Lấy ra ìd người dùng//x => x.UserName == username
                // Dùng CartItemDto để hiển thị kết quả
                List<CartItemDto> cartItem = new List<CartItemDto>();// Khởi tao 1 list
                cartItem = (
                           // Join các bảng lại để lấy dữ liệu
                           from x in await _context.CartEntity.ToListAsync()
                           join y in await _context.CartDetailEntity.ToListAsync() on x.IdUser equals y.CartId
                           join a in await _context.ProductDetailEntity.ToListAsync() on y.ProductDetailEntityId equals a.Id
                           join b in await _context.RamEntity.ToListAsync() on a.RamEntityId equals b.Id
                           join c in await _context.CpuEntity.ToListAsync() on a.CpuEntityId equals c.Id
                           join d in await _context.HardDriveEntity.ToListAsync() on a.HardDriveEntityId equals d.Id
                           join e in await _context.ColorEntity.ToListAsync() on a.ColorEntityId equals e.Id
                           join f in await _context.CardVGAEntity.ToListAsync() on a.CardVGAEntityId equals f.Id
                           join g in await _context.ScreenEntity.ToListAsync() on a.ScreenEntityId equals g.Id
                           // join h in await _context.ImageEntity.ToListAsync() on a.Id equals h.ProductDetailEntityId
                           join i in await _context.ProductEntity.ToListAsync() on a.ProductEntityId equals i.Id
                           join k in await _context.ManufacturerEntity.ToListAsync() on i.ManufacturerEntityId equals k.Id
                           select new CartItemDto// Dùng kiểu đối tượng ẩn danh (anonymous type)
                           {
                               Id = y.Id,
                               UserId = x.IdUser,
                               Quantity = y.Quantity,
                               Status = y.Status,
                               IdProductDetails = a.Id,
                               MaProductDetail = a.Code,
                               Price = a.Price,
                               Description = a.Description,
                               ThongSoRam = b.ThongSo,
                               MaRam = b.Ma,
                               TenCpu = c.Ten,
                               MaCpu = c.Ma,
                               ThongSoHardDrive = d.ThongSo,
                               MaHardDrive = d.Ma,
                               NameColor = e.Name,
                               MaColor = e.Ma,
                               MaCardVGA = f.Ma,
                               TenCardVGA = f.Ten,
                               ThongSoCardVGA = f.ThongSo,
                               MaManHinh = g.Ma,
                               KichCoManHinh = g.KichCo,
                               TanSoManHinh = g.TanSo,
                               ChatLieuManHinh = g.ChatLieu,
                               NameProduct = i.Name,
                               NameManufacturer = k.Name
                               //  LinkImage = h.LinkImage
                           }
                    ).ToList();
                return cartItem.Where(x => x.UserId == user.Id);// Trả về list với điểu kiện 
            }
            catch (Exception)
            {
                // Nếu idUser bị null tức là không tìm thấy, sẽ xảy ra Exception
                // Sau đó trả về null
                return null;
            }

        }
        //public async Task<IEnumerable<CartItemDto>> GetAllCarts()
        //{

        //    // Dùng CartItemDto để hiển thị kết quả
        //    List<CartItemDto> cartItem = new List<CartItemDto>();// Khởi tao 1 list
        //    cartItem = (
        //               // Join các bảng lại để lấy dữ liệu
        //               from x in await _context.CartEntity.ToListAsync()
        //               join y in await _context.CartDetailEntity.ToListAsync() on x.UserId equals y.CartId
        //               join a in await _context.ProductDetailEntity.ToListAsync() on y.ProductDetailId equals a.Id
        //               join b in await _context.RamEntity.ToListAsync() on a.RamId equals b.Id
        //               join c in await _context.CpuEntity.ToListAsync() on a.CpuId equals c.Id
        //               join d in await _context.HardDriveEntity.ToListAsync() on a.HardDriveId equals d.Id
        //               join e in await _context.ColorEntity.ToListAsync() on a.ColorId equals e.Id
        //               join f in await _context.CardVGAEntity.ToListAsync() on a.CardVGAId equals f.Id
        //               join g in await _context.ScreenEntity.ToListAsync() on a.ScreenId equals g.Id
        //               // join h in await _context.ImageEntity.ToListAsync() on a.Id equals h.ProductDetailId
        //               join i in await _context.ProductEntity.ToListAsync() on a.ProductId equals i.Id
        //               join k in await _context.ManufacturerEntity.ToListAsync() on i.ManufacturerId equals k.Id
        //               select new CartItemDto// Dùng kiểu đối tượng ẩn danh (anonymous type)
        //               {
        //                   Id = y.Id,
        //                   UserId = x.UserId,
        //                   Quantity = y.Quantity,
        //                   IdProductDetails = a.Id,
        //                   MaProductDetail = a.Ma,
        //                   Price = a.Price,
        //                   Description = a.Description,
        //                   ThongSoRam = b.ThongSo,
        //                   MaRam = b.Ma,
        //                   TenCpu = c.Ten,
        //                   MaCpu = c.Ma,
        //                   ThongSoHardDrive = d.ThongSo,
        //                   MaHardDrive = d.Ma,
        //                   NameColor = e.Name,
        //                   MaColor = e.Ma,
        //                   MaCardVGA = f.Ma,
        //                   TenCardVGA = f.Ten,
        //                   ThongSoCardVGA = f.ThongSo,
        //                   MaManHinh = g.Ma,
        //                   KichCoManHinh = g.KichCo,
        //                   TanSoManHinh = g.TanSo,
        //                   ChatLieuManHinh = g.ChatLieu,
        //                   NameProduct = i.Name,
        //                   NameManufacturer = k.Name
        //                   //  LinkImage = h.LinkImage
        //               }
        //        ).ToList();
        //    return cartItem;

        //}

        public async Task<bool> Update(CartEntity obj)
        {
            var cart = await _context.CartEntity.FindAsync(obj.IdUser);
            if (cart == null)
            {
                return false;
            }
            try
            {
                cart.Description = obj.Description;
                _context.CartEntity.Update(cart);
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
