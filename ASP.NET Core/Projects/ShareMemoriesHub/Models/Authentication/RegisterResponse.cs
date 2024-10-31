namespace ShareMemoriesHub.Models.Authentication
{
    public class RegisterResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public bool hasErrors    {  get; set; }
        public Register User { get; set; }
    }
}
