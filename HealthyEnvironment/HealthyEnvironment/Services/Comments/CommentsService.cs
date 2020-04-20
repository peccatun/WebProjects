using HealthyEnvironment.Data;
using HealthyEnvironment.Models;
using HealthyEnvironment.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Comments
{
    public class CommentsService : ICommentsService
    {
        private readonly ApplicationDbContext dbContext;

        public CommentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateCommentAsync(CreateComentViewModel model)
        {
            if (!this.IsValidApplicationUserId(model.ApplicationUserId))
            {
                return false;
            }

            if (!this.IsValidInformationId(model.InformationId))
            {
                return false;
            }

            Comment comment = new Comment
            {
                ApplicationUserId = model.ApplicationUserId,
                InformationId = model.InformationId,
                Content = model.Content,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };

            await dbContext.Comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<CommentDetailsViewModel> GetCommentDetails(string informationId)
        {
            IEnumerable<CommentDetailsViewModel> comments = this.dbContext
                .Comments
                .Where(c => c.Information.Id == informationId)
                .Where(c => !c.IsDeleted)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new CommentDetailsViewModel
                {
                    CreatorUserName = c.ApplicationUser.UserName,
                    Content = c.Content,
                    CreatedOn = c.CreatedOn,
                    IsDeleted = c.IsDeleted,
                })
                .ToList();

            return comments;
        }

        private bool IsValidApplicationUserId(string applicationUserId)
        {
            return this.dbContext.Users.Any(u => u.Id == applicationUserId);
        }

        private bool IsValidInformationId(string informationId)
        {
            return this.dbContext.Information.Any(i => i.Id == informationId);
        }
    }
}
