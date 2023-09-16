using System.Security.Cryptography;

namespace QuickXorHash
{
    internal class HashHelper
    {
        public static string CalculateQuickXorHash(string inputFile)
        {
            // Open the file for reading
            using (FileStream fileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[4096]; // Read the file in 4KB chunks (adjust as needed)
                int bytesRead;

                // Create an instance of your QuickXorHash class
                using (var hasher = new QuickXorHash())
                {
                    // Read the file in chunks and update the hash
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        hasher.TransformBlock(buffer, 0, bytesRead, buffer, 0);
                    }

                    // Finalize the hash calculation
                    hasher.TransformFinalBlock(buffer, 0, 0);

                    // Get the hash value as a byte array
                    byte[] hashBytes = hasher.Hash;

                    // Convert the byte array to a Base64 string
                    return Convert.ToBase64String(hashBytes);
                }
            }
        }

        public static string CalculateSha1(string inputFile)
        {
            // Open the file for reading
            using (FileStream fileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            {
                using (SHA1 sha1 = SHA1.Create())
                {
                    // Compute the SHA-1 hash
                    byte[] hashBytes = sha1.ComputeHash(fileStream);

                    // Convert the byte array to a hexadecimal string
                    //return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                    return Convert.ToBase64String(hashBytes);
                }
            }
        }
    }
}
