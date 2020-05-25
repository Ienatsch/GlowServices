using Microsoft.AspNetCore.DataProtection;

namespace GlowServices.Data
{
    public interface IEncryptionService
    {      
        public string Encrypt(string input);
        public string Decrypt(string encryptedText);
    }
}