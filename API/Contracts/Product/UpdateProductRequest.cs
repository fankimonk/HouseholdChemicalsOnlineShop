namespace API.Contracts.Product
{
    public record UpdateProductRequest(
        string Name,
        string Description,
        string ImageURL,
        decimal Price,
        int StockQuantity,
        int CategoryId,
        int BrandId
        );
}
