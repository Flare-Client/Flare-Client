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
        /*static string currentProfile = "DefaultProfile";
        static string configDir = Environment.CurrentDirectory + "/FlareData/";
        public static void saveSetting<T>(string path, T value)
        {
            saveSetting<T>(currentProfile, path, value);
        }
        public static bool saveSetting<T>(string profile, string path, T value)
        {
            try
            {
                //Check if required files exist
                if (!Directory.Exists(configDir))
                {
                    Directory.CreateDirectory(configDir);
                }
                string file = configDir + profile + ".fdf";
                if (!File.Exists(file))
                {
                    File.Create(file).Close();
                }

                //Create string of serialized object
                BinaryFormatter bin = new BinaryFormatter();
                string newLine = path + ":";
                MemoryStream serializationStream = new MemoryStream();
                bin.Serialize(serializationStream, value);
                newLine += Encoding.UTF8.GetString(serializationStream.ToArray());

                //Read file to replace it if it exists
                string[] lines = File.ReadAllLines(file);
                List<string> newLines = new List<string>();
                bool appendRequired = true;
                foreach (string line in lines)
                {
                    if (line.StartsWith(path))
                    {
                        //the line does exist so we replace it
                        newLines.Add(newLine);
                        appendRequired = false;
                        continue;
                    }
                    newLines.Add(line);
                }
                //the line doesnt exist so we have to append it
                if (appendRequired)
                {
                    newLines.Add(newLine);
                }
                File.WriteAllLines(file, newLines);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
        public static T loadSetting<T>(string path, out bool success)
        {
            return loadSetting<T>(currentProfile, path, out success);
        }
        public static T loadSetting<T>(string profile, string path, out bool success)
        {
            if (!Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir);
            }
            string file = configDir + profile + ".fdf";
            if (!File.Exists(file))
            {
                File.Create(file).Close();
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
        }*/
    }
}
