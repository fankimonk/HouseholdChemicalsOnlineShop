using API.Contracts.Product;

namespace API.Contracts.Order
{
    public record OrderResponse
    (
        int Id,
        DateTime OrderDate,
        decimal TotalPrice,
        string ShippingAddress,
        List<ProductResponse> Products
    );
}
