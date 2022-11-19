using Backend_ClothingApp.Helpers;
using Backend_ClothingApp.Models.ProductModel;
using Backend_ClothingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<ProductVM> productVMs = _productRepository.GetAll();
                return Ok(new ApiResponse(true, productVMs));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(AddProductModel productVM)
        {
            try
            {
                return Ok(new ApiResponse(true, _productRepository.Create(productVM)));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{productId}")]
        public IActionResult GetById(string productId)
        {
            try
            {
                ProductVM productVM = _productRepository.GetById(productId);
                if (productVM == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy sản phẩm"));
                }

                return Ok(new ApiResponse(true, productVM));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(string productId, UpdateProductModel updateProductModel) {
            {
                try
                {
                    bool check = _productRepository.Update(productId, updateProductModel);

                    if (!check)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy sản phẩm để Update"));
                    }

                    return Ok(new ApiResponse(true, "Cập nhật thành công"));
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
                }
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProductById(string productId) {
            try
            {
                bool check = _productRepository.Delete(productId);
                if (!check)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse(false, "Không tìm thấy sản phẩm để xóa"));
                }

                return Ok(new ApiResponse(true, "Xóa thành công"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(false, ex.Message));
            }
        }
    }
}
