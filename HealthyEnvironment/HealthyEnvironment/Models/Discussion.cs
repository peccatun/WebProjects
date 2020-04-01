using System;
using System.Collections.Generic;

namespace HealthyEnvironment.Models
{
    public class Discussion
    {
        public Discussion()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string About { get; set; }

        public string AdditionalInfo { get; set; }

        public byte[] Image { get; set; }

        public DateTime OpenedOn { get; set; }

        public DateTime? ClosedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<Solution> Solutions { get; set; } = new HashSet<Solution>();
    }
}
