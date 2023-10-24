using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Transactions;
using Newtonsoft.Json;

namespace exam_dictionary
{
    public class MyDictionary
    {

        private Dictionary<string, string> content = new Dictionary<string, string>();
        public Dictionary<string, string> Content
        {
            get { return content; }
            set { content = value; }
        }
        public void Add(string keyWord, string translation)
        {
            Content[keyWord] = translation;
        }

        public bool ContainsKey(string keyWord)
        {
            return Content.ContainsKey(keyWord);
        }

        public bool TryGetValue(string keyWord, out string? translation)
        {
            return Content.TryGetValue(keyWord, out translation);
        }

        public bool Remove(string keyWord)
        {
            return Content.Remove(keyWord);
        }

        public void Clear()
        {
            Content.Clear();
        }

        public int Count
        {
            get { return Content.Count; }
        }



        public IEnumerable<string> KeyWords
        {
            get { return Content.Keys; }
        }

        public IEnumerable<string> Translations
        {
            get { return Content.Values; }
        }
        public string this[string key]
        {
            get
            {
                if (content.ContainsKey(key)) { return content[key]; }
                else { throw new KeyNotFoundException($"The key '{key}' does not exist in the dictionary."); }
            }
            set { content[key] = value; }
        }
        public override string ToString()
        {
            string result = "{ ";
            foreach (var kvp in Content)
            {
                result += $"{kvp.Key} - {kvp.Value}, ";
            }
            result = result.TrimEnd(' ', ',');
            result += " }";
            return result;
        }
    }
}