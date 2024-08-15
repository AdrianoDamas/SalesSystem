using Sales.Domain.SalesAggregate;

namespace Sales.Application.SalesService.Models.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Payment { get; set; }

        public static explicit operator OrderDto(Domain.SalesAggregate.Order o)
        {
            return new OrderDto()
            {
                Id = o.Id,
                ClientName = o.ClientName,
                ClientEmail = o.ClientEmail,
                CreationDate = o.CreationDate,
                Payment = o.Payment,
            };
        }
    }
}
