namespace Domain.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public List<CartProduct> CartProducts { get; set; } = [];
        public List<OrderProduct> OrderProducts { get; set; } = [];
    }
}
