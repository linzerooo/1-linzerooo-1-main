using Finate.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Commands.Card
{
    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand, Unit>
    {
        private readonly IDbContext _dbContext;

        public RemoveFromCartCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {

            var cartItem = _dbContext.CartItem.Where(c => c.ProductCard.Id == request.CardId).FirstOrDefault();
       
            if (cartItem != null)
            {
                _dbContext.CartItem.Remove(cartItem);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
