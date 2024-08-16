using Sales.Application.Common;
using Sales.Application.SalesService.Models.Dtos;
using Sales.Application.SalesService.Models.Request;
using Sales.Application.SalesService.Models.Response;
using Sales.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sales.Domain.SalesAggregate;

namespace Sales.Application.SalesService.Service
{
    public class SalesService : BaseService<SalesService>, ISalesService
    {
        private readonly SalesContext _db;

        public SalesService(ILogger<SalesService> logger, Infra.Data.SalesContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllSalesResponse> GetAllOrderAsync()
        {
            var entity = await _db.Order.ToListAsync();
            return new GetAllSalesResponse()
            {
                Orders = entity != null ? entity.Select(a => (OrderDto)a).ToList() : []
            };
        }

        public async Task<GetAllSalesResponse> GetAllOrderItemsAsync()
        {
            var entity = await _db.OrderItems.ToListAsync();
            return new GetAllSalesResponse()
            {
                OrdersItems = entity != null ? entity.Select(a => (OrderItemsDto)a).ToList() : []
            };
        }

        public async Task<GetAllSalesResponse> GetAllProductAsync()
        {
            var entity = await _db.Product.ToListAsync();
            return new GetAllSalesResponse()
            {
                Products = entity != null ? entity.Select(a => (ProductDto)a).ToList() : []
            };
        }






        public async Task<GetByIdSalesResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdSalesResponse();

            var entity = await _db.Order.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Order = (OrderDto)entity;

            return response;
        }

        public async Task<CreateSalesResponse> CreateAsync(CreateOrderRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newOrder = Domain.SalesAggregate.Order.Create(request.ClientName, request.ClientEmail, request.CreationDate, request.Payment);

            _db.Order.Add(newOrder);

            await _db.SaveChangesAsync();

            return new CreateSalesResponse() { Id = newOrder.Id };
        }

        public async Task<UpdateSalesResponse> UpdateAsync(int id, UpdateSalesRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Order.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.ClientName, request.ClientEmail, request.CreationDate, request.Payment);
                await _db.SaveChangesAsync();
            }

            return new UpdateSalesResponse();
        }

        public async Task<DeleteSalesResponse> DeleteAsync(int id)
        {

            var entity = await _db.Order.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteSalesResponse();
        }
    }
}
