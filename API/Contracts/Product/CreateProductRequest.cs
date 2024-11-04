namespace API.Contracts.Product
{
    public record CreateProductRequest(
        string Name,
        string Description,
        string ImageURL,
        decimal Price,
        int StockQuantity,
        int CategoryId,
        int BrandId
        );
}
