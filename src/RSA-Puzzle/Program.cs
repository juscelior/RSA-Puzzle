using System;
using System.Diagnostics;
using System.Numerics;

namespace RSA_Puzzle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BigInteger p, q, d, e, n, m, c, phiN;

            e = BigInteger.Parse("107074310067384015279771780359");
            n = BigInteger.Parse("716986706621138193334849008809");
            c = BigInteger.Parse("609810477808753196933983953492");

            Stopwatch sw = new Stopwatch();

            sw.Start();
            p = AlgorithmPollardsRho(n);
            q = n / p;

            phiN = (p - 1) * (q - 1);

            d = modInverso(e, phiN);
            m = BigInteger.ModPow(c, d, n);
            sw.Stop();

            Console.WriteLine("Primo p: {0}", p);
            Console.WriteLine("Primo q: {0}", q);
            Console.WriteLine("N: {0}", n);
            Console.WriteLine("phi(N): {0}", phiN);
            Console.WriteLine("Pub_k: {0}", e);
            Console.WriteLine("Pri_k: {0}", d);
            Console.WriteLine("Texto Cifrado: {0}", c);
            Console.WriteLine("Mensagem: {0}", m);
            Console.WriteLine("Texto em claro: {0}", convertToASCII(m.ToString()));

            Console.WriteLine("Tempo total: {0:00}:{1:00}:{2:00}.{3:00}",
            sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds,
            sw.Elapsed.Milliseconds / 10);
            Console.ReadKey();
        }

        private static BigInteger AlgorithmPollardsRho(BigInteger n)
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

        static BigInteger modInverso(BigInteger e, BigInteger n)
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

        static string convertToASCII(string m)
        {
            string letra = string.Empty;

            if (m.Length > 0)
            {
                letra = ((char)int.Parse(m.Substring(0, 2))).ToString();

                return letra + convertToASCII(m.Substring(2, m.Length - 2));
            }
            else
            {
                return letra;
            }
        }
    }
}
