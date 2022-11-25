namespace APIApps.Models
{
    public class RegisterUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
    public class LoginUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class SecureResponse
    {
        public string? UserName { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public string? Token { get; set; }
    }

}
