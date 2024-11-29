namespace API.Contracts.Product
{
    public record ProductResponse(
        int Id,
        string Name,
        string Description,
        string ImagePath,
        decimal Price,
        int StockQuantity,
        int CategoryId,
        int BrandId
        );
}
