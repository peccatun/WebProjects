using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(30, MinimumLength =0)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
    }
}
