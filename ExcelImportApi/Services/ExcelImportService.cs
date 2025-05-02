using ExcelDataReader;
using ExcelImportApi.Data;
using ExcelImportApi.Models;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace ExcelImportApi.Services
{
    public class ExcelImportService : IExcelImportService
    {
        private readonly AppDbContext _context;

        public ExcelImportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> ImportExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file.");

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using var stream = file.OpenReadStream();
            using var reader = ExcelReaderFactory.CreateReader(stream);
            var dataSet = reader.AsDataSet();
            var table = dataSet.Tables[0];

            var products = new List<Product>();

            for (int i = 1; i < table.Rows.Count; i++)
            {
                var name = table.Rows[i][0]?.ToString();
                var priceStr = table.Rows[i][1]?.ToString();

                if (!string.IsNullOrWhiteSpace(name) && decimal.TryParse(priceStr, out decimal price))
                {
                    products.Add(new Product
                    {
                        Name = name,
                        Price = price
                    });
                }
            }

            _context.Product.AddRange(products);
            await _context.SaveChangesAsync();

            return products.Count;
        }
    }
}
