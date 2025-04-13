using System;
using tpModul8_103022300110;

class Program
{
    public static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.LoadConfig();

        //config.UbahSatuan();

        Console.Write("Apakah kamu ingin mengubah satuan suhu? (y/n): ");
        string jawab = Console.ReadLine()?.ToLower();

        if (jawab == "y")
        {
            config.UbahSatuan();
            Console.WriteLine($"Satuan suhu telah diubah ke: {config.satuan_suhu}");
        }
        else
        {
            Console.WriteLine($"Satuan suhu tetap: {config.satuan_suhu}");
        }


        Console.WriteLine($"Satuan suhu sekrang {config.satuan_suhu}");

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = int.Parse(Console.ReadLine());

        bool suhuNormal = false;

        if (config.satuan_suhu == "celcius")
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        else if (config.satuan_suhu == "fahrenheit")
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;

        if (suhuNormal && hari < config.batas_hari_deman)
            Console.WriteLine(config.pesan_diterima);
        else
            Console.WriteLine(config.pesan_ditolak);
    }
}
