using Sales.Application.SalesService.Models.Request;
using Sales.Application.SalesService.Models.Response;
using Sales.Application.SalesService.Service;
using Microsoft.AspNetCore.Mvc;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : BaseController
    {
        private readonly ISalesService _service;

        public SalesController(ILogger<SalesController> logger, ISalesService service) : base()
        {
            _service = service;
        }

        [HttpGet("getOrder")]
        public async Task<IActionResult> GetOrder()
        {
            try
            {
                var action = await _service.GetAllOrderAsync();
                return Ok(action);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet("getOrderItems")]
        public async Task<IActionResult> GetOrderItems()
        {
            try
            {
                var action = await _service.GetAllOrderItemsAsync();
                return Ok(action);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet("getProduct")]
        public async Task<IActionResult> GetProduct()
        {
            try
            {
                var action = await _service.GetAllProductAsync();
                return Ok(action);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var action = await _service.GetByIdAsync(id);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderRequest request)
        {
            try
            {
                var action = await _service.CreateAsync(request);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateSalesRequest request)
        {
            try
            {
                var action = await _service.UpdateAsync(id, request);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var action = await _service.DeleteAsync(id);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }
    }
}
