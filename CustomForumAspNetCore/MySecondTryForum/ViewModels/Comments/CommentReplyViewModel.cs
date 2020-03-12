using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySecondTryForum.ViewModels.Comments
{
    public class CommentReplyViewModel
    {
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public IFormFile Image { get; set; }

        public int TopicId { get; set; }
    }
}
