using System.ComponentModel.DataAnnotations;

namespace ShareMemoriesHub.Models.Authentication
{
    public class Register
    {
        [Required(ErrorMessage ="Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Is Required")]
        public string Password { get; set; }
    }
}
