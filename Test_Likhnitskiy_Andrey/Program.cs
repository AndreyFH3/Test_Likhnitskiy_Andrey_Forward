using System.Globalization;
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
    Console.WriteLine("Введите данные о погоде: ");
    float temp = GetFloat(Console.ReadLine());
    if(temp == -1)
    {
        return;
    }
    InternalCombustionEngine engine = new InternalCombustionEngine(I, M, V, Hm, Hv, C, temp);
    TestStand test = new TestStand();
    
    test.StartTest(engine);
}
#endregion

float GetFloat(string? s)
{

    if (s.Contains(','))
    {
        s = s.Replace(',', '.');
    }

    if (float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out float result))
        return result;
    else
    {
        Console.WriteLine("Некорректный ввод данных. Перезапустите программу");
        return -1;
    }
}