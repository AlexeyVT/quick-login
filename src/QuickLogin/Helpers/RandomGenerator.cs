using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace QuickLogin.Helpers;

public static class RandomGenerator
{
    public static string CreateString(uint len)
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

        var random = CreateByteArray(len);

        var result = new char[len];
        for (var i = 0; i < len; i++)
        {
            result[i] = chars[random[i] % chars.Length];
        }

        return new string(result);
    }

    public static byte[] CreateByteArray(uint len)
    {
        var random = new byte[len];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(random);

        return random;
    }
}