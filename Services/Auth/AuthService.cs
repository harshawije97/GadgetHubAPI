using System.Text;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Services.Auth
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthService(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<string?> LoginServiceAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user==null)
            {
                return null;
            }

            using var sha = SHA256.Create();
            var hash = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
            if (user.PasswordHash != hash)
            {
                return null;
            }

            return _jwtService.GenerateToken(user);
        }

        public async Task<User> ResgisterUserServiceAsync(string username, string password, string role)
        {
            using var sha = SHA256.Create();
            var hash = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = hash,
                Role = role
            };

            // Creating a new user  
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
