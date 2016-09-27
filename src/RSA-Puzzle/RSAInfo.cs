using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace RSA_Puzzle
{
    public class RSAInfo
    {
        private BigInteger p, q, d, e, n, m, c, phiN;

        public BigInteger C
        {
            get
            {
                return c;
            }

            set
            {
                c = value;
            }
        }

        public BigInteger D
        {
            get
            {
                return d;
            }

            set
            {
                d = value;
            }
        }

        public BigInteger E
        {
            get
            {
                return e;
            }

            set
            {
                e = value;
            }
        }

        public BigInteger M
        {
            get
            {
                return m;
            }

            set
            {
                m = value;
            }
        }

        public BigInteger N
        {
            get
            {
                return n;
            }

            set
            {
                n = value;
            }
        }

        public BigInteger P
        {
            get
            {
                return p;
            }

            set
            {
                p = value;
            }
        }

        public BigInteger PhiN
        {
            get
            {
                return phiN;
            }

            set
            {
                phiN = value;
            }
        }

        public BigInteger Q
        {
            get
            {
                return q;
            }

            set
            {
                q = value;
            }
        }

        public string Texto
        {
            get;
            set;
        }
    }
}
