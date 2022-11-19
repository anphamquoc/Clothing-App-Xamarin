using Backend_ClothingApp.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public interface IProductRepository
    {
        List<ProductVM> GetAll();
        ProductVM GetById(string id);
        ProductVM Create(AddProductModel productVM);
        bool Update(string id, UpdateProductModel productVM);
        bool Delete(string id);
    }
}
