using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.IRepository;
using ProductAPI.Model;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
         IProductRepository ProductRepository;

        public ProductController(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var Products = ProductRepository.GetAll();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public IActionResult GetById(int id)
        {
            var Product = ProductRepository.GetById(id);
            if (Product != null)
            {
                return Ok(Product);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.Create(product);
                return Created($"https://localhost:7272/api/Product/{product.Id}", product);

            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                var updatedProduct = ProductRepository.Update(product);
                if (updatedProduct != null)
                {
                    
                    updatedProduct.Name = product.Name;
                    updatedProduct.Description = product.Description;
                    updatedProduct.salary = product.salary;

                    return Ok(updatedProduct);
                }
                else
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }
        [HttpDelete]
            public IActionResult Delete(int id)
            {
            var deleted = ProductRepository.Delete(id);

            if (deleted != null)
                {
                    return Ok(deleted);
                }
                else
                {
                    return NotFound();
                }
            }
     }
}
