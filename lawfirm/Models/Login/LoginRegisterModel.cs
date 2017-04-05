namespace lawfirm.Models.Login
{
    public class LoginRegisterModel
    {
        public Register RegisterModel { get; set; }
        public Login LoginModel { get; set; }
    }

    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}