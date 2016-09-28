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
        private RSAPuzzleProfile profile;

        public RSAPuzzleProfile Profile { get { return profile; } }

        /// <summary>
        /// Mensagem cifrada
        /// </summary>
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

        /// <summary>
        /// Chave privada
        /// </summary>
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

        /// <summary>
        /// Chave pública
        /// </summary>
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

        /// <summary>
        /// Mensagem em claro
        /// </summary>
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

        /// <summary>
        /// Corpo N
        /// </summary>
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

        /// <summary>
        /// Numero primo p
        /// </summary>
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

        /// <summary>
        /// Corpo phi de n
        /// </summary>
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

        /// <summary>
        /// Numero primo q
        /// </summary>
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

        /// <summary>
        /// Texto em claro, no codificado em ASCII
        /// </summary>
        public string Texto
        {
            get;
            set;
        }

        public RSAInfo()
        {
            profile = new RSAPuzzleProfile();
        }

        public void Imprimir()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("/----------------------------------------------------------------/");
            Console.WriteLine("\tResultado da operacao");
            Console.WriteLine("/----------------------------------------------------------------/");

            Console.WriteLine("[Resultado] Primo p: {0}", this.P);
            Console.WriteLine("[Resultado] Primo q: {0}", this.Q);
            Console.WriteLine("[Resultado] N: {0}", this.N);
            Console.WriteLine("[Resultado] phi(N): {0}", this.PhiN);
            Console.WriteLine("[Resultado] Pub_k: {0}", this.E);
            Console.WriteLine("[Resultado] Pri_k: {0}", this.D);
            Console.WriteLine("[Resultado] Texto Cifrado: {0}", this.C);
            Console.WriteLine("[Resultado] Mensagem: {0}", this.M);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[Resultado] Texto em claro: {0}", this.Texto);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("/----------------------------------------------------------------/");
            Console.WriteLine("\tMetricas durante a fatoracao");
            Console.WriteLine("/----------------------------------------------------------------/");

            Console.WriteLine("[INFO] Memoria consumida durante a fatorcao de N");
            Console.WriteLine("Inicio: {0:N}Kb \tFinal: {1:N}Kb", this.Profile.MemoriaInicial / 1024, this.Profile.MemoriaFinal / 1024);

            Console.Write("[INFO] Tempo gasto durante a fatorcao de N: ");
            Console.WriteLine("{0:00}:{1:00}:{2:00}.{3:00}", this.Profile.TempoGastoFatorial.Hours, this.Profile.TempoGastoFatorial.Minutes, this.Profile.TempoGastoFatorial.Seconds, this.Profile.TempoGastoFatorial.Milliseconds / 10);

            Console.Write("[INFO] Tempo gasto durante todo o processamento: ");
            Console.WriteLine("{0:00}:{1:00}:{2:00}.{3:00}", this.Profile.TempoGastoTotal.Hours, this.Profile.TempoGastoTotal.Minutes, this.Profile.TempoGastoTotal.Seconds, this.Profile.TempoGastoTotal.Milliseconds / 10);

            Console.ResetColor();
        }
    }
}
