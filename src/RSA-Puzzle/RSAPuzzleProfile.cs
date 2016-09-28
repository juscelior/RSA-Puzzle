using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RSA_Puzzle
{
    public class RSAPuzzleProfile
    {
        static Stopwatch swFatorial, swTotal;
        public long MemoriaInicial { get; set; }
        public long MemoriaFinal { get; set; }
        public TimeSpan TempoGastoFatorial { get; set; }
        public TimeSpan TempoGastoTotal { get; set; }


        public RSAPuzzleProfile()
        {
            swFatorial = new Stopwatch();
            swTotal = new Stopwatch();
        }
        public void IniciarCronometro()
        {
            swTotal.Start();
        }

        public void EncerrarCronometro()
        {
            swTotal.Stop();
            TempoGastoTotal = swTotal.Elapsed;
        }

        public void IniciarMonitoramentoFatorial()
        {
            Interlocked.MemoryBarrier();
            MemoriaInicial = GC.GetTotalMemory(true);
            swFatorial.Start();
        }

        public void FinalizarMonitoramentoFatorial()
        {
            swFatorial.Stop();
            Interlocked.MemoryBarrier();
            MemoriaFinal = GC.GetTotalMemory(true);
            TempoGastoFatorial = swFatorial.Elapsed;
        }
    }
}
