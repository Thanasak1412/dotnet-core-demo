using System.Net;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_demo.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet("GetAllProduct")]
    public ActionResult<List<string>> GetAllProduct()
    {
        var products = new List<string>
        {
            "React",
            "Vue",
            "Angular"
        };

        return Ok(products);
    }

    [HttpGet("GetProductList")]
    public ActionResult<List<Product>> GetProductList()
    {
        var productList = new List<Product>()
        {
            new Product() { Id = 1, Name = "React", Price = 100 },
            new Product() { Id = 2, Name = "Angular", Price = 200 },
            new Product() { Id = 3, Name = "Vue", Price = 300 }
        };

        return Ok(productList);
    }

    [HttpPost("AddProduct")]
    public ActionResult<Product> AddProduct([FromBody] Product model)
    {
        return Ok(model);
    }

    [HttpGet("GetProductById/{id}")]
    public ActionResult<Product> GetProductById([FromRoute] int id)
    {
        var product = new Product()
        {
            Id = id,
            Name = "Vue",
            Price = 100
        };

        return Ok(product);
    }

    [HttpPost("GetProductsByCriteria")]
    public ActionResult<Product> GetProductByQuery([FromBody] Product model, [FromQuery] int id, [FromQuery] string category, [FromQuery] int page = 0, [FromQuery] int pageLength = 50)
    {
        var product = new Product()
        {
            Id = id,
            Name = model.Name,
            Price = model.Price
        };

        return Ok(new
        {
            product,
            category,
            page,
            pageLength
        });
    }

    [HttpPost("AddImageProduct")]
    public ActionResult<Product> AddImageProduct([FromForm] Product model)
    {
        var product = new Product()
        {
            Id = model.Id,
            Name = model.Name,
            Price = model.Price,
            Image = model.Image
        };

        return Ok(model);
    }

    [HttpPut("UpdateProduct/{id}")]
    public ActionResult<Product> UpdateProduct([FromRoute] int id, [FromBody] Product model)
    {
        var product = new Product()
        {
            Id = id,
            Name = model.Name,
            Price = model.Price,
            Image = model.Image
        };

        return Ok(product);
    }

    [HttpPost("AddProductAndCategory")]
    public ActionResult<Product> AddProductAndCategory([FromBody] Product model)
    {
        var product = new Product()
        {
            Id = model.Id,
            Name = model.Name,
            Price = model.Price,
            Image = model.Image,
            Category = model.Category
        };

        return Ok(product);
    }

    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Image { get; set; }
        public Category? Category { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}