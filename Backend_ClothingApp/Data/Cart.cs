using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Data
{
    public class Cart
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public Cart()
        {
            CartDetails = new HashSet<CartDetail>();
        }
    }
}
