using Sales.Domain.SalesAggregate;

namespace Sales.Application.SalesService.Models.Dtos
{
    public class OrderItemsDto
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }

        public static explicit operator OrderItemsDto(Domain.SalesAggregate.OrderItems i)
        {
            return new OrderItemsDto()
            {
                Id = i.Id,
                IdOrder = i.IdOrder,
                IdProduct = i.IdProduct,
                Quantity = i.Quantity,
            };
        }
    }
}
