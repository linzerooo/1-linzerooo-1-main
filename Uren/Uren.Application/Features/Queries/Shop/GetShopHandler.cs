using Finate.Application.Features.Queries.Account.GetMyProfile;
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
    public class GetShopHandler : IRequestHandler<GetShop, List<ShopModel>>
    {
        private readonly IDbContext _dbContext;

        public GetShopHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ShopModel>> Handle(GetShop request, CancellationToken cancellationToken)
        {
            var cards = await _dbContext.ProductCard.ToListAsync(cancellationToken);

            return cards.Select(card => new ShopModel
            {
                Id = card.Id,
                CardName = card.CardName,
                Description = card.Description,
                ImageSrc = card.ImageSrc,
                Price = card.Price,
            }).ToList();
        }
    }
}
