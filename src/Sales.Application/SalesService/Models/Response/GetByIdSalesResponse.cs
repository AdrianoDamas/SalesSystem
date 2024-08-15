using Sales.Application.Common;
using Sales.Application.SalesService.Models.Dtos;

namespace Sales.Application.SalesService.Models.Response
{
    public class GetByIdSalesResponse : BaseResponse
    {
        public OrderDto Order { get; set; }
        public OrderItemsDto OrderItems { get; set; }
        public ProductDto Product { get; set; }
    }
}
