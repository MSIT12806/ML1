using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML1
{
    public static class PrintResult
    {
        public static void PrintData()
        {
            MyDataReader<Flower> dataReader= new CsvReader<Flower>("C:\\Gits\\ML\\ML1\\ML1\\BlueFllower.csv");
            var data = dataReader.GetAllData();
            foreach (var item in data)
            {
                Console.WriteLine($"Len:{item.Length}, Wid:{item.Width}, Col:{(item.Color?"Blue":"Red")}");
            }
        }
    }
}
