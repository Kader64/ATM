using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ATM.Resources.BaseClasses;
using ConsoleGameEngine;

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
            string json = File.ReadAllText(path + "users.json");
            UserData[] data = JsonSerializer.Deserialize<UserData[]>(json);
            return data;
        }

        public static GameObject[] ReadGameObjectsData(int level)
        {
            string json = File.ReadAllText(path + $"level{level}.json");

            GameObject[] objects = JsonSerializer.Deserialize<GameObject[]>(json);
            GameObject[] gameObjects = new GameObject[objects.Length];

            for (int i = 0; i < objects.Length; i++)
            {
                GameObject go = null;
                switch (objects[i].Type)
                {
                    case "Atm": go = new Atm(objects[i].PosX, objects[i].PosY); break;
                    case "Hook": go = new Hook(objects[i].PosX, objects[i].PosY); break;
                    case "Plug": go = new Plug(objects[i].PosX, objects[i].PosY); break;
                    case "Surface": go = new Surface(objects[i].PosX, objects[i].PosY, objects[i].Width, objects[i].Height, objects[i].Color); break;
                }
                gameObjects[i] = go;
            }
            return gameObjects;
        } 
    }
}