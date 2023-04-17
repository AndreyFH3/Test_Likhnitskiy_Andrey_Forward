using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Likhnitskiy_Andrey.Engines;

namespace Test_Likhnitskiy_Andrey
{
    internal class TestStand
    {
        public void StartTest(Engine engine)
        {
            if(engine is InternalCombustionEngine e)
            {
                RunTestInternalCombustion(e);
            }
            else
            {
                Console.WriteLine("Engine is not define");
            }
        }

        private void RunTestInternalCombustion(Engine engine)
        {
            var results = engine.Simulate();
            Console.WriteLine(results.Item2
                ? "Двигатель успешно прошел тесты"
                : $"Двигатель перегрелся через {results.Item1} секунд");
        }
    }
}
