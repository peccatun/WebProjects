using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySecondTryForum.Data;
using MySecondTryForum.Models;
using MySecondTryForum.ViewModels.Topics;

namespace MySecondTryForum.Services
{
    public class TopicsService : ITopicsService
    {
        private readonly ApplicationDbContext db;

        public TopicsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int CreateTopic(CreateTopicViewModel input)
        {
            string appUserId = db.Users.Where(u => u.UserName == input.AppUserName)
                .Select(u => u.Id)
                .FirstOrDefault();

            Topic topic = new Topic()
            {
                ApplicationUserId = appUserId,
                Header = input.Header,
                OpenedOn = DateTime.UtcNow,
                IsClosed = false,
                
            };

            db.Topics.Add(topic);
            db.SaveChanges();

            int topicId = db.Topics
                .Where(t => t.IsClosed == false)
                .Where(t => t.Header == input.Header)
                .Select(t => t.Id)
                .FirstOrDefault();

            return topicId;
        }

        public TopicDetailsViewModel TopicDetails(int id)
        {
            TopicDetailsViewModel topic = db.Topics
                .Where(t => t.Id == id)
                .Select(t => new TopicDetailsViewModel
                {
                    TopicName = t.Header,
                    CreatorName = t.ApplicatuinUser.UserName,
                    CreateOn = t.OpenedOn,
                    Posters = t.Comments
                    .Where(c => c.TopicId == id)
                    .Select(c => c.ApplicationUserId)
                    .Distinct()
                    .Count(),
                    Comments = t.Comments.Where(t => t.TopicId == id).Count()
                })
                .FirstOrDefault();

            return topic;
        }

        public IEnumerable<TopicDetailsViewModel> AllTopics()
        {
            IEnumerable<TopicDetailsViewModel> topics = db.Topics
                .Select(t => new TopicDetailsViewModel
                {
                    TopicName = t.Header,
                    CreatorName = t.ApplicatuinUser.UserName,
                    CreateOn = t.OpenedOn,
                    Comments = t.Comments.Where(c => c.TopicId == t.Id).Count(),
                    Posters = t.Comments.Where(c => c.TopicId == t.Id)
                    .Select(c => c.ApplicationUserId)
                    .Distinct()
                    .Count(),
                })
                .ToList();



            return topics;
        }

        public bool HasOpenedTopic(string header)
        {
            return db.Topics.Where(t => t.IsClosed == false).Any(t => t.Header == header);
        }

        public bool HasTopic(int id)
        {
            return db.Topics.Any(t => t.Id == id);
        }
    }
}
