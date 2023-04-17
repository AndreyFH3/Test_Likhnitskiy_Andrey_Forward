using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Likhnitskiy_Andrey.Engines
{
    internal class InternalCombustionEngine : Engine
    {
        public InternalCombustionEngine(float I, float[] M, float[] V, float Hm, float Hv, float C, float temperature) : 
            base(I, M, V, Hm, Hv, C, temperature) { }



        public override float HeatingRate(int index) => M[index] * Hm + MathF.Pow(V[index], 2) * Hv;

        public override float CoolingRate(int index) => C * (TEnviroment - TEngine);

        public override (int, bool) Simulate()
        {
            int time = 0;
            int maxTime = 2500;
            int index = 0;

            float v = V[0]; 
            float m = M[0]; 
            float a = M[0] / I;

            while (!IsOverHeat)
            {
                ++time;
                v += a; 

                index += index < M.Length - 2
                    ? v < M[index + 1] 
                        ? 0 
                        : 1
                    : 0;

                float up = v - V[index];
                float down = V[index + 1] - V[index];
                float factor = M[index + 1] - M[index];
                m = up / down * factor + M[index];
                TEngine += HeatingRate(index) + CoolingRate(index);
                a = m / I;
                IsOverHeat = TOverheat <= TEngine;
                if(maxTime <= time)
                {
                    return (time, true);
                }
            }

            return (time, false);

        }

    }
}
