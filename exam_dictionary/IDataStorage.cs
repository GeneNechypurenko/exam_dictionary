using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_dictionary
{
    public interface IDataStorage
    {
        public abstract void SaveData(string data);
        public abstract string LoadData();
        public abstract void ShowSources();
        public abstract void OpenSource(string sourceName);
        public abstract void DeleteSource(string sourceName);
    }
}