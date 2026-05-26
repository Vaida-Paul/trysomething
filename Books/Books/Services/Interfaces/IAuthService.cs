using Books.Models.DTOs;

namespace Books.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<string> LoginAsync(LoginRequestDTO loginRequestDTO);
        public Task RegisterAsync(RegisterRequestDTO registerRequestDTO);
    }
}
