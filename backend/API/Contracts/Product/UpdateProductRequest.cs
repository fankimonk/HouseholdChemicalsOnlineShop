namespace API.Contracts.Product
{
    public record UpdateProductRequest(
        string Name,
        string Description,
        string ImagePath,
        decimal Price,
        int StockQuantity,
        int CategoryId,
        int BrandId
        );
}
