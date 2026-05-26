using Books.Data;
using Books.Models.DTOs;
using Books.Models.Entities;
using Books.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Books.Services
{
    public class AuthService : IAuthService
    {
        private readonly BooksDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthService(BooksDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<string> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginRequestDTO.Email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginRequestDTO.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            return GenerateJwtToken(user);
        }

        public async Task RegisterAsync(RegisterRequestDTO registerRequestDTO)
        {
            var exists = await _dbContext.Users.AnyAsync(u => u.Email == registerRequestDTO.Email);

            if (exists)
            {
                throw new InvalidOperationException("User with this email already exists.");
            }
            var user = new User
            {
                Name = registerRequestDTO.Name,
                Email = registerRequestDTO.Email
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, registerRequestDTO.Password);
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    int.Parse(_configuration["Jwt:ExpiresInMinutes"]!)
                ),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
