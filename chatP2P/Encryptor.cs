/*
 Encryptor Class
 by : Joao Araribá
 Date : 17.06.2023 v1
 */

using Sodium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace encryptingArariba
{
    internal class Encryptor
    {
        static private byte[] nonce = null;
        static private byte[] key = null;

        /// <summary>
        /// Encrpyt a string
        /// </summary>
        /// <param name="message">the text</param>
        /// <returns>the encrypted texte</returns>
        static public byte[] EncryptString(string message)
        {



            nonce = GenNonce;
            SodiumCore.Init();
            byte[] encrpytedMess = SecretBox.Create(message, nonce, key);


            //encrpytedMess.ToList<byte>().ForEach(aByte => { encryptedArea.Text += aByte; });

            return encrpytedMess;
        }



        /// <summary>
        /// Returns the original version of the texte
        /// </summary>
        /// <param name="encryptedMess">The encrypted message in an array of bytes</param>
        /// <returns>dsad</returns>
        static public string DecryptString(byte[] encryptedMess)
        {
            return Encoding.UTF8.GetString(SecretBox.Open(encryptedMess, nonce, key));
        }

        /// <summary>
        /// Return the hexadecimal version of the texte.
        /// </summary>
        /// <param name="byteMess">A texte in bytes</param>
        /// <returns>the message in hexadecimal</returns>
        static public string GetHexa(byte[] byteMess)
        {
            string hexaMess = BitConverter.ToString(byteMess);
            return hexaMess;
        }

        /// <summary>
        /// Generate the nonce if it's not generated yet or returns it if it exists/>
        /// </summary>
        static public byte[] GenNonce
        {
            get
            {
                if (nonce == null)
                {
                    return nonce = GenerateNonce();
                }
                else
                {
                    return nonce;
                }
            }
        }

        public static byte[] Key { get => key; set => key = value; }
        public static byte[] Nonce { set => nonce = value; }

        /// <summary>
        /// Set method of the attribute _key
        /// </summary>
        public static void SetKey()
        {
            if(key == null)
            {
                key = SecretBox.GenerateKey();
            }
        }

        /// <summary>
        /// Generate a 24 byte noce
        /// </summary>
        /// <returns>array of 24 bytes</returns>
        static private byte[] GenerateNonce()
        {
            Random rd = new Random();
            long nb64bits = rd.NextInt64();

            byte[] nonce = new byte[24];

            List<byte> keyList = new List<byte>();

            for (int j = 0; j < 3; j++)
            {
                long intereByte = nb64bits;
                for (int i = 1; i <= 8; i++)
                {
                    keyList.Add((byte)intereByte);
                    intereByte = (byte)(nb64bits >> 8 * i);
                }
            }

            nonce = keyList.ToArray();

            return nonce;
        }
    }
}
