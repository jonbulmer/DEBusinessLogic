using System;
using System.Security.Cryptography;

namespace ResourceFileServer.Providers
{
    /// <summary>
    /// code from:
    /// http://stackoverflow.com/questions/4892588/rngcryptoserviceprovider-random-number-review
    /// </summary>
    public class SecureRandom : RandomNumberGenerator

    {
        private readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();

        public override void GetBytes(byte[] data)
        {
            rng.GetBytes(data);
        }
    }
}
