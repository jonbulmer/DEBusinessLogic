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

        public int Next()
        {
            return 1;
        }

        public int Next(int maxValue)
        {
            return Next(0,maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException();
            }


            return (int)Math.Floor(minValue + ((double)maxValue - minValue) * NextDouble());
        }

        public double NextDouble()
        {
            return 1;
        }

        public override void GetBytes(byte[] data)
        {
            rng.GetBytes(data);
        }
    }
}
