using Finate.Application.Interfaces;
using Finate.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Commands.Card.Query
{
    public class GetCartItemsQuery : IRequest<List<CartItem>>
    {
    }

}
