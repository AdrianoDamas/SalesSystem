namespace Sales.Domain.SalesAggregate
{
    public sealed class Product
    {
        private Product(string productName, decimal value)
        {
            this.ProductName = productName;
            this.Value = value;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Value { get; set; }

        public static Product Create(string productName, decimal value)
        {
            if (productName == null)
                throw new ArgumentException("Invalid " + nameof(productName));

            if (value == 0)
                throw new ArgumentException("Invalid " + nameof(value));


            return new Product(productName, value);
        }

        public void Update(string productName, decimal value)
        {
            if (productName != null)
                ProductName = productName;

            if (value != 0)
                Value = value;
        }
    }
}
