namespace Sales.Domain.SalesAggregate
{
    public sealed class Order
    {
        private Order(string clientName, string clientEmail, DateTime creationDate, bool payment)
        {
            this.ClientName = clientName;
            this.ClientEmail = clientEmail;
            this.CreationDate = creationDate;
            this.Payment = payment; 
        }

        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Payment { get; set; }

        public static Order Create(string clientName, string clientEmail, DateTime creationDate, bool payment)
        {
            if (clientName == null) 
                throw new ArgumentException("Invalid " + nameof(clientName));

            if (clientEmail == null)
                throw new ArgumentException("Invalid " + nameof(clientEmail));


            return new Order(clientName, clientEmail, creationDate, payment);
        }

        public void Update(string clientName, string clientEmail, DateTime creationDate, bool payment)
        {
            if (clientName != null)
                ClientName = clientName;

            if (clientEmail != null)
                ClientEmail = clientEmail;
        }
    }
}
