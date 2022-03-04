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
            string data = "";
            if (!runtime)
            {
                TextAsset f = (TextAsset)Resources.Load(filePath + fileName);
                data = System.Text.Encoding.UTF8.GetString(f.bytes);


            }
            else
            {
                string applicationPath = Application.persistentDataPath;
                string path = applicationPath + "/" + filePath + fileName;
                StreamReader reader = new StreamReader(path);
                data = reader.ReadToEnd();
                reader.Close();
            }

            
            

            
            
            return data;


        }
    }
}
