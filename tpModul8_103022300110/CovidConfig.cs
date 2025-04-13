using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpModul8_103022300110
{
    class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        private static string filePath = @"C:\Users\super\OneDrive\Documents\KULIAHHH\SEMESTER 4\SOFTWARE CONSTRUCTION\Personal Assignment (Code Implementaion)\tpModul8_103022300110\covid_config.json";

        public static CovidConfig LoadConfig()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<CovidConfig>(json);
            }

            // Default jika file tidak ditemukan
            return new CovidConfig
            {
                satuan_suhu = "celcius",
                batas_hari_deman = 14,
                pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
            };
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void UbahSatuan()
        {
            satuan_suhu = "fahrenheit";
            Save();
        }
    }
}
