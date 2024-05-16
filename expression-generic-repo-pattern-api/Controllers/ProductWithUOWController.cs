using expression_generic_repo_pattern_api.Entity;
using expression_generic_repo_pattern_api.Interface;
using expression_generic_repo_pattern_api.VeiwModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace expression_generic_repo_pattern_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithUOWController(IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productRepository = unitOfWork.GetRepository<IProductRepository, Product>();
            var result = await productRepository.GetAllAsync();

            return Ok(result);

        }

       [HttpGet("productbyname")]
        public async Task<IActionResult> GetByName(string proudctName)
        {
            var productRepository = unitOfWork.GetRepository<IProductRepository, Product>();
            var result = await productRepository.GetProductsByName(proudctName);
            // var product = await unitOfWork.ProductRepository.GetProductsByName(proudctName);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequest product)
        {
            try
            {
                using var transaction = unitOfWork.BeginTransactionAsync();

                var productEnitity = new Product
                {
                    Price = product.Price,
                    ProductName = product.ProductName
                };
                var productRepository = unitOfWork.GetRepository<IProductRepository, Product>();
                var productrestul = await productRepository.AddAsync(productEnitity);

                await unitOfWork.SaveChangesAsync();

                var orderEntity = new Order
                {
                    OrderDate = DateTime.Now,
                    ProductId = productrestul.ProductId
                };

                await unitOfWork.GetRepository<Order>().AddAsync(orderEntity);
                await unitOfWork.SaveChangesAsync();

                await unitOfWork.CommitAsync();

                return StatusCode((int)HttpStatusCode.Created, new { Id = productrestul.ProductId });
            }
            catch (System.Exception)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
