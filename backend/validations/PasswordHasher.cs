using System.Security.Cryptography;
using Isopoh.Cryptography.Argon2;
using Isopoh.Cryptography.SecureArray;

public class PasswordHasher {

    public static byte[] GenerateSalt(int length = 25)
    {
        var salt = new byte[length];
        using (var rng = RandomNumberGenerator.Create()){
            rng.GetBytes(salt);
        }
        return salt;
    }
    public string HashPassword(string password, byte[] salt) {
        var config = new Argon2Config(){
            Type = Argon2Type.DataIndependentAddressing,
            Version = Argon2Version.Nineteen,
            TimeCost = 10,
            MemoryCost = 262144,
            Lanes = Environment.ProcessorCount,
            Threads = Environment.ProcessorCount,
            HashLength = 64,
            Password = System.Text.Encoding.UTF8.GetBytes(password),
            Salt = salt,
        };
        using (var argon2 = new Argon2(config))
        
        using (SecureArray<byte> hash = argon2.Hash())
        {
            return config.EncodeString(hash.Buffer);
        }
    }

    public bool verifyPassword(string password, string hashedPassword){
        return Argon2.Verify(hashedPassword, password);
    }
}