﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTS.Data;
using PTS.Domain.Entities;
using PTS.Application.Interfaces.Repositories;
using PTS.Persistence.Services;
using PTS.WebAPI.Controllers;
using PTS.Application.Features.Image.Commands;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using PTS.Application.Features.Voucher.Queries;
using PTS.Application.Features.Image.Queries;
using PTS.Application.Features.Product.Commands;
namespace PTS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : BaseController
    {
      //  private readonly IImageRepository _repository;
        private readonly IConfiguration _config;
        //   private readonly IImagesServies _imageUploadService;
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;
        public ImagesController(IConfiguration config, IWebHostEnvironment hostingEnvironment, IMediator mediator, ApplicationDbContext context)
        {
         //   _repository = repository;
            _config = config;

            //_imageUploadService = imageUploadService;
            _hostingEnvironment = hostingEnvironment;
            _mediator = mediator;
            // Tạo thư mục lưu trữ nếu nó không tồn tại
            Directory.CreateDirectory(_uploadFolder);
            _context = context;
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<ActionResult<IEnumerable<ImageEntity>>> GetImages()
        //{

        //    string apiKey = _config.GetSection("ApiKey").Value;
        //    if (apiKey == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
        //    if (keyDomain != apiKey.ToLower())
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok(await _repository.GetAllImage());
        //}
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new ImageGetAllQuery()));
        }

        [HttpPost("GetPage")]
        public async Task<IActionResult> GetPage(ImageGetPageQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var command = new ImageCreateCommand
            {
               Name = file.FileName,
               Url = $"/uploads/{file.FileName}",
               CrDateTime = DateTime.Now,
               Status = 1
            };
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> CreateOrUpdate(ImageEditCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id,string url)
        {
            if (string.IsNullOrEmpty(url))
                return BadRequest("No file URL provided");
            var fileName = Path.GetFileName(url);
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");
            System.IO.File.Delete(filePath);
            var command = new ImageDeleteCommand
            {
               Id = id
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        //[HttpPut]
        //public async Task<IActionResult> UpdateImage(ImageEntity image)
        //{

        //    string apiKey = _config.GetSection("ApiKey").Value;
        //    if (apiKey == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
        //    if (keyDomain != apiKey.ToLower())
        //    {
        //        return Unauthorized();
        //    }
        //    if (await _repository.Update(image))
        //    {
        //        return Ok("Sửa thành công");

        //    }
        //    return BadRequest("Sửa thất bại");
        //}

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ImageEntity>> CreateImage(ImageEntity image)
        //{

        //    string apiKey = _config.GetSection("ApiKey").Value;
        //    if (apiKey == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
        //    if (keyDomain != apiKey.ToLower())
        //    {
        //        return Unauthorized();
        //    }
        //    if (await _repository.Create(image))
        //    {
        //        return Ok("Thêm thành công");
        //    }
        //    return BadRequest("Thêm thất bại");
        //}

        // DELETE: api/Images/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteImage(int id)
        //{

        //    string apiKey = _config.GetSection("ApiKey").Value;
        //    if (apiKey == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
        //    if (keyDomain != apiKey.ToLower())
        //    {
        //        return Unauthorized();
        //    }
        //    if (await _repository.Delete(id))
        //    {

        //        return Ok("Xóa thành công");
        //    }
        //    return BadRequest("Xóa thất bại");
        //}



        //  [HttpPost]
        //[Route("TaiAnh")]
        //public async Task<IActionResult> TaiAnh(IFormFile file, string objectType, int? objectId, string imageCode)
        //{
        //    if (file == null)
        //    {
        //        return BadRequest("Vui lòng chọn một tệp để tải lên và lưu.");
        //    }

        //    string objectFolder = null;
        //    bool saveToDb = false;

        //    switch (objectType)
        //    {
        //        case "a":
        //            objectFolder = "product_images";
        //            saveToDb = true;
        //            break;
        //        case "b":
        //            objectFolder = "user_images";
        //            saveToDb = false;
        //            break;
        //        case "c":
        //            objectFolder = "bai_dang_images";
        //            saveToDb = false;
        //            break;
        //        case "d":
        //            objectFolder = "card_VGA_images";
        //            saveToDb = false;
        //            break;
        //        case "e":
        //            objectFolder = "hard_drive_images";
        //            saveToDb = false;
        //            break;
        //        case "f":
        //            objectFolder = "manufacturer_images"; saveToDb = false;
        //            break;
        //        case "g":
        //            objectFolder = "ram_images"; saveToDb = false;
        //            break;
        //        case "h":
        //            objectFolder = "screen_images"; saveToDb = false;
        //            break;
        //        case "i":
        //            objectFolder = "voucher_images"; saveToDb = false;
        //            break;

        //        default:
        //            return BadRequest("Loại đối tượng không hợp lệ.");
        //    }

        //    string basePath = _hostingEnvironment.WebRootPath; // Đường dẫn gốc của thư mục wwwroot
        //    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        //    string filePath = Path.Combine(basePath, objectFolder, fileName);

        //    // Kiểm tra định dạng tệp ảnh
        //    string fileExtension = Path.GetExtension(file.FileName).ToLower();
        //    if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png" && fileExtension != ".gif")
        //    {
        //        return BadRequest("Vui lòng tải lên một tệp ảnh hợp lệ.");
        //    }

        //    // Giới hạn kích thước tệp
        //    long maxFileSizeInBytes = 5 * 1024 * 1024; // Giới hạn kích thước tệp là 5 MB
        //    if (file.Length > maxFileSizeInBytes)
        //    {
        //        return BadRequest("Kích thước tệp quá lớn. Vui lòng tải lên một tệp nhỏ hơn.");
        //    }
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }
        //    if (saveToDb)
        //    {
        //        var image = new ImageEntity
        //        {

        //            Ma = imageCode, // Mã của ảnh
        //            LinkImage = $"/{objectFolder}/{fileName}", // Đường dẫn tương đối đến ảnh
        //            ProductDetailEntityId = objectId, // Đối tượng ProductDetail
        //            Status = 1 // Trạng thái ảnh
        //        };

        //        await _imageUploadService.SaveImageAsync(image);
        //    }

        //    return Ok("Tải lên và lưu thành công.");
        //}
        //[HttpDelete]
        //[Route("XoaAnh")]
        //public IActionResult XoaAnh(string objectType, string imageName)
        //{
        //    if (string.IsNullOrEmpty(objectType) || string.IsNullOrEmpty(imageName))
        //    {
        //        return BadRequest("Thông tin không hợp lệ.");
        //    }

        //    string objectFolder = null;

        //    switch (objectType)
        //    {
        //        case "a":
        //            objectFolder = "product_images";
        //            break;
        //        case "b":
        //            objectFolder = "user_images";
        //            break;
        //        case "c":
        //            objectFolder = "bai_dang_images";
        //            break;
        //        case "d":
        //            objectFolder = "card_VGA_images";
        //            break;
        //        case "e":
        //            objectFolder = "hard_drive_images";
        //            break;
        //        case "f":
        //            objectFolder = "manufacturer_images";
        //            break;
        //        case "g":
        //            objectFolder = "ram_images";
        //            break;
        //        case "h":
        //            objectFolder = "screen_images";
        //            break;
        //        case "i":
        //            objectFolder = "voucher_images";
        //            break;
        //        default:
        //            return BadRequest("Loại đối tượng không hợp lệ.");
        //    }

        //    string basePath = _hostingEnvironment.WebRootPath; // Đường dẫn gốc của thư mục wwwroot
        //    string filePath = Path.Combine(basePath, objectFolder, imageName);

        //    var image = _context.ImageEntity.FirstOrDefault(x => x.LinkImage == $"/{objectFolder}/{imageName}");
        //    // tìm ảnh theo tên 
        //    //var imagesByName = _context.Images.FirstOrDefault(x=>x.Ma==);
        //    if (System.IO.File.Exists(filePath) && image != null)
        //    {
        //        _context.ImageEntity.Remove(image);
        //        _context.SaveChanges();
        //        System.IO.File.Delete(filePath);
        //        return Ok("Xóa tệp ảnh thành công.");
        //    }
        //    else if (System.IO.File.Exists(filePath) && image == null)
        //    {
        //        System.IO.File.Delete(filePath);
        //        return Ok("Xóa tệp ảnh thành công.");
        //    }
        //    else
        //    {
        //        return BadRequest("Không tìm thấy tệp ảnh để xóa.");
        //    }
        //}


        // UpdateImages By Name Of file in wwwroot

        //[HttpPut]
        //[Route("update/{imageName}")]
        //public async Task<IActionResult> UpdateImage(string imageName, string objectType,/* [FromForm]*/ IFormFile file)
        //{
        //    try
        //    {
        //        if (file == null)
        //        {
        //            return BadRequest("Vui lòng chọn một tệp để tải lên và lưu.");
        //        }

        //        string objectFolder = null;
        //        bool saveToDb = false;

        //        switch (objectType)
        //        {
        //            case "a":
        //                objectFolder = "product_images";
        //                saveToDb = true;
        //                break;
        //            case "b":
        //                objectFolder = "user_images";
        //                saveToDb = false;
        //                break;
        //            case "c":
        //                objectFolder = "bai_dang_images";
        //                saveToDb = false;
        //                break;
        //            case "d":
        //                objectFolder = "card_VGA_images";
        //                saveToDb = false;
        //                break;
        //            case "e":
        //                objectFolder = "hard_drive_images";
        //                saveToDb = false;
        //                break;
        //            case "f":
        //                objectFolder = "manufacturer_images"; saveToDb = false;
        //                break;
        //            case "g":
        //                objectFolder = "ram_images"; saveToDb = false;
        //                break;
        //            case "h":
        //                objectFolder = "screen_images"; saveToDb = false;
        //                break;
        //            case "i":
        //                objectFolder = "voucher_images"; saveToDb = false;
        //                break;

        //            default:
        //                return BadRequest("Loại đối tượng không hợp lệ.");
        //        }

        //        string basePath = _hostingEnvironment.WebRootPath; // Đường dẫn gốc của thư mục wwwroot
        //                                                           //string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        //        string filePath = Path.Combine(basePath, objectFolder, imageName);


        //        string _newFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        //        string NewfilePath = Path.Combine(basePath, objectFolder, _newFileName);

        //        var image = _context.ImageEntity.FirstOrDefault(x => x.LinkImage == $"/{objectFolder}/{imageName}");
        //        // tìm ảnh theo tên 

        //        if (!System.IO.File.Exists(filePath))
        //        {
        //            return NotFound("Không tìm thấy tệp ảnh.");
        //        }

        //        if (System.IO.File.Exists(filePath) && image != null && objectType == "a")
        //        {
        //            image.LinkImage = $"/{objectFolder}/{_newFileName}";


        //            // Lưu ảnh vào cơ sở dữ liệu ở đây (sử dụng dịch vụ _imageUploadService)

        //            _context.ImageEntity.Update(image);
        //            await _context.SaveChangesAsync();

        //            // Xóa tệp ảnh cũ
        //            System.IO.File.Delete(filePath);

        //            // Lưu tệp ảnh mới
        //            using (var stream = new FileStream(NewfilePath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(stream);
        //            }
        //            //System.IO.File.Create(NewfilePath);
        //            //return Ok("chỉnh tệp ảnh thành công.");
        //        }
        //        else
        //        {
        //            System.IO.File.Delete(filePath);

        //            // Lưu tệp ảnh mới
        //            using (var stream = new FileStream(NewfilePath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(stream);
        //            }
        //        }
        //        return Ok(new { Message = "Cập nhật ảnh thành công.", ImagePath = NewfilePath });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Lỗi: {ex.Message}");
        //    }
        //}
        [HttpGet]
        [Route("get-images-by-object-type/{objectType}")]
        public IActionResult GetImagesByObjectType(string objectType)
        {
            try
            {
                // Xác định thư mục lưu trữ dựa trên objectType
                string objectFolder = null;
                switch (objectType)
                {
                    case "a":
                        objectFolder = "product_images";
                        break;
                    case "b":
                        objectFolder = "user_images";
                        break;
                    // (Thêm các case tương tự như trước)
                    default:
                        return BadRequest("Loại đối tượng không hợp lệ.");
                }

                string basePath = _hostingEnvironment.WebRootPath; // Đường dẫn gốc của thư mục wwwroot
                string objectFolderPath = Path.Combine(basePath, objectFolder);

                // Kiểm tra xem thư mục tồn tại
                if (!Directory.Exists(objectFolderPath))
                {
                    return NotFound("Không có ảnh nào được tìm thấy cho đối tượng này.");
                }

                // Lấy danh sách tên tệp ảnh trong thư mục
                string[] imageFileNames = Directory.GetFiles(objectFolderPath);

                return Ok(imageFileNames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("find-image/{objectType}/{imageName}")] // có cả đuôi png
        public IActionResult FindImage(string objectType, string imageName)
        {
            try
            {
                // Xác định thư mục lưu trữ dựa trên objectType
                string objectFolder = null;
                switch (objectType)
                {
                    case "a":
                        objectFolder = "product_images";
                        break;
                    case "b":
                        objectFolder = "user_images";
                        break;
                    case "c":
                        objectFolder = "bai_dang_images";
                        break;
                    case "d":
                        objectFolder = "card_VGA_images";
                        break;
                    case "e":
                        objectFolder = "hard_drive_images";
                        break;
                    case "f":
                        objectFolder = "manufacturer_images";
                        break;
                    case "g":
                        objectFolder = "ram_images";
                        break;
                    case "h":
                        objectFolder = "screen_images";
                        break;
                    case "i":
                        objectFolder = "voucher_images";
                        break;
                    default:
                        return BadRequest("Loại đối tượng không hợp lệ.");
                }

                string basePath = _hostingEnvironment.WebRootPath; // Đường dẫn gốc của thư mục wwwroot
                string objectFolderPath = Path.Combine(basePath, objectFolder);
                string imagePath = Path.Combine(objectFolderPath, imageName);

                // Kiểm tra xem tệp ảnh có tồn tại không
                if (!System.IO.File.Exists(imagePath))
                {
                    return NotFound("Không tìm thấy ảnh.");
                }

                // Trả về tệp ảnh dưới dạng một phản hồi tệp
                return PhysicalFile(imagePath, "image/jpeg"); // Điều chỉnh kiểu tệp tùy theo định dạng thực tế của tệp ảnh
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi: {ex.Message}");
            }
        }

        private readonly string _uploadFolder = "uploads"; // Thư mục lưu trữ tệp ảnh
        [HttpPost]
        //[Route("uploadManyProductDetailImages")] // NO NO
        //public async Task<IActionResult> UploadImages([FromForm] List<IFormFile> files, [FromForm] int ProductId)
        //{
        //    var objectFolder = "product_images";
        //    //var ProductId = Guid.Empty;
        //    try
        //    {
        //        var uploadedFiles = new List<string>();
        //        var spct = await _context.ProductDetailEntity.FindAsync(ProductId);

        //        if (spct != null)
        //        {
        //            int i = 1;
        //            foreach (var file in files)
        //            {
        //                if (file != null && file.Length > 0)
        //                {
        //                    string basePath = _hostingEnvironment.WebRootPath;
        //                    // Tạo tên tệp duy nhất bằng cách sử dụng Guid và đuôi mở rộng
        //                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        //                    string filePath = Path.Combine(basePath, objectFolder, fileName);
        //                    using (var stream = new FileStream(filePath, FileMode.Create))
        //                    {
        //                        await file.CopyToAsync(stream);
        //                    }

        //                    uploadedFiles.Add(fileName);
        //                    var image = new ImageEntity
        //                    {
        //                        Ma = "Anh" + i++,
        //                        LinkImage = $"/{objectFolder}/{fileName}",
        //                        ProductDetailEntityId = ProductId,
        //                        Status = 1
        //                    };

        //                    // Lưu ảnh vào cơ sở dữ liệu ở đây (sử dụng dịch vụ _imageUploadService)
        //                    await _imageUploadService.SaveImageAsync(image);

        //                }
        //            }
        //        }

        //        return Ok(new { Message = "Tải lên thành công", Files = uploadedFiles });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Lỗi: {ex.Message}");
        //    }
        //}
        [HttpGet]
        [Route("getProductDetailImages")]
        public IActionResult GetProductDetailImages(int ProductId)
        {
            try
            {
                    return Ok();
              
            }
            catch (Exception ex)
            {
                // Ghi log lỗi ở đây
                return StatusCode(500, $"Lỗi: {ex.Message}");
            }
        }


        [HttpPost]// DONE wwwroot, not done db
        [Route("uploadManyImageszszs")]
        public async Task<IActionResult> UploadImagezzs(List<IFormFile> files)
        {
            try
            {
                var uploadedFiles = new List<string>();

                foreach (var file in files)
                {
                    if (file != null && file.Length > 0)
                    {
                        // Tạo thư mục "allPhotoUploaded" nếu nó không tồn tại
                        string uploadFolder = "allPhotoUploaded";
                        string folderPath = Path.Combine(_hostingEnvironment.WebRootPath, uploadFolder);

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        // Tạo tên tệp duy nhất bằng cách sử dụng Guid và đuôi mở rộng
                        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                        string filePath = Path.Combine(folderPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        uploadedFiles.Add(fileName);
                    }
                }

                return Ok(new { Message = "Tải lên thành công", Files = uploadedFiles });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi: {ex.Message}");
            }
        }
        // update many images
        [HttpPut] // DONE wwwroot, not done db
        [Route("updateImages")]
        public async Task<IActionResult> UpdateImages(List<IFormFile> files)
        {
            try
            {
                // Bước 1: Lấy danh sách các tệp ảnh cũ trong thư mục "allPhotoUploaded"
                string uploadFolder = "allPhotoUploaded";
                string folderPath = Path.Combine(_hostingEnvironment.WebRootPath, uploadFolder);

                if (Directory.Exists(folderPath))
                {
                    // Bước 2: Xóa toàn bộ tệp ảnh cũ trong thư mục "allPhotoUploaded"
                    Directory.Delete(folderPath, true);
                }

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var uploadedFiles = new List<string>();

                foreach (var file in files)
                {
                    if (file != null && file.Length > 0)
                    {
                        // Bước 3: Lưu tệp ảnh mới từ dữ liệu PUT vào thư mục "allPhotoUploaded"
                        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                        string filePath = Path.Combine(folderPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        uploadedFiles.Add(fileName);
                    }
                }

                // Bước 4: Trả về danh sách tên tệp ảnh sau khi đã cập nhật
                return Ok(new { Message = "Cập nhật ảnh thành công", Files = uploadedFiles });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi: {ex.Message}");
            }
        }
    }
}
