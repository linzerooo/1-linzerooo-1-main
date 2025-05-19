using Finate.Application.Features.Commands.Card.Query;
using Finate.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Commands.Card
{
    public class ClearCartHandler : IRequestHandler<ClearCartCommand, Unit>
    {
        private readonly IDbContext _dbContext;

        public ClearCartHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            var cartItems = _dbContext.CartItem.Where(c => c.Id == request.Id);
            _dbContext.CartItem.RemoveRange(cartItems);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
