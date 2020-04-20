using HealthyEnvironment.ViewModels.Comments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyEnvironment.Services.Comments
{
    public interface ICommentsService
    {
        IEnumerable<CommentDetailsViewModel> GetCommentDetails(string informationId);

        Task<bool> CreateCommentAsync(CreateComentViewModel model);
    }
}
