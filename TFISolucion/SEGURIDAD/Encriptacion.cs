using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TFI.SEGURIDAD
{
    public class Encriptacion
    {

        public static string Llave()
        {
            return "TFI2016";
        }


        private static TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

        private static Random random = new Random((int)DateTime.Now.Ticks);

        private static MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        public static byte[] MD5Hash(string value)
        {

            return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value));

        }

        public static string Encriptar(string stringToEncrypt, string key)
        {

            DES.Key = MD5Hash(key);

            DES.Mode = CipherMode.ECB;

            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt);

            return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));

        }

        public static string Desencriptar(string encryptedString, string key)
        {
            try
            {
                DES.Key = MD5Hash(key);
                DES.Mode = CipherMode.ECB;
                byte[] Buffer = Convert.FromBase64String(encryptedString);
                return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The encryption key specified was not appropriate for decryption.", "Invalid Enryption Key", MessageBoxButtons.OK, MessageBoxIcon.Information)
                throw ex;


            }

        }
    }
}
