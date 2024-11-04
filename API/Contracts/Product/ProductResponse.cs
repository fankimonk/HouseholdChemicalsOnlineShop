namespace API.Contracts.Product
{
    public record ProductResponse(
        int Id,
        string Name,
        string Description,
        string ImageURL,
        decimal Price,
        int StockQuantity,
        int CategoryId,
        int BrandId
        );
}
