using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows;
using System.Security.Cryptography;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;


namespace AplikacjaSzyfrow.Views
{
    /// <summary>
    /// Interaction logic for RSAView.xaml
    /// </summary>
    public partial class RSAView : Window
    {
        public RSAView()
        {
            InitializeComponent();
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.Input.Text) || !String.IsNullOrEmpty(this.KeyPublic.Text))
            {             
                string xmlkey = $"<RSAKeyValue><Modulus>{this.KeyPublic.Text.ToString()}</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
                RSAParameters publicKey;

                using (RSA rsa = RSA.Create())
                {
                    rsa.FromXmlString(xmlkey);
                    publicKey = rsa.ExportParameters(false);
                }

                byte[] plainBytes = Encoding.UTF8.GetBytes(this.Input.Text.ToString());
                byte[] encryptedBytes;

                using (var rsa = RSA.Create())
                {
                    rsa.ImportParameters(publicKey);
                    encryptedBytes = rsa.Encrypt(plainBytes, RSAEncryptionPadding.Pkcs1);
                }
                string result = Convert.ToBase64String(encryptedBytes);
                this.Output.Text = result;
            }

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            this.Input.Text = "";
            this.Output.Text = "";
            this.KeyPublic.Text = "";
            this.KeyPrivate.Text = "";
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.Input.Text.ToString()) || !String.IsNullOrEmpty(this.KeyPrivate.Text.ToString()))
            {
                string xmlkey = $"<RSAKeyValue><Modulus>{this.KeyPrivate.Text.ToString()}</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
                RSAParameters privateKey;
                string result;

                using (RSA rsa = RSA.Create())
                {
                    rsa.FromXmlString(xmlkey);
                    privateKey = rsa.ExportParameters(false);
                }

                byte[] plainBytes = Encoding.UTF8.GetBytes(this.Input.Text.ToString());
                byte[] encryptedBytes;

                using (var rsa = RSA.Create())
                {
                    rsa.ImportParameters(privateKey);

                    int blockSize = rsa.KeySize / 8;
                    int encryptedBlockSize = blockSize - 11;
                    List<byte[]> decryptedBlocks = new List<byte[]>();

                    for (int i = 0; i < plainBytes.Length; i += encryptedBlockSize)
                    {
                        int remainingBytes = plainBytes.Length - i;
                        int currentBlockSize = remainingBytes < encryptedBlockSize ? remainingBytes : encryptedBlockSize;

                        byte[] currentBlock = new byte[currentBlockSize];
                        Array.Copy(plainBytes, i, currentBlock, 0, currentBlockSize);

                        byte[] decryptedBlock = rsa.Decrypt(currentBlock, RSAEncryptionPadding.Pkcs1);
                        decryptedBlocks.Add(decryptedBlock);
                    }

                    int totalLength = decryptedBlocks.Sum(b => b.Length);
                    byte[] decryptedMessage = new byte[totalLength];
                    int offset = 0;

                    foreach (byte[] block in decryptedBlocks)
                    {
                        Array.Copy(block, 0, decryptedMessage, offset, block.Length);
                        offset += block.Length;
                    }

                    result = Encoding.UTF8.GetString(decryptedMessage);
                    //encryptedBytes = rsa.Decrypt(plainBytes, RSAEncryptionPadding.Pkcs1);
                }
                // string result = Convert.ToBase64String(encryptedBytes);                
                this.Output.Text = result;
            }
        }

        private void GenerKey(object sender, RoutedEventArgs e)
        {
            using (RSA rsa = RSA.Create())
            {
                // Wygeneruj klucz publiczny i prywatny
                RSAParameters publicKey = rsa.ExportParameters(false);
                RSAParameters privateKey = rsa.ExportParameters(true);

                this.KeyPublic.Text = Convert.ToBase64String(publicKey.Modulus);
                this.KeyPrivate.Text = Convert.ToBase64String(privateKey.Modulus);
            }
        }

    
    }
}
