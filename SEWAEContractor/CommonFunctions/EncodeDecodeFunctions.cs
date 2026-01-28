using System.Text;
using SEWAEContractorCore.ExternalModels;

namespace SEWAEContractor.CommonFunctions
{
    public class EncodeDecodeFunctions
    {
        private readonly IConfiguration _configuration;
        public EncodeDecodeFunctions(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string getEncodedEncryptedText(string textToBeEncrypted)
        {
            try
            {
                string key = _configuration["CipherKey"];
                string keyValueUsed = _configuration["KeyValue"];
                byte[] keyValue = Convert.FromBase64String(keyValueUsed);
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(textToBeEncrypted);

                byte[] additionalData = Encoding.UTF8.GetBytes(key);

                // Encrypt the data
                var (ciphertext, tag, nonce) = AESGCMEncryption.Encrypt(keyValue, plaintextBytes, additionalData);

                // Encode the encrypted data for URL
                var urlSafeEncryptedText = AESGCMEncryption.EncodeEncryptedText(ciphertext, tag, nonce);
                return urlSafeEncryptedText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string removeSpecialCharactersInEncryptedText(string decodedEncryptedText)
        {
            try
            {
                bool fHasSpace = decodedEncryptedText.Contains(" ");
                bool fHasPlus = decodedEncryptedText.Contains("+");
                bool fHasEqual = decodedEncryptedText.Contains("=");
                if (fHasPlus)
                {
                    decodedEncryptedText = decodedEncryptedText.Replace("+", "%2b");
                }
                if (fHasEqual)
                {
                    decodedEncryptedText = decodedEncryptedText.Replace("=", "%3d");
                }
                if (fHasSpace)
                {
                    decodedEncryptedText = decodedEncryptedText.Replace(" ", "+");
                }
                return decodedEncryptedText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getDecryptedText(string decodedEncryptedText)
        {
            try
            {

                string key = _configuration["CipherKey"];
                string keyValueUsed = _configuration["KeyValue"];
                byte[] keyValue = Convert.FromBase64String(keyValueUsed);

                byte[] additionalData = Encoding.UTF8.GetBytes(key);
                string base64Decoded = System.Web.HttpUtility.UrlDecode(decodedEncryptedText); // URL decode
                byte[] combinedData = Convert.FromBase64String(base64Decoded);

                // Extract nonce, ciphertext, and tag from the combined data
                byte[] nonceExtracted = new byte[12];
                byte[] ciphertextExtracted = new byte[combinedData.Length - 28];
                byte[] tagExtracted = new byte[16];

                Buffer.BlockCopy(combinedData, 0, nonceExtracted, 0, nonceExtracted.Length);
                Buffer.BlockCopy(combinedData, nonceExtracted.Length, ciphertextExtracted, 0, ciphertextExtracted.Length);
                Buffer.BlockCopy(combinedData, nonceExtracted.Length + ciphertextExtracted.Length, tagExtracted, 0, tagExtracted.Length);

                //decryptedSubService = AESOperation.DecryptString(key, SubService);
                // Decrypt the text
                var decryptedSubService = AESGCMEncryption.Decrypt(ciphertextExtracted, tagExtracted, nonceExtracted, keyValue, additionalData);
                return decryptedSubService;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
