using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Puzzle.Portable
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

        public string Imprimir()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("/----------------------------------------------------------------/");
            sb.AppendLine("\tResultado da operacao");
            sb.AppendLine("/----------------------------------------------------------------/");

            sb.AppendLine(string.Format("[Resultado] Primo p: {0}", this.P));
            sb.AppendLine(string.Format("[Resultado] Primo q: {0}", this.Q));
            sb.AppendLine(string.Format("[Resultado] N: {0}", this.N));
            sb.AppendLine(string.Format("[Resultado] phi(N): {0}", this.PhiN));
            sb.AppendLine(string.Format("[Resultado] Pub_k: {0}", this.E));
            sb.AppendLine(string.Format("[Resultado] Pri_k: {0}", this.D));
            sb.AppendLine(string.Format("[Resultado] Texto Cifrado: {0}", this.C));
            sb.AppendLine(string.Format("[Resultado] Mensagem: {0}", this.M));

            sb.AppendLine(string.Format("[Resultado] Texto em claro: {0}", this.Texto));

            sb.AppendLine("/----------------------------------------------------------------/");
            sb.AppendLine("\tMetricas durante a fatoracao");
            sb.AppendLine("/----------------------------------------------------------------/");
            sb.Append("[INFO] Tempo gasto durante a fatorcao de N: ");
            sb.AppendLine(string.Format("{0:00}:{1:00}:{2:00}.{3:00}", this.Profile.TempoGastoFatorial.Hours, this.Profile.TempoGastoFatorial.Minutes, this.Profile.TempoGastoFatorial.Seconds, this.Profile.TempoGastoFatorial.Milliseconds / 10));

            sb.Append("[INFO] Tempo gasto durante todo o processamento: ");
            sb.AppendLine(string.Format("{0:00}:{1:00}:{2:00}.{3:00}", this.Profile.TempoGastoTotal.Hours, this.Profile.TempoGastoTotal.Minutes, this.Profile.TempoGastoTotal.Seconds, this.Profile.TempoGastoTotal.Milliseconds / 10));

            return sb.ToString();
        }
    }
}
