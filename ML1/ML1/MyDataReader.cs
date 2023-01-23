using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML1
{
    public interface MyDataReader<T>
    {
        IEnumerable<T> GetAllData();
        T GetDataByRow(int row);
    }
    public class CsvReader<T> : MyDataReader<T> where T : new()
    {
        string absolutePath;
        public CsvReader(string absolutePath)
        {
            this.absolutePath = absolutePath;
        }
        public IEnumerable<T> GetAllData()
        {
            List<T> result = new List<T>();

            // 讀取 csv 檔案中的內容
            string filePath = absolutePath;
            string[] lines = File.ReadAllLines(filePath);

            // 取得欄位名稱
            string[] headers = lines[0].Split(',');

            for (int i = 1; i < lines.Length; i++)
            {
                // 將每一行的內容分割為字串陣列
                string[] fields = lines[i].Split(',');

                // 建立泛用型別的物件
                T item = new T();

                for (int j = 0; j < headers.Length; j++)
                {
                    // 取得欄位名稱
                    string header = headers[j];

                    // 取得欄位值
                    string value = fields[j];

                    // 取得屬性
                    var prop = item.GetType().GetProperty(header);

                    // 檢查屬性是否為布林型別
                    if (prop.PropertyType == typeof(bool))
                    {
                        value = (value == "1") ? "true" : "false";
                    }

                    // 將欄位值對映到泛用型別物件中
                    prop.SetValue(item, Convert.ChangeType(value, prop.PropertyType), null);
                }

                result.Add(item);
            }

            return result;
        }

        public T GetDataByRow(int row)
        {
            throw new NotImplementedException();
        }
    }
}
