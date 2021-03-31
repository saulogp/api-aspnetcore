using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using prjapiproduto.Models;
using prjapiproduto.Services;

namespace prjapiproduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _productServices;

        public ProductController(ProductServices productServices){
            _productServices = productServices;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get() => _productServices.Get();

        [HttpGet("{id:length(24)}", Name = "GetProduto")]
        public ActionResult<Product> Get(string id)
        {
            var produto = _productServices.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        public ActionResult<Product> Create(Product produto)
        {
            _productServices.Create(produto);

            return CreatedAtRoute("GetProduto", new { id = produto.Id.ToString() }, produto);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Product produtoIn)
        {
            var produto = _productServices.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            _productServices.Update(id, produtoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var produto = _productServices.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            _productServices.Remove(produto.Id);

            return NoContent();
        }
    }
}