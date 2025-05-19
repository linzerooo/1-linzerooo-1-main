using Finate.Application.Features.Commands.Card.Query;
using Finate.Application.Interfaces;
using Finate.Domain.Entities;
using MediatR;

public class AddToCartHandler : IRequestHandler<AddToCartCommand, Unit>
{
    private readonly IDbContext _dbContext;

    public AddToCartHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var productCard = await _dbContext.ProductCard.FindAsync(request.Dto.ProductCardId);


        CartItem cartItem = new CartItem
        {
            ProductCard = productCard,
            Quantity = request.Dto.Quantity
        };
        _dbContext.CartItem.Add(cartItem);

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
