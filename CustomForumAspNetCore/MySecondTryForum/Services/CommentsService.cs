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

            byte[] image = null;
            if (model.Image != null)
            {
                using (var stream = new MemoryStream())
                {
                    model.Image.CopyTo(stream);
                    image = stream.ToArray();
                }
            }

            Comment comment = new Comment()
            {
                ApplicationUserId = userId,
                TopicId = model.TopicId,
                Image = image,
                Content = model.Content,
                IsDeleted = false,
                PostedOn = DateTime.UtcNow,
            };
            
            db.Comments.Add(comment);
            db.SaveChanges();

            //TODO: Validate images
            
            
            
            
            
            
            
        }

        public TopicCommentsViewModel TopicAllComents(int topicId)
        {

            //string imgPath = @"~D:/ImagesFromMyForum/";
            TopicCommentsViewModel model = db.Topics
                .Where(t => t.Id == topicId)
                .Select(t => new TopicCommentsViewModel
                {
                    TopicId = topicId,
                    Creator = t.ApplicatuinUser.UserName,
                    CreatedOn = t.OpenedOn,
                    Header = t.Header,
                    Comments = t.Comments.Where(c => c.TopicId == topicId)
                                .Select(c => new CommentViewModel
                                {
                                    ImagePath = c.Image == null ? null : "data:image/png;base64," + Convert.ToBase64String(c.Image),
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
