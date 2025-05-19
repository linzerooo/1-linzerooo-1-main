using MediatR;
using Shared.Requests.Account.GetMyProfile;
using Shared.Requests.Shop.GetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Queries.Shop
{
    public class GetShop : IRequest<List<ShopModel>>;
}
