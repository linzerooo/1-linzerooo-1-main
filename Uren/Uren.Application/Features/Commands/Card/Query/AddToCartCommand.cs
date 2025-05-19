using Finate.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Commands.Card.Query
{
    public class AddToCartCommand : IRequest<Unit>
    {
        public AddToCartDto Dto { get; set; }
        public int Quantity { get; set; }
    }
}
