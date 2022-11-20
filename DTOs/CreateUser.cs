using System.ComponentModel.DataAnnotations;

namespace Mi_Granjita_Paraiso.DTOs
{
    public class CreateUser
    {
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
