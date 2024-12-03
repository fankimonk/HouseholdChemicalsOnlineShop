namespace Domain.Models
{
    public class CartProduct
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }

        public Cart? Cart { get; set; }
        public Product? Product { get; set; }
    }
}
