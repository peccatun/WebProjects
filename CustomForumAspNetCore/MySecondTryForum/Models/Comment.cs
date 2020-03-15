using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MySecondTryForum.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public DateTime PostedOn { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public byte[] Image { get; set; }

        public bool IsDeleted { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }




    }
}
