using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace RSA_Puzzle
{
    /// <summary>
    /// Essa classe serve para realizar testes com o resultado obtido da fatoração
    /// </summary>
    public class RSATest
    {
        RSAInfo _info;
        public RSATest(RSAInfo info)
        {
            _info = info;
        }

        public void Imprimir()
        {
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("/----------------------------------------------------------------/");
            Console.WriteLine("\tRealizando testes para validar o resultado obtido");
            Console.WriteLine("/----------------------------------------------------------------/");
            Console.WriteLine("[Teste] n = pq: {0}", TestN());
            Console.WriteLine("[Teste] M < n: {0}", TestMMinorN());
            Console.WriteLine("[Teste] M^ed mod n = M: {0}", TestMModN());
            Console.WriteLine("[Teste] ed mod phiN = 1: {0}", TestEDPhiN());
            Console.WriteLine("[Teste] Comparando o texto em claro com o valor da descriptografia da mensagem criptografada: {0}", TestDescriptandoAMensagem());
            Console.WriteLine("[Teste] Comparando o texto cifrado informado com o valor da criptografia da mensagem em claro: {0}", TestEncriptandoAMensagem());


            Console.ResetColor();
        }

        /// <summary>
        /// Sabendo que p*q=n, dessa forma é realizado o teste com p e q obtido da fatoração comparando o resultado com o valor n informado no inicio do programa.
        /// </summary>
        /// <returns></returns>
        public bool TestN()
        {
            return (_info.P * _info.Q) == _info.N;
        }

        /// <summary>
        /// De acordo com o livro do Stallings, apêndice R - Proof of the RSA Algorithm, o bloco de mensagem M é menor que o corpo n
        /// </summary>
        /// <returns></returns>
        public bool TestMMinorN()
        {
            return _info.M < _info.N;
        }

        /// <summary>
        /// De acordo com o livro do Stallings, apêndice R - Proof of the RSA Algorithm, a mensagem M elevado a ed mod n tem que ser igual a M
        /// </summary>
        /// <returns></returns>
        public bool TestMModN()
        {
            return BigInteger.ModPow(_info.M, _info.E * _info.D, _info.N) == _info.M;
        }

        /// <summary>
        /// De acordo com o livro do Stallings, apêndice R - Proof of the RSA Algorithm, a relação das chaves e e d mod phiN tem que ser igual a 1
        /// </summary>
        /// <returns></returns>
        public bool TestEDPhiN()
        {
            return (_info.E * _info.D) % _info.PhiN == 1;
        }


        /// <summary>
        /// Comparando a mensagem em claro com o valor decriptografada da mensagem cifrada
        /// </summary>
        /// <returns></returns>
        public bool TestDescriptandoAMensagem()
        {
            return BigInteger.ModPow(_info.C, _info.D, _info.N) == _info.M;
        }

        /// <summary>
        /// Comparando a mensagem em cifrada com o valor criptografado da mensagem em claro
        /// </summary>
        /// <returns></returns>
        public bool TestEncriptandoAMensagem()
        {
            return BigInteger.ModPow(_info.M, _info.E, _info.N) == _info.C;
        }
    }
}
