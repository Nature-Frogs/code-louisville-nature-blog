using System.ComponentModel.DataAnnotations;

namespace NatureBlog.Web.Models
{
    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
