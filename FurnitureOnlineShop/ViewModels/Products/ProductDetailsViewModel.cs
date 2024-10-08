﻿namespace FurnitureOnlineShop.ViewModels.Products
{
    public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public string Color { get; set; }

        public string SubCategory { get; set; }

        public int SubCategoryId { get; set; }
    }
}
