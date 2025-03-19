using System;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionUtility
{
    private static byte[] GetValidKey(string key)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(key)).AsSpan(0, 32).ToArray(); // 32 bytes for AES-256
        }
    }

    public static string Encrypt(string plainText, string key)
    {
        byte[] keyBytes = GetValidKey(key);
        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.GenerateIV();
            byte[] iv = aes.IV;

            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                byte[] combinedBytes = new byte[iv.Length + encryptedBytes.Length];
                Buffer.BlockCopy(iv, 0, combinedBytes, 0, iv.Length);
                Buffer.BlockCopy(encryptedBytes, 0, combinedBytes, iv.Length, encryptedBytes.Length);

                return Convert.ToBase64String(combinedBytes);
            }
        }
    }

    public static string Decrypt(string encryptedText, string key)
    {
        byte[] keyBytes = GetValidKey(key);
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;

            byte[] iv = new byte[16];
            byte[] cipherText = new byte[encryptedBytes.Length - iv.Length];
            Buffer.BlockCopy(encryptedBytes, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(encryptedBytes, iv.Length, cipherText, 0, cipherText.Length);
            aes.IV = iv;

            using (ICryptoTransform decryptor = aes.CreateDecryptor())
            {
                byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
