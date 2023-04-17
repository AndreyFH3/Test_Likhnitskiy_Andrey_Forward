using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Likhnitskiy_Andrey.Engines
{
    internal abstract class Engine
    {
        public bool IsOverHeat { get; private protected set; } = false;
        /// <summary>
        /// момент инерции
        /// </summary>
        private protected float I { get; set; }
        /// <summary>
        /// кусочно линейная зависимость крутящего момента
        /// </summary>
        private protected float[] M{ get; set; }
        /// <summary>
        /// скорость вращения коленвала
        /// </summary>
        private protected float[] V { get; set; }
        /// <summary>
        /// температура двигателя
        /// </summary>
        private protected float TEngine { get; set; }
        /// <summary>
        /// температура окружающей среды
        /// </summary>
        private protected float TEnviroment { get; set; }

        /// <summary>
        /// температура перегрева
        /// </summary>
        private protected float TOverheat { get; set; } = 110;
        // Hm - коэффициент зависимости скорости нагрева от крутящего момента
        private protected float Hm { get; set; }
        // Hv - коэффициент зависимости скорости нагрева от скорости вращения коленвала
        private protected float Hv { get; set; }
        // C - коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды
        private protected float C { get; set; }

        public Engine(float I, float[] M, float[] V, float Hm, float Hv, float C, float temperature)
        {
            TEngine = TEnviroment = temperature;
            this.I = I;
            this.M = M;
            this.V = V;
            this.Hm = Hm;
            this.Hv = Hv;
            this.C = C;
        }


        public abstract float HeatingRate(int index);

        public abstract float CoolingRate(int index);

        public abstract (int,bool) Simulate();

    }
}
