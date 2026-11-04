
using System.Security.Cryptography;
using System.Text;

namespace Utilities.Helper
{
    public static class Hash
    {

        public static string HashValues(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Hash value cannot be null");

            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            byte[] hashByte = sha256.ComputeHash(bytes);

            return Convert.ToHexString(hashByte);
        }

        public static bool CompareHashValues(string value, string hashedValue)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(hashedValue))
                return false;

            string computedHash = HashValues(value);

            byte[] computedBytes = Convert.FromHexString(computedHash);
            byte[] storedBytes;

            try
            {
                storedBytes = Convert.FromHexString(hashedValue);
            }
            catch (FormatException)
            {
                return false;
            }

            return CryptographicOperations.FixedTimeEquals(
                computedBytes,
                storedBytes
            );
        }
    }
}
