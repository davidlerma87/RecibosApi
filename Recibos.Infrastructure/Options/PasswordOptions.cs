using System;
using System.Collections.Generic;
using System.Text;

namespace Recibos.Infrastructure.Options
{
    public class PasswordOptions
    {
        
        public int SaltSize { get; set; }
        public int KeySize { get; set; }
        public int Iterations { get; set; }

        public PasswordOptions(int saltSize, int keySize, int iterations) 
        {
            this.SaltSize = saltSize;
            this.KeySize = keySize;
            this.Iterations = iterations;
        }
    }
}
