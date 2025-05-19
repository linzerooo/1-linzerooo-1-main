using Finate.Application.Features.Commands.Card.Query;
using Finate.Application.Interfaces;
using Finate.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Queries.Cart
{
    public class GetCartItemsHandler : IRequestHandler<GetCartItemsQuery, List<CartItem>>
    {
        private readonly IDbContext _dbContext;

        public GetCartItemsHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CartItem>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            var cartItems = await _dbContext.CartItem
                .Include(ci => ci.ProductCard)  // Ensure the ProductCard is included
                .ToListAsync(cancellationToken);

            return cartItems;
        }
    }

}
