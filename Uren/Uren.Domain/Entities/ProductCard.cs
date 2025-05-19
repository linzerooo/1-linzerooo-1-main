using Finate.Domain.Entities;

namespace Finate.Application.Interfaces
{
    public class ProductCard
    {
        public Guid Id { get; set; }
        public string CardName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<string> ImageSrc { get; set; } = new List<string>();
    }
}