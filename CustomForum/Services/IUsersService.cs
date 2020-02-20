namespace CustomForum.Services
{
    using CustomForum.ViewModels.Users;
    public interface IUsersService
    {
        int? GetUserId(LoginUserViewModel input);

        void Register(RegisterUserViewModel input);
    }
}
