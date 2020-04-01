using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.IO
{
    public class ProfileIO
    {
        static string configDir = Environment.CurrentDirectory + "/FlareData/";
        public static void saveSetting<T>(string profile, string path, T value)
        {
            string file = configDir + profile + ".fdf";
            if (!File.Exists(file)){
                File.Create(file);
            }
            string[] lines = File.ReadAllLines(file);
            List<string> newLines = new List<string>();
            foreach (string line in lines)
            {
                if (line.StartsWith(path + ":"))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    string newLine = path+":";
                    MemoryStream serializationStream = new MemoryStream();
                    bin.Serialize(serializationStream, value);
                    newLine += Encoding.UTF8.GetString(serializationStream.ToArray());
                    newLines.Add(newLine);
                }
                newLines.Add(line);
            }
        }
        public static T loadSetting<T>(string profile, string path, out bool success)
        {
            string file = configDir + profile + ".fdf";
            if (!File.Exists(file))
            {
                File.Create(file);
            }
            string[] lines= File.ReadAllLines(file);
            string targetLine = "";
            foreach(string line in lines)
            {
                if (line.StartsWith(path + ":"))
                {
                    targetLine = line;
                }
            }
            string[] split = targetLine.Split(':');
            if (split.Length != 2)
            {
                success = false;
                return default;
            }
            try
            {
                BinaryFormatter bin = new BinaryFormatter();
                MemoryStream serializationStream = new MemoryStream();
                serializationStream.Write(Encoding.UTF8.GetBytes(split[1]), 0, split[1].Length);
                T deserialized = (T)bin.Deserialize(serializationStream);
                success = true;
                return deserialized;
            }
            catch (Exception)
            {
                success = false;
                return default;
            }
        }
    }
}
