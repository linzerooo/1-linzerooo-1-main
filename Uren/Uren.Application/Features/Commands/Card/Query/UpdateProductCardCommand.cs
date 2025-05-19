using MediatR;
using System;

namespace Finate.Application.Features.Commands.Shop
{
    public class UpdateProductCardCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string CardName { get; set; }
        public string Description { get; set; }
        public List<string> ImageSrc { get; set; }
        public decimal Price { get; set; }
    }
}
