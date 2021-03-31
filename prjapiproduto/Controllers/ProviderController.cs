using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using prjapiproduto.Models;
using prjapiproduto.Services;

namespace prjapiproduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly ProviderServices _providerServices;

        public ProviderController(ProviderServices productServices){
            _providerServices = productServices;
        }

        [HttpGet]
        public ActionResult<List<Provider>> Get() => _providerServices.Get();

        [HttpGet("{id:length(24)}", Name = "GetFornecedor")]
        public ActionResult<Provider> Get(string id)
        {
            var fornecedor = _providerServices.Get(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return fornecedor;
        }

        [HttpPost]
        public ActionResult<Provider> Create(Provider fornecedor)
        {
            _providerServices.Create(fornecedor);

            return CreatedAtRoute("GetFornecedor", new { id = fornecedor.Id.ToString() }, fornecedor);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Provider fornecedorIn)
        {
            var fornecedor = _providerServices.Get(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            _providerServices.Update(id, fornecedorIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var fornecedor = _providerServices.Get(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            _providerServices.Remove(fornecedor.Id);

            return NoContent();
        }
    }
}