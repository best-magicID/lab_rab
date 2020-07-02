using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_rab
{
    public class CsvData
    {
        public string Name { get; set; }
        public string Mask { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var data = GetList(args[1]);

            Console.WriteLine($"Содержимое файла:\n{new string('*', 14)}");
            Console.WriteLine(string.Join("\n", data.Select(x => $"{x.Name,-7} \t {x.Mask,5}")));
            Console.WriteLine(new string('*', 14));



        }

        static List<CsvData> GetList(string path)
        {
            var result = new List<CsvData>();

            using (var sr = new StreamReader(path))
            using (var cr = new CsvReader(sr, new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = true
            }))
            {
                result = cr.GetRecords<CsvData>().ToList();
            }
            return result;
        }
    }
}
