using ShareMemoriesHub.Models.Authentication;

namespace ShareMemoriesHub.Interfaces
{
    public interface IUserFactory
    {
      Task <RegisterResponse> RegisterAsync(Register registerDto);
      Task <LoginResponse> LoginAsync(Login loginDto);
    }
}
