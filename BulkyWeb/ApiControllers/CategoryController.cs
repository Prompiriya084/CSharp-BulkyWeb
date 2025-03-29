using Azure.Core;
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
    [Authorize(Roles = "TS001")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly _ISerilog _serilog;
        public CategoryController(IUnitOfWork unitOfWork, _ISerilog serilog)
        {
            _unitOfWork = unitOfWork;
            _serilog = serilog;
        }
        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                int parsedId;
                if (!int.TryParse(id, out parsedId))
                {
                    return BadRequest();
                }
                var product = _unitOfWork.Category.Get(x => x.Id == parsedId && x.DeletedDate == null);

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
        public async Task<IActionResult> GetAllById(string id)
        {
            try
            {
                int parsedId;
                if (!int.TryParse(id, out parsedId))
                {
                    return BadRequest();
                }
                var product = _unitOfWork.Category.GetAll(x => x.Id == parsedId)
                    .Where(x => x.DeletedDate == null)
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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var product = _unitOfWork.Category.GetAll()
                    .Where(x => x.DeletedDate == null)
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
        public async Task<IActionResult> Add([FromBody] CategoryRequest request)
        {
            try
            {
                var date = DateTime.Now;
                var category = new Category();
                category.Id = 1; //Mock data for example
                category.Name = request.Name;
                category.CreatedDate = date;
                category.UpdatedDate = date;

                _unitOfWork.Category.Add(category);
                await _unitOfWork.SaveAsync();

                _serilog.LogInformation($"INSERT INTO Categories | Obj : {JsonConvert.SerializeObject(category)}");

                return Ok(new
                {
                    message = "success"
                });
            }
            catch (Exception ex)
            {
                _serilog.LogError(ex.Message);
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] CategoryRequest request)
        {
            try
            {
                var category = _unitOfWork.Category.Get(x => x.Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                var dateNow = DateTime.Now;
                category.Name = request.Name;
                category.UpdatedDate = dateNow;

                _unitOfWork.Category.Update(category);
                await _unitOfWork.SaveAsync();

                _serilog.LogInformation($"UPDATE Categories | Obj : {JsonConvert.SerializeObject(category)}");
                return Ok(new
                {
                    message = "updated successfully."
                });
            }
            catch (Exception ex)
            {
                _serilog.LogError(ex.Message);
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
                var category = _unitOfWork.Category.Get(x => x.Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                var dateNow = DateTime.Now;
                category.DeletedDate = dateNow;

                _unitOfWork.Category.Update(category);
                await _unitOfWork.SaveAsync();

                _serilog.LogInformation($"(SOFT DELETE)UPDATE Categories | Obj : {JsonConvert.SerializeObject(category)}");
                return Ok(new
                {
                    message = "deleted successfully."
                });
            }
            catch (Exception ex)
            {
                _serilog.LogError(ex.Message);
                return StatusCode(500, new
                {
                    message = ex.Message,
                });
            }
        }
    }
}
