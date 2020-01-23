using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;


namespace ServerDash
{
   public class RSAService
    {
        RSACryptoServiceProvider RSA = null;
        RSAParameters rsaParamsPublic;
        RSAParameters rsaParamsPrivate;

        
        
        public RSAParameters RSAParamsPrivate { get => rsaParamsPrivate; set => rsaParamsPrivate = value; }
        public RSAParameters RSAParamsPublic { get => rsaParamsPublic; set => rsaParamsPublic = value; }

        public RSAService() {

        }
        public RSACryptoServiceProvider GetRSA()
        {
            return this.RSA;
        }

       

        

        public String DisplayBytes(byte[] msg)
        {
            String str = "";
            foreach (var b in msg)
            {
                str += (char)b;
            }
            return str;
        }

        public void GenerateKeys()
        {
            this.RSA = new RSACryptoServiceProvider();
            this.rsaParamsPublic = this.RSA.ExportParameters(false);
            this.rsaParamsPrivate = this.RSA.ExportParameters(true);
        }
        
        public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData; 
                this.RSA.ImportParameters(RSAKey);
                encryptedData = this.RSA.Encrypt(Data, DoOAEPPadding);
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

            public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
            {
                try
                {
                    byte[] decryptedData;
                    
                    
                        RSA.ImportParameters(RSAKey);
                        decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                    
                    return decryptedData;
                }
                catch (CryptographicException e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
    }
