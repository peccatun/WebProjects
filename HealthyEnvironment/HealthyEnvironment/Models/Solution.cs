using System;

namespace HealthyEnvironment.Models
{
    public class Solution
    {
        public Solution()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Content { get; set; }

        public byte[] Image { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string DiscussionId { get; set; }

        public Discussion Discussion { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
