using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.PersistentStorage
{
    public static class StorageManager
    {

   
        public static void WriteFile(string filePath, string fileName, string data, bool runtime)
        {
            string applicationPath = runtime ? Application.persistentDataPath : Application.dataPath;
            string path = applicationPath + "/" + filePath + fileName;

            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine(data);
            writer.Close();
            
            
        }

        public static string ReadFile(string filePath, string fileName, bool runtime)
        {
            string applicationPath = runtime ? Application.persistentDataPath : Application.dataPath;
            string path = applicationPath + "/" + filePath + fileName;

            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();
            reader.Close();
            return data;


        }
    }
}
