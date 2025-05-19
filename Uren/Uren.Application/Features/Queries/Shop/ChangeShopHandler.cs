using Finate.Application.Features.Queries.Account.GetMyProfile;
using Finate.Application.Features.Queries.Shop.Commands;
using Finate.Application.Features.Queries.Shop.Query;
using Finate.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Requests.Shop.GetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Queries.Shop
{
    public class ChangeShopHandler :
        IRequestHandler<GetProductCardQuery, ShopModel>,
        IRequestHandler<CreateProductCardCommand, Guid>,
        IRequestHandler<UpdateProductCardCommand, Unit>,
        IRequestHandler<DeleteProductCardCommand, Unit>
    {
        private readonly IDbContext _dbContext;

        public ChangeShopHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShopModel> Handle(GetProductCardQuery request, CancellationToken cancellationToken)
        {
            var card = await _dbContext.ProductCard.FindAsync(request.Id, cancellationToken);
            if (card == null) return null;

            return new ShopModel
            {
                Id = card.Id,
                CardName = card.CardName,
                Description = card.Description,
                ImageSrc = card.ImageSrc,
                Price = card.Price
            };
        }

        public async Task<Guid> Handle(CreateProductCardCommand request, CancellationToken cancellationToken)
        {
            var card = new ProductCard
            {
                Id = Guid.NewGuid(),
                CardName = request.CardName,
                Description = request.Description,
                ImageSrc = request.ImageSrc,
                Price = request.Price
            };

            _dbContext.ProductCard.Add(card);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return card.Id;
        }

        public async Task<Unit> Handle(UpdateProductCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _dbContext.ProductCard.FindAsync(request.Id, cancellationToken);
            if (card == null) throw new Exception("ProductCard not found");

            card.CardName = request.CardName;
            card.Description = request.Description;
            card.ImageSrc = request.ImageSrc;
            card.Price = request.Price;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteProductCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _dbContext.ProductCard.FindAsync(request.Id, cancellationToken);
            if (card == null) throw new Exception("ProductCard not found");

            _dbContext.ProductCard.Remove(card);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
