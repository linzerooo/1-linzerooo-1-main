using MediatR;
using Finate.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Finate.Application.Features.Commands.Shop
{
    public class UpdateProductCardCommandHandler : IRequestHandler<UpdateProductCardCommand, Unit>
    {
        private readonly IDbContext _dbContext;

        public UpdateProductCardCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProductCardCommand request, CancellationToken cancellationToken)
        {
            var productCard =  _dbContext.ProductCard.Where(c => c.CardName == request.CardName).ToList().FirstOrDefault();

            if (productCard != null)
            {
                productCard.CardName = request.CardName;
                productCard.Description = request.Description;
                productCard.ImageSrc = request.ImageSrc;
                productCard.Price = request.Price;

                _dbContext.ProductCard.Update(productCard);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
