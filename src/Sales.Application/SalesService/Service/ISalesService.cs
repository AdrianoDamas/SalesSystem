using Sales.Application.SalesService.Models.Request;
using Sales.Application.SalesService.Models.Response;
using System.Threading.Tasks;

namespace Sales.Application.SalesService.Service
{
    public interface ISalesService
    {
        Task<GetAllSalesResponse> GetAllOrderAsync();
        Task<GetAllSalesResponse> GetAllOrderItemsAsync();
        Task<GetAllSalesResponse> GetAllProductAsync();
        Task<GetByIdSalesResponse> GetByIdAsync(int id);
        Task<CreateSalesResponse> CreateAsync(CreateOrderRequest request);
        Task<UpdateSalesResponse> UpdateAsync(int id, UpdateSalesRequest request);
        Task<DeleteSalesResponse> DeleteAsync(int id);
    }
}
