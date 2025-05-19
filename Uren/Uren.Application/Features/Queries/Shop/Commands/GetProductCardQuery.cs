using MediatR;
using Shared.Requests.Shop.GetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Queries.Shop.Query
{
    public class GetProductCardQuery : IRequest<ShopModel>
    {
        public Guid Id { get; set; }
    }
}
