namespace HealthyEnvironment.Models
{
    public class DiscussionCategory
    {
        //TODO: Decide what will you do with DiscussionCategory

        public string DiscussionId { get; set; }

        public Discussion Discussion { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
