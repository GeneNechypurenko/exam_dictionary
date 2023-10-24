using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exam_dictionary
{
    public class FileDataStorage : IDataStorage
    {
        private readonly string _dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dictionaries");
        private string _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Dictionaries", "MyDictionary.json");



        public string DirPath
        {
            get { return _dirPath; }
        }
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = Path.Combine(_dirPath, value); }
        }



        public FileDataStorage()
        { }
        public FileDataStorage(string fileName)
        {
            _fileName = Path.Combine(_dirPath, fileName);
        }



        public void SaveData(string data)
        {
            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }

            string jsonData = JsonConvert.SerializeObject(data);
            File.WriteAllText(FileName, jsonData);
        }
        public string? LoadData()
        {
            if (File.Exists(FileName))
            {
                string jsonData = File.ReadAllText(FileName);
                string data = JsonConvert.DeserializeObject<string>(jsonData);

                return data;
            }
            else { return null; }
        }

        public void ShowSources()
        {
            if (Directory.Exists(DirPath))
            {
                string[] files = Directory.GetFiles(DirPath);

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    Console.WriteLine(fileName);
                }
            }
            else { throw new FileNotFoundException("File not found"); }
        }

        public void OpenSource(string sourceName)
        {
            if (File.Exists(Path.Combine(DirPath, sourceName)))
            {
                FileName = sourceName;
            }
            else { throw new FileNotFoundException("File not found"); }
        }

        public void DeleteSource(string sourceName)
        {
            if (File.Exists(Path.Combine(DirPath, sourceName)))
            {
                File.Delete(Path.Combine(DirPath, sourceName));
            }
            else { throw new FileNotFoundException("File not found"); }
        }
    }
}
