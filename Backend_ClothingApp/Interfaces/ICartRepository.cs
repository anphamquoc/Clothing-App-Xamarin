using Backend_ClothingApp.Models.CartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public interface ICartRepository
    {
        CartVM GetByUserId(string UserId);
        CartVM Create(AddCartModel addCartModel);
        bool Delete(DeleteCartModel deleteCartModel);
    }
}
