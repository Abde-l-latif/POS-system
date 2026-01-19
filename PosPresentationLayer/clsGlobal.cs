using Microsoft.Win32;
using PosBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PosPresentationLayer
{
    internal class clsGlobal
    {
        static public clsUsers User = new clsUsers();

        static public string GenerateProtectedKey()
        {
            byte[] keyBytes = new byte[16]; // AES-128
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(keyBytes);

            byte[] protectedKey = ProtectedData.Protect(
                keyBytes,
                null,
                DataProtectionScope.CurrentUser
            );

            return Convert.ToBase64String(protectedKey);
        }
   
        static public string HashPassword(string password)
        {
     
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                string hashedPass = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();

                return hashedPass;
            }
       
        }

        static public string AESencrypt(string data , string key)
        {
   
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("EncryptedAESKey is missing in App.config or registry.");
            }

            byte[] aesKey = ProtectedData.Unprotect(
               Convert.FromBase64String(key),
               null,
               DataProtectionScope.CurrentUser
           );

            string AESkey = Convert.ToBase64String(aesKey);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(AESkey);
                aes.IV = new byte[16];
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    sw.Write(data);
                    sw.Flush();
                    cs.FlushFinalBlock();

                    byte[] cipherBytes = ms.ToArray();
                    return Convert.ToBase64String(cipherBytes);
                }
            }

        }

        static public void RegisterAccount(string username , string password)
        {
            string registryPath = @"SOFTWARE\POS";
            string valueName1 = "Username";
            string valueName2 = "Password";
    

            RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);

            key.SetValue(valueName1, username, RegistryValueKind.String);
            key.SetValue(valueName2, password, RegistryValueKind.String);
            key.Close();

        }

        static public void RegisterKey(string Protectedkey)
        {
            string registryPath = @"SOFTWARE\POS";
            string valueName = "Key";
            RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);
            key.SetValue(valueName, Protectedkey, RegistryValueKind.String);
            key.Close();
        }

        static public void removeAccountFromRegistry()
        {
 
            string registryPath = @"Software\POS";

            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(registryPath, throwOnMissingSubKey: false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string DecryptAES(string data , string key)
        {   

            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("EncryptedAESKey is missing in App.config or registry.");
            }

            byte[] cipherBytes = Convert.FromBase64String(data);

            byte[] aesKey = ProtectedData.Unprotect(
                Convert.FromBase64String(key),
                null,
                DataProtectionScope.CurrentUser
            );


            using (Aes aes = Aes.Create())
            {
                aes.Key = aesKey;
                aes.IV = new byte[16];
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream(cipherBytes))
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
