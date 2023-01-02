using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mi_Granjita_Paraiso.DTOs
{
    public class CreateUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Phone { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        [PasswordPropertyText]
        public string PasswordConfirm { get; set; }
    }
}
