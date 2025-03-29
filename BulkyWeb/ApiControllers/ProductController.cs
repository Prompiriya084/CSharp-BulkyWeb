using BulkyWeb.Application.CustomLib.Files.Services;
using BulkyWeb.Application.CustomLib.Files.Services.Interfaces;
using BulkyWeb.Application.CustomLib.Interfaces;
using BulkyWeb.Application.Services.Interfaces;
using BulkyWeb.Domain.Models;
using BulkyWeb.Models.ViewModels;
using BulkyWeb.Services.Serilog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BulkyWeb.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly _ISerilog _serilog;
        private readonly ICustomLib _ctoLib;
        public ProductController(IUnitOfWork unitOfWork,
            _ISerilog serilog,
            ICustomLib customLib) 
        {
            _unitOfWork = unitOfWork;
            _serilog = serilog;
            _ctoLib = customLib;
        }
        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                int parsedId;
                if (!int.TryParse(id,out parsedId))
                {
                    return BadRequest();
                }
                var product = _unitOfWork.Product.Get(x => x.Id == parsedId && x.DeletedDate == null);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllByDate(string date)
        {
            try
            {
                //int parsedId;
                //if (!int.TryParse(id, out parsedId))
                //{
                //    return BadRequest();
                //}
                if (date.Length != 8)
                {
                    return BadRequest();
                }
                DateTime requestDate;
                if (DateTime.TryParseExact(date, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out requestDate))
                {
                    return BadRequest();
                }

                var product = _unitOfWork.Product.GetAll(x => x.CreatedDate == requestDate && x.DeletedDate == null)
                    .OrderByDescending(x => x.UpdatedDate);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(new
                {
                    data = product
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var product = _unitOfWork.Product.GetAll(x => x.DeletedDate == null)
                    .OrderByDescending(x => x.UpdatedDate);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductRequest request)
        {
            try
            {
                var date = DateTime.Now;
                var category = _unitOfWork.Category.Get(x => x.Id == request.CategoryId);
                if (category == null)
                {
                    return NotFound(new
                    {
                        message = "Category not found."
                    });
                }
                var product = new Product();
                product.Id = 1; //Mock data for example
                product.Name = request.Name;
                product.Price = request.Price;
                product.CreatedDate = date;
                product.UpdatedDate = date;
                product.CategoryId = request.CategoryId;

                _unitOfWork.Product.Add(product);
                await _unitOfWork.SaveAsync();

                _serilog.LogInformation($"INSERT INTO Products | Obj : {JsonConvert.SerializeObject(product)}");

                return Ok(new
                {
                    message = "Product added successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductRequest request)
        {
            try
            {
                var product = _unitOfWork.Product.Get(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                var dateNow = DateTime.Now;
                product.Name = request.Name;
                product.UpdatedDate = dateNow;

                _unitOfWork.Product.Update(product);
                await _unitOfWork.SaveAsync();

                _serilog.LogInformation($"UPDATE Products | Obj : {JsonConvert.SerializeObject(product)}");

                return Ok(new
                {
                    message = "updated successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = _unitOfWork.Product.Get(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                var dateNow = DateTime.Now;
                product.DeletedDate = dateNow;

                _unitOfWork.Product.Update(product);
                await _unitOfWork.SaveAsync();

                _serilog.LogInformation($"(SOFT DELETE)UPDATE Products | Obj : {JsonConvert.SerializeObject(product)}");
                return Ok(new
                {
                    message = "deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> SaveFiles([FromForm] FilesRequest request)
        {
            try
            {
                return Ok(new
                {
                    message = "saving successful."
                });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> ExportFile(string id)
        {
            try
            {
                byte[] fileData;
                string fileName = "product.xlsx";
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                int parsedId;
                if (!int.TryParse(id, out parsedId))
                {
                    return BadRequest();
                }

                var product = _unitOfWork.Product.GetAll(x => x.Id == parsedId && x.DeletedDate == null);

                //if (request.Format.ToLower() == "pdf")
                //{
                //    fileData = await _pdfService.ExportAsync(request);
                //    fileName = "export.pdf";
                //    contentType = "application/pdf";
                //}
                //else if (request.Format.ToLower() == "excel")
                //{
                //    fileData = await _excelService.ExportAsync(request);
                //    fileName = "export.xlsx";
                //    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //}
                //else
                //{
                //    return BadRequest("Invalid format. Use 'pdf' or 'excel'.");
                //}
                var excelFiles = await _ctoLib.File.Excel.ExportAsync<Product>(product);

                return File(excelFiles, contentType, fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }

    }
}
