namespace HealthyEnvironment.ViewModels.Products
{
    public class ProductDetailsViewModel
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public string HeadImage { get; set; }

        public string[] AdditionalImageUrls { get; set; }
    }
}
