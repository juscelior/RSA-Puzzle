using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace RSA_Puzzle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RSAPuzzle rsa1 = new RSAPuzzle("949902337593732396994719119873", "165772326714668730785560041787", "6772558976633833488172800351");
            RSAPuzzle rsa2 = new RSAPuzzle("83140361258286376419383780399", "145521313938052692625650086791", "107570193177564050094349063369");
            RSAPuzzle rsa3 = new RSAPuzzle("146415029121779013346484386243", "526514926305168121442289247889", "389487317456079343725109185855");
            RSAPuzzle rsa4 = new RSAPuzzle("79416997781680809248379529279", "113372866814489443756184748623", "32969390369471701792127187219");
            RSAPuzzle rsa5 = new RSAPuzzle("354496798059228460541345727943", "436578704663021353851760058567", "18358978277291877360404561152");
            RSAPuzzle rsa6 = new RSAPuzzle("65991656935309556946334537421", "776024116327733109997546004413", "440956302061270319148903300929");
            RSAPuzzle rsa7 = new RSAPuzzle("107074310067384015279771780359", "716986706621138193334849008809", "609810477808753196933983953492");
            RSAPuzzle rsa8 = new RSAPuzzle("357637061988777028710437384669", "400220582605191947480095697563", "194496061940512005552080230225");
            RSAPuzzle rsa9 = new RSAPuzzle("107778279971684516690444046067", "546414508111281232984895453741", "227136785220628684883812511774");
            RSAPuzzle rsa10 = new RSAPuzzle("93283342829830335318407785033", "112685970328815221881682030779", "81968136837986791103525517433");
            RSAPuzzle rsa11 = new RSAPuzzle("407008269973444452940125334891", "623171572907500791642047276999", "93227721222106738575633474354");
            RSAPuzzle rsa12 = new RSAPuzzle("245427906227410096976650915187", "481512719053266333115702349923", "12156830769538472074363549562");
            RSAPuzzle rsa13 = new RSAPuzzle("5178823383791929716166324671791", "551791528462201310857081956463", "244137066175660768128879476899");

            List<RSAInfo> resultados = new List<RSAInfo>();
            resultados.Add(rsa1.Resolver());
            resultados.Add(rsa2.Resolver());
            resultados.Add(rsa3.Resolver());
            resultados.Add(rsa4.Resolver());
            resultados.Add(rsa5.Resolver());
            resultados.Add(rsa6.Resolver());
            resultados.Add(rsa7.Resolver());
            resultados.Add(rsa8.Resolver());
            resultados.Add(rsa9.Resolver());
            resultados.Add(rsa10.Resolver());
            resultados.Add(rsa11.Resolver());
            resultados.Add(rsa12.Resolver());
            resultados.Add(rsa13.Resolver());

            // Stopwatch sw = new Stopwatch();
            // sw.Start();
            // sw.Stop();
            // Console.WriteLine("Tempo total: {0:00}:{1:00}:{2:00}.{3:00}",
            //sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds,
            //sw.Elapsed.Milliseconds / 10);

            for (int i = 0; i < resultados.Count; i++)
            {
                Console.WriteLine("Desafio RSA {0}", i + 1);

                Console.WriteLine("Primo p: {0}", resultados[i].P);
                Console.WriteLine("Primo q: {0}", resultados[i].Q);
                Console.WriteLine("N: {0}", resultados[i].N);
                Console.WriteLine("phi(N): {0}", resultados[i].PhiN);
                Console.WriteLine("Pub_k: {0}", resultados[i].E);
                Console.WriteLine("Pri_k: {0}", resultados[i].D);

                Console.WriteLine("1 mod phiN: {0}", BigInteger.Multiply(resultados[i].D, resultados[i].E) % resultados[i].PhiN == 1);

                Console.WriteLine("Texto Cifrado: {0}", resultados[i].C);
                Console.WriteLine("Mensagem: {0}", resultados[i].M);
                Console.WriteLine("Texto em claro: {0}", resultados[i].Texto);

                Console.WriteLine("------------ || ------------");
            }

            Console.ReadKey();
        }
    }
}
