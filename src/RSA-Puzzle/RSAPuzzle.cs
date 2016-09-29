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
            //Funções para cronometrar o tempo de todo o processo para resolver o problema RSA-100
            info.Profile.IniciarCronometro();
            //Funções para cronometrar o tempo para encontrar o valor de p
            info.Profile.IniciarMonitoramentoFatorial();

            //Aplicamos o algoritmo proposto por John Pollard em 1975
            info.P = AplicarPollardsRho(info.N);

            //Marcado informando para parar o cronometro da fatoração
            info.Profile.FinalizarMonitoramentoFatorial();

            //Partindo do entendimento que já encontramos p, e sabendo que n é o resultado da multiplicação de p e q
            //Logo o valor de q seria o resultado da divisão de n por p
            info.Q = info.N / info.P;

            //Para encontrar o valor de phiN aplicamos a formula (p-1)*(q-1)
            info.PhiN = (info.P - 1) * (info.Q - 1);

            //A chave privada pode ser encontrada com a multiplicação inversa da chave pública em relação a phiN
            info.D = modInverso(info.E, info.PhiN);

            //Para encontrar a mensagem descriptografada, utilizamos a formula c^d % n
            info.M = BigInteger.ModPow(info.C, info.D, info.N);

            //Aplicamos a transformação do valor da mensagem encontrada após a sua descriptografia para um valor codificado em ASCII, onde a cada 2 caractere representa 1 caractere em ASCII
            info.Texto = converterParaASCII(info.M.ToString());

            //Marcado informando para parar o cronometro de todo o cálculo para conseguir o valor em claro da mensagem criptografada
            info.Profile.EncerrarCronometro();

            return info;
        }

        /// <summary>
        /// Algoritmo Pollard's rho
        /// Esse algoritmo foi desenvolvido por Pollard em 1975
        /// A ideia do algoritmo consiste em gerar um número pseudoaleatório
        /// x = (x * x + 1) % n;
        /// 
        /// Esse algoritmo gera uma sequência pseudoaleatório até cair em um ciclo, para evitar que caia em um laço infinito, foi utilizado uma variável de controle chamada cycle_size.
        /// O tempo esperado até que a sequência caia em um ciclo é proporcional a Raiz quadrada de n
        /// O valor do cycle_size é equivalente a 2^(número de rodadas)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private BigInteger AplicarPollardsRho(BigInteger n)
        {
            BigInteger x = new BigInteger(2);
            BigInteger factor = new BigInteger(1);
            BigInteger x_fixed = new BigInteger(2);
            int cycle_size = 2;

            //Enquanto o factor for igual 1, se ele for maior, encontramos o valor de p
            while (factor == 1)
            {
                //Representa o cálculo da rodada.
                //cycle_size é 2^(quantidade de rodadas)
                //EX: caso seja a primeira rodada o valor de cycle_size seria 2^1, se fosse a quinta rodada seria o seu valor seria 2^5 = 32
                for (int count = 1; count <= cycle_size && factor <= 1; count++)
                {
                    //Gera um numero pseudoaleatório
                    x = (x * x + 1) % n;

                    factor = BigInteger.GreatestCommonDivisor(x - x_fixed, n);
                }

                cycle_size *= 2;
                x_fixed = x;
            }

            return factor;
        }

        /// <summary>
        /// Função responsável por realizar a exponenciação modular
        /// </summary>
        /// <param name="e"></param>
        /// <param name="n"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Codifica e mensagem para seu equivalente em ASCII, respeitando a lógica de a cada 2 caracteres equivale em 1 valor na tabela ASCII
        /// </summary>
        /// <param name="mensagem"></param>
        /// <returns></returns>
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
