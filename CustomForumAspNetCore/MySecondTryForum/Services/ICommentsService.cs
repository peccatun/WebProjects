using MySecondTryForum.ViewModels.Comments;
using System.Threading.Tasks;

namespace MySecondTryForum.Services
{
    public interface ICommentsService
    {
        void CreateComment(string name, CommentReplyViewModel model);

        AllCommentsViewModel TopicAllComents(int topicId);
    }
}
