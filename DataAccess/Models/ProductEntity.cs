﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? ImageURL { get; set; } = string.Empty;

        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }

        public int BrandId { get; set; }
        public BrandEntity? Brand { get; set; }
    }
}