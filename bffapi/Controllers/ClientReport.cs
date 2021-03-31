using System.Collections.Generic;
using System.Threading.Tasks;
using bffapi.Dto;
using bffapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace bffapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientReport
    {

        private DbServices _dbService;
        public ClientReport()
        {
            _dbService = new DbServices();
        }
        [HttpGet]
        public async Task<IEnumerable<ClientDto>> GetClientAsync()
        {
            return await _dbService.GetClientAsync();
        }

    }
}
