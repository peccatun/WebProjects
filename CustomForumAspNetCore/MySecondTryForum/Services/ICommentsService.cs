using MySecondTryForum.ViewModels.Comments;

namespace MySecondTryForum.Services
{
    public interface ICommentsService
    {
        void CreateComment(string name, CommentReplyViewModel model);

        TopicCommentsViewModel TopicAllComents(int topicId);
    }
}
