using static BCrypt.Net.BCrypt;

namespace DataAccess.Helper
{
    public static class PasswordHelper
    {
        public static string CreateHashPassword(string password)
        {
            return HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return Verify(password, hashedPassword);
        }
    }
}
