using System.Runtime.CompilerServices;
using Test_Likhnitskiy_Andrey;
using Test_Likhnitskiy_Andrey.Engines;
#region MAIN
{
    float I = 10;
    float[] M = new float[] { 20, 75, 105, 75, 0 };
    float[] V = new float[] { 0, 75, 150, 200, 250, 300 };
    float Hm = 0.01f;
    float Hv  = 0.0001f;
    float C = 0.1f;

    float temp = GetFloat(Console.ReadLine());
    
    InternalCombustionEngine engine = new InternalCombustionEngine(I, M, V, Hm, Hv, C, temp);
    TestStand test = new TestStand();
    
    test.StartTest(engine);
}
#endregion

float GetFloat(string? s) 
{
    if(float.TryParse(s, out float result))
        return result;
    else throw new Exception("Некорректный ввод данных. Перезапустите программу");
}