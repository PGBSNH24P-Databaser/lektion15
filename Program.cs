using System.Security.Cryptography;
using System.Text;

namespace lektion15;

class Program
{
    static void Main(string[] args)
    {
        string password = "secure-password";
        // Generate salt
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        using (HashAlgorithm algorithm = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] fullBytes = passwordBytes.Concat(salt).ToArray();
            byte[] hash = algorithm.ComputeHash(fullBytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
                sb.Append(b.ToString("X2"));

            string hashedPassword = sb.ToString();

            Console.WriteLine(hashedPassword);
        }
    }
}
