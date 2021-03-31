using System.Collections.Generic;
using System.Threading.Tasks;
using bffapi.Dto;
using bffapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace bffapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReport
    {
        private DbServices _dbService;
        public ProductReport()
        {
            _dbService = new DbServices();
        }
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProductAsync()
        {
            return await _dbService.GetProductAsync();
        }

    }
}
