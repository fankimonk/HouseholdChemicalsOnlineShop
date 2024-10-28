namespace DataAccess.Models
{
    public class CategoryEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<ProductEntity> Products { get; set; } = [];
    }
}
