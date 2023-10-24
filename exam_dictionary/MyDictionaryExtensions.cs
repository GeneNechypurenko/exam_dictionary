using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace exam_dictionary
{
    public static class MyDictionaryExtensions
    {
        public static void OpenDictionary(this MyDictionary dictionary, IDataStorage dataStorage)
        {
            Console.WriteLine("Awailable Dictionaries:");
            dataStorage.ShowSources();

            Console.Write("Enter File Name: ");
            string file = Console.ReadLine();
            dataStorage.OpenSource(file);

            string data = dataStorage.LoadData();
            if (data != null) { dictionary.Content = JsonConvert.DeserializeObject<Dictionary<string, string>>(data); }
        }
        public static void CreateDictionary(this MyDictionary dictionary, IDataStorage dataStorage)
        {
            Console.WriteLine("Enter New Dictionary Name:");
            string fileName = Console.ReadLine();

            dataStorage = new FileDataStorage(fileName);
            Console.WriteLine($"New Dictionary {fileName} Has Been Created");
        }
        public static void DeleteDictionary(this MyDictionary dictionary, IDataStorage dataStorage)
        {
            Console.WriteLine("Awailable Dictionaries:");
            dataStorage.ShowSources();

            Console.Write("Enter File Name To Delete: ");
            string file = Console.ReadLine();

            dataStorage.DeleteSource(file);
            Console.WriteLine($"{file} Has Been Deleted");
        }



        public static void SearchForTranslation(this MyDictionary dictionary)
        {
            Console.Write("Enter Word: ");
            string keyWord = Console.ReadLine();

            string? translation;
            if (dictionary.TryGetValue(keyWord, out translation))
            {
                Console.WriteLine($"Translation for '{keyWord}': {translation}");
            }
            else
            {
                Console.WriteLine($"Translation for '{keyWord}' not found in the dictionary.");
            }
        }
        public static void AddNewWord(this MyDictionary dictionary, IDataStorage dataStorage)
        {
            Console.Write("Enter Word: ");
            string keyWord = Console.ReadLine();
            Console.Write("Enter Translation: ");
            string translation = Console.ReadLine();

            dictionary.Add(keyWord, translation);
            string data = JsonConvert.SerializeObject(dictionary.Content);
            dataStorage.SaveData(data);
        }
        public static void AddTranslation(this MyDictionary dictionary, IDataStorage dataStorage)
        {
            Console.Write("Enter Word: ");
            string keyWord = Console.ReadLine();

            if (dictionary.ContainsKey(keyWord))
            {
                Console.Write("Enter Translation: ");
                string translation = Console.ReadLine();

                string existingTranslation = dictionary[keyWord];
                string updatedTranslation = $"{existingTranslation}, {translation}";

                dictionary[keyWord] = updatedTranslation;
                string data = JsonConvert.SerializeObject(dictionary.Content);
                dataStorage.SaveData(data);

                Console.WriteLine($"Translation for '{keyWord}' has been updated.");
            }
            else
            {
                Console.WriteLine($"The word '{keyWord}' does not exist in the dictionary. You can use the 'Add New Word' option instead.");
            }
        }

        public static void EditKeyWord(this MyDictionary dictionary, IDataStorage dataStorage)
        {
            Console.Write("Enter the Word to Edit: ");
            string oldKeyWord = Console.ReadLine();

            if (dictionary.ContainsKey(oldKeyWord))
            {
                Console.Write("Enter the New Word: ");
                string newKeyWord = Console.ReadLine();

                string translation = dictionary[oldKeyWord];

                dictionary.Remove(oldKeyWord);

                dictionary.Add(newKeyWord, translation);

                string data = JsonConvert.SerializeObject(dictionary.Content);
                dataStorage.SaveData(data);

                Console.WriteLine($"Word '{oldKeyWord}' has been updated to '{newKeyWord}'.");
            }
            else
            {
                Console.WriteLine($"The word '{oldKeyWord}' does not exist in the dictionary.");
            }
        }

        public static void EditTranslation(this MyDictionary dictionary, IDataStorage dataStorage)
        {
            Console.Write("Enter Word: ");
            string keyWord = Console.ReadLine();

            if (dictionary.ContainsKey(keyWord))
            {
                Console.Write("Enter New Translation: ");
                string newTranslation = Console.ReadLine();

                dictionary[keyWord] = newTranslation;

                string data = JsonConvert.SerializeObject(dictionary.Content);
                dataStorage.SaveData(data);

                Console.WriteLine($"Translation for '{keyWord}' has been updated.");
            }
            else
            {
                Console.WriteLine($"The word '{keyWord}' does not exist in the dictionary.");
            }
        }

        public static void DeleteWord(this MyDictionary dictionary, IDataStorage dataStorage)
        {
            Console.Write("Enter Word to Delete: ");
            string keyWord = Console.ReadLine();

            if (dictionary.ContainsKey(keyWord))
            {
                dictionary.Remove(keyWord);

                string data = JsonConvert.SerializeObject(dictionary.Content);
                dataStorage.SaveData(data);

                Console.WriteLine($"Word '{keyWord}' has been deleted.");
            }
            else
            {
                Console.WriteLine($"The word '{keyWord}' does not exist in the dictionary.");
            }
        }
    }
}
