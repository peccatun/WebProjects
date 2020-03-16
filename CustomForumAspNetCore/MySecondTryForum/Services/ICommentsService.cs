using MySecondTryForum.ViewModels.Comments;
using System.Threading.Tasks;

namespace MySecondTryForum.Services
{
    public interface ICommentsService
    {
        Task CreateCommentAsync(string name, CommentReplyViewModel model);

        AllCommentsViewModel TopicAllComents(int topicId);

        bool Delete(string userId, int commentId);
    }
}
