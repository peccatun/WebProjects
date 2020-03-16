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
                .Where(t => t.IsClosed == false)
                .Select(t => new TopicDetailsViewModel
                {
                    TopicId = t.Id,
                    TopicName = t.Header,
                    CreatorName = t.ApplicatuinUser.UserName,
                    CreateOn = t.OpenedOn,
                    Posters = t.Comments
                    .Where(c => c.TopicId == id)
                    .Select(c => c.ApplicationUserId)
                    .Distinct()
                    .Count(),
                    Comments = t.Comments.Where(t => t.TopicId == id).Count(),
                    IsDeleted = t.IsClosed,
                })
                .FirstOrDefault();

            return topic;
        }

        public IEnumerable<TopicDetailsViewModel> AllTopics()
        {
            IEnumerable<TopicDetailsViewModel> topics = db.Topics
                .Where(t => t.IsClosed == false)
                .Select(t => new TopicDetailsViewModel
                {
                    TopicId = t.Id,
                    TopicName = t.Header,
                    CreatorName = t.ApplicatuinUser.UserName,
                    CreateOn = t.OpenedOn,
                    Comments = t.Comments.Where(c => c.TopicId == t.Id).Count(),
                    Posters = t.Comments.Where(c => c.TopicId == t.Id)
                    .Select(c => c.ApplicationUserId)
                    .Distinct()
                    .Count(),
                    IsDeleted = t.IsClosed,
                })
                .OrderByDescending(t => t.CreateOn.Date)
                .ThenByDescending(t => t.Comments)
                .ThenByDescending(t => t.Posters)
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

        public bool Delete(string userId, int topicId)
        {
            string applicationUserId = db.Topics
                .Where(t => t.Id == topicId)
                .Select(t => t.ApplicationUserId)
                .FirstOrDefault();

            if (applicationUserId == null)
            {
                return false;
            }

            if (userId != applicationUserId)
            {
                return false;
            }

            if (!db.Topics.Any(t => t.Id == topicId))
            {
                return false;
            }

            var topic = db.Topics.FirstOrDefault(t => t.Id == topicId);
            topic.IsClosed = true;
            topic.ClosedOn = DateTime.Now;
            db.SaveChanges();

            return true;
        }
    }
}
