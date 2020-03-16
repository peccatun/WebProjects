using MySecondTryForum.ViewModels.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySecondTryForum.Services
{
    public interface ITopicsService
    {
        int CreateTopic(CreateTopicViewModel input);

        TopicDetailsViewModel TopicDetails(int id);

        IEnumerable<TopicDetailsViewModel> AllTopics();

        bool Delete(string userId, int topicId);

        bool HasOpenedTopic(string header);

        bool HasTopic(int id);
    }
}
