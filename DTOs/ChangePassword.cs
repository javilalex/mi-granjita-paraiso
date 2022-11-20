using System.ComponentModel;

namespace Mi_Granjita_Paraiso.DTOs
{
    public class ChangePassword
    {
        public string OldPassword { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        [PasswordPropertyText]
        public string PasswordConfirm { get; set; }
    }
}
