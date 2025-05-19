using Finate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public ProductCard ProductCard { get; set; }
        public int Quantity { get; set; }
    }
}
