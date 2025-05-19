using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Commands.Card
{
    public class AddToCartDto
    {
        public Guid ProductCardId { get; set; }
        public int Quantity { get; set; }
    }
}
