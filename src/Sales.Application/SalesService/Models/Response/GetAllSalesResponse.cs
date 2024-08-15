using System.Collections.Generic;
using Sales.Application.Common;
using Sales.Application.SalesService.Models.Dtos;

namespace Sales.Application.SalesService.Models.Response
{
    public class GetAllSalesResponse: BaseResponse
    {
        public List<OrderDto> Orders { get; set; }
        public List<OrderItemsDto> OrdersItems { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
