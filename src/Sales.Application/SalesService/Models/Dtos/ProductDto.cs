using Sales.Domain.SalesAggregate;

namespace Sales.Application.SalesService.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Value { get; set; }

        public static explicit operator ProductDto(Domain.SalesAggregate.Product p)
        {
            return new ProductDto()
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Value =p.Value
            };
        }
    }
}
