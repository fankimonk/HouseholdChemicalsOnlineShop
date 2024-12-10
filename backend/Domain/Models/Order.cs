namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string ShippingAddress { get; set; } = string.Empty;

        public int CartId { get; set; }
        public Cart? Cart { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } = [];
    }

}
