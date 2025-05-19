using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Queries.Shop.Commands
{
    public class CreateProductCardCommand : IRequest<Guid>
    {
        public string CardName { get; set; }
        public string Description { get; set; }
        public List<string> ImageSrc { get; set; } = new();
        public decimal Price { get; set; }
    }
}
