using System;
using System.Security.Cryptography;

namespace WinEI.Utils
{
    internal class CryptoUtils
    {
        /// <summary>
        /// Calculates the SHA256 hash of a byte array.
        /// </summary>
        /// <param name="sourceBytes">The byte array to calculate the hash for.</param>
        /// <returns>The SHA256 checksum of the byte array.</returns>
        internal static string GetSha256Digest(byte[] sourceBytes)
        {
            using (SHA256 provider = SHA256.Create())
            {
                byte[] digestBytes =
                    provider.ComputeHash(
                        sourceBytes);

                return BitConverter.ToString(
                    digestBytes).Replace("-", "").ToLower();
            }
        }
    }
}