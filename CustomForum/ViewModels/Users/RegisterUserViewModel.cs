namespace CustomForum.ViewModels.Users
{
    using System;

    public class RegisterUserViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
