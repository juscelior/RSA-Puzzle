using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Threading;

namespace RSA_Puzzle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DesenharOCabecalho();
            RSAPuzzle rsa = ObterParametros();
            //RSAPuzzle rsa7 = new RSAPuzzle("107074310067384015279771780359", "716986706621138193334849008809", "609810477808753196933983953492");
            Processando();
            ImprimirResultado(rsa.Resolver());

            Console.ReadKey();
        }

        private static void LimparTela()
        {
            Console.Clear();
            DesenharOCabecalho();
        }
        private static void DesenharOCabecalho()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("$$$$$$$\\   $$$$$$\\   $$$$$$\\        $$$$$$$\\                                $$\\");
            Console.WriteLine("$$  __$$\\ $$  __$$\\ $$  __$$\\       $$  __$$\\                               $$ |");
            Console.WriteLine("$$ |  $$ |$$ /  \\__|$$ /  $$ |      $$ |  $$ |$$\\   $$\\ $$$$$$$$\\ $$$$$$$$\\ $$ | $$$$$$\\");
            Console.WriteLine("$$$$$$$  |\\$$$$$$\\  $$$$$$$$ |      $$$$$$$  |$$ |  $$ |\\____$$  |\\____$$  |$$ |$$  __$$\\");
            Console.WriteLine("$$  __$$<  \\____$$\\ $$  __$$ |      $$  ____/ $$ |  $$ |  $$$$ _ /   $$$$ _/$$ |$$$$$$$$ |");
            Console.WriteLine("$$ |  $$ |$$\\   $$ |$$ |  $$ |      $$ |      $$ |  $$ | $$  _/    $$  _/   $$ |$$   ____|");
            Console.WriteLine("$$ |  $$ |\\$$$$$$  |$$ |  $$ |      $$ |      \\$$$$$$  |$$$$$$$$\\ $$$$$$$$\\ $$ |\\$$$$$$$\\");
            Console.WriteLine("\\__|  \\__| \\______/ \\__|  \\__|      \\__|       \\______/ \\________|\\________|\\__| \\_______|");
            Console.WriteLine(Environment.NewLine);
            Console.ResetColor();
        }
        private static void Processando()
        {
            LimparTela();

            Console.WriteLine("Processando...");
        }
        private static RSAPuzzle ObterParametros()
        {
            Console.WriteLine("Qual a chave publica?");
            string pk = Console.ReadLine();
            Console.WriteLine("Qual o corpo N?");
            string n = Console.ReadLine();
            Console.WriteLine("Qual a mensagem criptografada?");
            string m = Console.ReadLine();

            return new RSAPuzzle(pk.Trim(), n.Trim(), m.Trim());
        }
        private static void ImprimirResultado(RSAInfo resultado)
        {
            LimparTela();

            resultado.Imprimir();

            new RSATest(resultado).Imprimir();
        }
    }
}
