using ClothingApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Interfaces
{
    public class CommonInterface
    {
        public ICartRepository _cartRepository = new CartService();
        public IUserRepository _userRepository = new UserService();
        public IProductRepository _productRepository = new ProductService();
        public ICartDetailRepository _cartDetailRepository = new CartDetailService();
        public IOrderRepository _orderRepository = new OrderService();
        public IOrderDetailRepository _orderDetailRepository
 = new OrderDetailService();
    }
}
