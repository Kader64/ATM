using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ATM
{
    internal class FileManager
    {
        private string path = "../../../../Saves/users.json";
        public void WriteData(UserData[] data)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize(data, options);

            File.WriteAllText(path, json);
        }

        public UserData[] ReadData()
        {
            string json = File.ReadAllText(path);
            UserData[] data = JsonSerializer.Deserialize<UserData[]>(json);
            return data;
        }
    }
}