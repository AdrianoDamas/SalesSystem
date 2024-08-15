namespace Sales.Application.SalesService.Models.Request
{
    public class CreateOrderRequest
    {
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Payment { get; set; }
    }
}
