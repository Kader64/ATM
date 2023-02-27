using System.Text.Json;
using ATM.Resources.BaseClasses;
using ConsoleGameEngine;
using ATM.Resources.GameClasses;

namespace ATM
{
    internal class FileManager
    {
        private static readonly string path = "../../../Resources/Assets/Saves/";
        public static void WriteUsersData(UserData[] data)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(path+ "users.json", json);
        }

        public static UserData[] ReadUsersData()
        {
            if (!File.Exists(path + "users.json"))
            {
                File.Create(path + "users.json");
            }
            try
            {
                string json = File.ReadAllText(path + "users.json");
                UserData[] data = JsonSerializer.Deserialize<UserData[]>(json);
                return data;
            }
            catch(Exception ex)
            {
                return new UserData[0];
            }
        }

        public static GameObject[] ReadGameObjectsData(int level)
        {
            string json = File.ReadAllText(path + $"level{level}.json");

            GameObject[] objects = JsonSerializer.Deserialize<GameObject[]>(json);
            GameObject[] gameObjects = new GameObject[objects.Length];

            for (int i = 0; i < objects.Length; i++)
            {
                GameObject obj = null;
                switch (objects[i].Type)
                {
                    case "Atm": obj = new Atm(objects[i].PosX, objects[i].PosY); break;
                    case "Hook": obj = new Hook(objects[i].PosX, objects[i].PosY); break;
                    case "Plug": obj = new Plug(objects[i].PosX, objects[i].PosY); break;
                    case "Ladder": obj = new Ladder(objects[i].PosX, objects[i].PosY, objects[i].Height); break;
                    case "Surface": obj = new Surface(objects[i].PosX, objects[i].PosY, objects[i].Width, objects[i].Height, objects[i].Color); break;
                    case "Trapdoor": obj = new Trapdoor(objects[i].PosX, objects[i].PosY, objects[i].Width, objects[i].Height); break;
                }
                gameObjects[i] = obj;
            }
            return gameObjects;
        } 
    }
}