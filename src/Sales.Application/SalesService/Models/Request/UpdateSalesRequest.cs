namespace Sales.Application.SalesService.Models.Response
{
    public class UpdateSalesRequest
    {
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Payment { get; set; }
    }
}
