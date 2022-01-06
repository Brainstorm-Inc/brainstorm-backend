using System;
using System.Security.Cryptography;
using System.Text;

namespace Brainstorm.Business.Auth;

class Utils
{

    public static string GenerateSalt(int size)
    {
        var buff = RandomNumberGenerator.GetBytes(size);

        return Convert.ToBase64String(buff);
    }

    public static string GenerateSaltedHash(string plainText, string salt)
    {
        var algorithm = SHA256.Create();

        var plainTextWithSaltBytes = plainText + salt;

        var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(plainTextWithSaltBytes));

        return Convert.ToBase64String(hash);
    }
}
