using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Models.CartModel
{
    public class AddCartModel
    {
        [Required]
        public Guid UserId { get; set; }
    }

    public class DeleteCartModel: AddCartModel
    {
        
    }
}
