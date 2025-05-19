using Finate.Domain.Entities;
using Shared.Requests.Shop.GetShop;

namespace Finate.Web
{
    public class ShopViewModel
    {
        public List<ShopModel> ShopItems { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
