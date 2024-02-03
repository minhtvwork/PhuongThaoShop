//using Microsoft.EntityFrameworkCore;

//using PTS.EntityFrameworkCore.Repository.IRepository;
//using PTS.Domain.Dto;
//using PTS.Domain.Entities;

//namespace PTS.EntityFrameworkCore.Repository
//{
//    public class ManagePostRepository : IManagePostRepository
//    {
//        private readonly ApplicationDbContext _dbContext;

//        public ManagePostRepository(ApplicationDbContext context)
//        {
//            _dbContext = context;
//        }
//        public async Task<bool> Create(ManagePostEntity managePost)
//        {
//            var check = await _dbContext.ManagePostEntity.FirstOrDefaultAsync(x=>x.Code==managePost.Code);
//            if (managePost == null || check !=null)
//            {
//                return false;
//            }
//            try
//            {
//                await _dbContext.ManagePostEntity.AddAsync(managePost);
//                await _dbContext.SaveChangesAsync();
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }

//        public async Task<ResponseDto> Duyet(int Id)
//        {
//            var obj = await _dbContext.ManagePostEntity.FindAsync(Id);
//            if (obj == null)
//            {
//                return new ResponseDto
//                {
//                    Result = null,
//                    IsSuccess = false,
//                    Code = 400,
//                    Message = "Không tìm thấy bài viết",
//                };
//            }
//            try
//            {
//                //obj. = true;
//                _dbContext.ManagePosts.Update(obj);
//                await _dbContext.SaveChangesAsync();
//                return new ResponseDto
//                {
//                    Result = obj,
//                    IsSuccess = false,
//                    Code = 200,
//                    Message = "Duyệt thành công",
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

//        public async Task<ResponseDto> HuyDuyet(int Id)
//        {
//            var obj = await _dbContext.ManagePostEntity.FindAsync(id);
//            if (obj == null)
//            {
//                return new ResponseDto
//                {
//                    Result = null,
//                    IsSuccess = false,
//                    Code = 400,
//                    Message = "Không tìm thấy bài viết",
//                };
//            }
//            try
//            {
//                obj.Status = false;
//                _dbContext.ManagePosts.Update(obj);
//                await _dbContext.SaveChangesAsync();
//                return new ResponseDto
//                {
//                    Result = obj,
//                    IsSuccess = false,
//                    Code = 200,
//                    Message = "Hủy duyệt Thành Công",
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

//        public async Task<bool> Delete(int Id)
//        {
//            var obj = await _dbContext.ManagePostEntity.FindAsync(id);
//            if (obj == null)
//            {
//                return false;
//            }
//            try
//            {
//                obj.Status = false;
//                _dbContext.ManagePostEntity.Remove(obj);
//                await _dbContext.SaveChangesAsync();
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }



//        public async Task<List<ManagePostEntity>> GetAllManagePosts()
//        {
//            var list = await _dbContext.ManagePostEntity.ToListAsync();
//            //var listMP = list.Where(x => x.Status != false).ToList();
//            return list;
//        }

//        public Task<bool> GetByCode(int Id)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<ManagePostEntity> GetById(int Id)
//        {
//            var getById = await _dbContext.ManagePostEntity.FindAsync(id);
//            return getById;
//        }

//        public async Task<bool> Update(ManagePostEntity managePost)
//        {
//            var obj = await _dbContext.ManagePosts.FindAsync(managePost.Id);
//            if (obj == null)
//            {
//                return false;
//            }
//            try
//            {
//                obj.Code = managePost.Code;
//                obj.CreateDate = managePost.CreateDate;
//                obj.LinkImage = managePost.LinkImage;
//                obj.Status = managePost.Status;
//                obj.Description = managePost.Description;
//                _dbContext.ManagePosts.Update(obj);
//                await _dbContext.SaveChangesAsync();
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }

//        public async Task<IEnumerable<ManagePostEntity>> GetManagePostDtos(string? search, DateTime? from, DateTime? to, string? sortBy,bool? status, int page = 1)
//        {
//            var query = _dbContext.ManagePosts
//                .AsNoTracking()
//                //.Where(a => a.Status!=false)
//                .Select(a => new ManagePostEntity
//                {
//                    Id = a.Id,
//                    Code = a.Code,
//                    CreateDate = a.CreateDate,
//                    LinkImage = a.LinkImage,
//                    Description = a.Description,
//                    Status = a.Status,

//                });

//            #region Filltering
//            if (!string.IsNullOrEmpty(search))
//            {
//                query = query.Where(x => x.Code.Contains(search));
//            }

//            if (from.HasValue)
//            {
//                query = query.Where(x => x.CreateDate >= from);
//            }
//            if (to.HasValue)
//            {
//                query = query.Where(x => x.CreateDate <= to);
//            }
//            #endregion
        
//            if (status.HasValue)
//            {
//                query = query.Where(x => x.Status == status.Value);
//            }
//            #region Sorting
//            //if (!string.IsNullOrEmpty(sortBy))
//            //{
//            //    switch (sortBy)
//            //    {
//            //        case "nameproduct_desc":
//            //            query = query.OrderByDescending(x => x.Code);
//            //            break;
//            //        case "price_asc":
//            //            query = query.OrderBy(x => x.Price);
//            //            break;
//            //        case "price_desc":
//            //            query = query.OrderByDescending(x => x.Price);
//            //            break;
//            //        default:
//            //            break;
//            //    }
//            //}
//            #endregion

//            #region Paging
//            var pageSize = page;
//            var totalItems = await query.CountAsync();
//            var totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);
//            if (page < 1)
//            {
//                page = 1;
//            }
//            else if (page > totalPages)
//            {
//                page = totalPages;
//            }

//            //query = query.Skip((page - 1) * pageSize).Take(pageSize);
//            #endregion
//            var result = await query.ToListAsync();
//            // Lấy danh sách mã sản phẩm để thực hiện một lần duy nhất truy vấn cơ sở dữ liệu.
//            var productCodes = result.Select(p => p.Code).ToList();
//            // Gán AvailableQuantity cho từng sản phẩm trong danh sách.
//            //foreach (var productDetail in result)
//            //{
//            //    productDetail.AvailableQuantity = GetCountProductDetail(productDetail.Code);
//            //}

//            return result;
//        }

//    }
//}
