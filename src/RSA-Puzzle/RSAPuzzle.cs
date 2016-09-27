using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace RSA_Puzzle
{
    public class RSAPuzzle
    {
        private RSAInfo info;

        public RSAPuzzle(string chavePublica, string corpoN, string mensagemCriptografada)
        {
            info = new RSAInfo();
            info.E = BigInteger.Parse(chavePublica);
            info.N = BigInteger.Parse(corpoN);
            info.C = BigInteger.Parse(mensagemCriptografada);
        }

        public RSAInfo Resolver()
        {
            info.P = AplicarPollardsRho(info.N);
            info.Q = info.N / info.P;

            info.PhiN = (info.P - 1) * (info.Q - 1);

            info.D = modInverso(info.E, info.PhiN);
            info.M = BigInteger.ModPow(info.C, info.D, info.N);

            info.Texto = converterParaASCII(info.M.ToString());

            return info;
        }


        private BigInteger AplicarPollardsRho(BigInteger n)
        {
            BigInteger x = new BigInteger(2);
            BigInteger factor = new BigInteger(1);
            BigInteger x_fixed = new BigInteger(2);
            int cycle_size = 2;

            while (factor == 1)
            {
                for (int count = 1; count <= cycle_size && factor <= 1; count++)
                {
                    x = (x * x + 1) % n;

                    factor = BigInteger.GreatestCommonDivisor(x - x_fixed, n);
                }

                cycle_size *= 2;
                x_fixed = x;
            }

            return factor;
        }

        private BigInteger modInverso(BigInteger e, BigInteger n)
        {
            BigInteger i = n, v = 0, d = 1;
            while (e > 0)
            {
                BigInteger t = i / e, x = e;
                e = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }

        private string converterParaASCII(string mensagem)
        {
            string letra = string.Empty;

            if (mensagem.Length > 0)
            {

                letra = mensagem.Length == 1 ? ((char)int.Parse(mensagem.Substring(0, 1))).ToString() : ((char)int.Parse(mensagem.Substring(0, 2))).ToString();

                return letra + converterParaASCII(mensagem.Length == 1 ? mensagem.Substring(1, mensagem.Length - 1) : mensagem.Substring(2, mensagem.Length - 2));
            }
            else
            {
                return letra;
            }
        }
    }
}
