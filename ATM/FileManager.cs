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
        public void WriteData()
        {
            var accounts = new[]
{
                new { Name = "Konto 1", Balance = 1000.0 },
                new { Name = "Konto 2", Balance = 5000.0 },
                new { Name = "Konto 3", Balance = 2000.0 },
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize(accounts, options);

            var filename = "../../../../Saves/users.json";
            
            File.WriteAllText(filename, json);

            Console.WriteLine($"Zapisano {accounts.Length} kont do pliku {filename}");
        }

        public Object[] ReadData()
        {
            return null;
        }
    }
}