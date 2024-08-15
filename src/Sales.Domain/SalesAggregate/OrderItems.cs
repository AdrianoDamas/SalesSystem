namespace Sales.Domain.SalesAggregate
{
    public sealed class OrderItems
    {
        private OrderItems(int idOrder, int idProduct, int quantity)
        {
            this.IdOrder = idOrder;
            this.IdProduct = idProduct;
            this.Quantity = quantity;
        }

        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }

        public static OrderItems Create(int idOrder, int idProduct, int quantity)
        {
            if (idOrder == 0)
                throw new ArgumentException("Invalid " + nameof(idOrder));

            if (idProduct == 0)
                throw new ArgumentException("Invalid " + nameof(idProduct));


            return new OrderItems(idOrder, idProduct, quantity);
        }

        public void Update(int idOrder, int idProduct, int quantity)
        {
            if (idOrder != 0)
                IdOrder = idOrder;

            if (idProduct != 0)
                IdProduct = idProduct;

            Quantity = quantity;
        }
    }
}
