using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ExcelImportApi.Services
{
    public interface IExcelImportService
    {
        Task<int> ImportExcelAsync(IFormFile file);
    }
}
