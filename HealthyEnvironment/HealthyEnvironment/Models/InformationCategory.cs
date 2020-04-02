namespace HealthyEnvironment.Models
{
    public class InformationCategory
    {
        public string InformationId { get; set; }

        public Information Information { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
