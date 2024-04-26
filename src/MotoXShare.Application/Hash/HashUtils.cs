using System.Security.Cryptography;
using System.Text;

namespace MotoXShare.Application.Hash
{
    public static class HashUtils
    {
        public static string HashPassword(string password)
        {
            string initialSalt = "b147V2";
            string finalSalt = "cw@6492";
            password = initialSalt + password + finalSalt;

            byte[] encodedPassword = Encoding.UTF8.GetBytes(password);
            byte[] hashedPassword = MD5.HashData(encodedPassword);
            string fullPassword = Convert.ToBase64String(hashedPassword);

            if (fullPassword.Length > 30)
                fullPassword = fullPassword[..30];

            return fullPassword;
        }
    }
}