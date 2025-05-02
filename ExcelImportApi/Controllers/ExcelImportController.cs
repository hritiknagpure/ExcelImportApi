using ExcelImportApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExcelImportApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExcelImportController : ControllerBase
    {
        private readonly IExcelImportService _excelService;

        public ExcelImportController(IExcelImportService excelService)
        {
            _excelService = excelService;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                var count = await _excelService.ImportExcelAsync(file);
                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
