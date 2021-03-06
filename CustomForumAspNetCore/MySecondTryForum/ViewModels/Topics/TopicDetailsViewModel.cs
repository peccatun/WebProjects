﻿using System;

namespace MySecondTryForum.ViewModels.Topics
{
    public class TopicDetailsViewModel
    {
        public int TopicId { get; set; }

        public string TopicName { get; set; }

        public string CreatorName { get; set; }

        public DateTime CreateOn { get; set; }

        public int Comments { get; set; }

        public int Posters { get; set; }

        public bool IsDeleted { get; set; }
    }
}
