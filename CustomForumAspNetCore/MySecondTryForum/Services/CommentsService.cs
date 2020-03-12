using MySecondTryForum.Data;
using MySecondTryForum.Models;
using MySecondTryForum.ViewModels.Comments;
using System;
using System.IO;
using System.Linq;

namespace MySecondTryForum.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ApplicationDbContext db;

        public CommentsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateComment(string name,CommentReplyViewModel model)
        {
            string userId = this.GetUserId(name);
            Comment comment = new Comment()
            {
                ApplicationUserId = userId,
                TopicId = model.TopicId,
                Image = model.Image,
                Content = model.Content,
                IsDeleted = false,
                PostedOn = DateTime.UtcNow,
            };

            db.Comments.Add(comment);
            db.SaveChanges();

            //TODO: Validate images
            if (model.Image != null)
            {
                using (var stream = new FileStream(@$"D:\ImagesFromMyForum\{comment.Id}.jpeg", FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }
            }
        }

        public TopicCommentsViewModel TopicAllComents(int topicId)
        {
            //TODO: Display the fking image
            string imgPath = @"./../../../ImagesFromMyForum/";

            TopicCommentsViewModel model = db.Topics
                .Where(t => t.Id == topicId)
                .Select(t => new TopicCommentsViewModel
                {
                    Creator = t.ApplicatuinUser.UserName,
                    CreatedOn = t.OpenedOn,
                    Header = t.Header,
                    Comments = t.Comments.Where(c => c.TopicId == topicId)
                                .Select(c => new CommentViewModel
                                {
                                    ImagePath = imgPath + c.Id + ".jpeg",
                                    CommentId = c.Id,
                                    PostedOn = c.PostedOn,
                                    Content = c.Content,
                                    Username = c.ApplicationUser.UserName,
                                })
                                .ToList()
                })
                .FirstOrDefault();

            return model;
        }

        private string GetUserId(string name)
        {
            return this.db.Users.Where(u => u.UserName == name).Select(u => u.Id).FirstOrDefault();
        }
    }
}
