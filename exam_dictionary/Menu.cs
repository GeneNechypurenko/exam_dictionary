using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_dictionary
{
    public class Menu
    {
        public void ShowMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Open Dictionary");
            Console.WriteLine("2. Create Dictionary");
            Console.WriteLine("3. Delete Dictionary");
            Console.WriteLine("4. Exit");
        }

        public void ShowDictionaryMenu()
        {
            Console.WriteLine("Dictionary Menu:");
            Console.WriteLine("1. Search for Translation");
            Console.WriteLine("2. Dictionary Settings");
            Console.WriteLine("3. Back");
            Console.WriteLine("4. Exit");
        }

        public void ShowDictionarySettingsMenu()
        {
            Console.WriteLine("Dictionary Settings:");
            Console.WriteLine("1. Add New Word");
            Console.WriteLine("2. Add Translation");
            Console.WriteLine("3. Edit Dictionary");
            Console.WriteLine("4. Back");
            Console.WriteLine("5. Exit");
        }

        public void ShowEditDictionaryMenu()
        {
            Console.WriteLine("Edition Settings:");
            Console.WriteLine("1. Edit Key Word");
            Console.WriteLine("2. Edit Translation");
            Console.WriteLine("3. Delete Word");
            Console.WriteLine("4. Back");
            Console.WriteLine("5. Exit");
        }
    }
}
