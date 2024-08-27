using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Shared.Dto;
using PTS.Application.Dto;
using PTS.Domain.Entities;
using PTS.Application.Interfaces.Repositories;
using OfficeOpenXml;
using PTS.Application.Features.Serial.Commands;
using PTS.Application.Features.Serial.Queries;

namespace PTS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerialController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SerialController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new SerialGetAllQuery()));
        }
        [HttpPost("GetByCodeProductDetail")]
        public async Task<IActionResult> GetByCodeProductDetail(SerialGetByCodeProductDetailQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetPage")]
        public async Task<IActionResult> GetPage(SerialGetPageQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(SerialGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(SerialCreateOrUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(SerialUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteSerial(SerialDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { status = "error", message = "Tệp không hợp lệ" });

            List<SerialEntity> list = new List<SerialEntity>();
            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount++; row++)
                        {
                            var serialNumberCell = worksheet.Cells[row, 1].Value;
                            var codeCell = worksheet.Cells[row, 2].Value;

                            if (serialNumberCell == null || string.IsNullOrWhiteSpace(serialNumberCell.ToString()))
                                continue;

                            if (codeCell == null || string.IsNullOrWhiteSpace(codeCell.ToString()))
                                continue;

                            string serialNumber = serialNumberCell.ToString().Trim();
                            string code = codeCell.ToString().Trim();
                            var existingSerial = await _unitOfWork._serialRepository
                                .FindBySerialNumberAsync(serialNumber);

                            if (existingSerial != null)
                                continue;

                            var idProductDetail = await _unitOfWork._productDetailRepository.GetIdByCode(code);
                            if (idProductDetail != null)
                            {
                                var serial = new SerialEntity
                                {
                                    SerialNumber = serialNumber,
                                    CrDateTime = DateTime.Now,
                                    Status = 1,
                                    ProductDetailEntityId = idProductDetail
                                };
                                list.Add(serial);
                            }
                        }

                        if (list.Any())
                        {
                            await _unitOfWork._serialRepository.CreateMany(list);
                            return Ok(new { status = "success", message = "Tệp đã được tải lên và xử lý thành công." });
                        }
                        else
                        {
                            return BadRequest(new { status = "error", message = "Không có dữ liệu hợp lệ để xử lý." });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = "Đã xảy ra lỗi trong quá trình xử lý tệp: " + ex.Message });
            }
        }


        [HttpPost("CreateMany")]
        public async Task<IActionResult> CreateMany(List<SerialDto> listObjDto)
        {
            var listObj = _mapper.Map<List<SerialEntity>>(listObjDto);
            return Ok(await _unitOfWork._serialRepository.CreateMany(listObj));
        }
    }
}
