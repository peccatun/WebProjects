namespace HealthyEnvironment.Areas.Administration.ViewModels.Categories
{
    public class CategoryDetailsViewModel
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsApproved { get; set; }
    }
}
