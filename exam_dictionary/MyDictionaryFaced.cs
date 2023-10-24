using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_dictionary
{
    public class DictionaryFacade
    {
        private IDataStorage dataStorage;
        private MyDictionary dictionary;
        private Menu menu;

        public DictionaryFacade()
        {
            dataStorage = new FileDataStorage();
            dictionary = new MyDictionary();
            menu = new Menu();
        }

        public void Start()
        {
            while (true)
            {
                menu.ShowMainMenu();
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("-------------------------");
                        dictionary.OpenDictionary(dataStorage);
                        Console.WriteLine("-------------------------");
                        DictionaryMenu();
                        break;

                    case 2:
                        Console.WriteLine("-------------------------");
                        dictionary.CreateDictionary(dataStorage);
                        Console.WriteLine("-------------------------");
                        DictionaryMenu();
                        break;

                    case 3:
                        Console.WriteLine("-------------------------");
                        dictionary.DeleteDictionary(dataStorage);
                        Console.WriteLine("-------------------------");
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void DictionaryMenu()
        {
            while (true)
            {
                menu.ShowDictionaryMenu();
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("-------------------------");
                        dictionary.SearchForTranslation();
                        Console.WriteLine("-------------------------");
                        break;
                    case 2:
                        Console.WriteLine("-------------------------");
                        DictionarySettingsMenu();
                        break;

                    case 3:
                        Console.WriteLine("-------------------------");
                        return;

                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void DictionarySettingsMenu()
        {
            while (true)
            {
                menu.ShowDictionarySettingsMenu();
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("-------------------------");
                        dictionary.AddNewWord(dataStorage);
                        Console.WriteLine("-------------------------");
                        break;

                    case 2:
                        Console.WriteLine("-------------------------");
                        dictionary.AddTranslation(dataStorage);
                        Console.WriteLine("-------------------------");
                        break;

                    case 3:
                        Console.WriteLine("-------------------------");
                        EditionMenu();
                        break;

                    case 4:
                        Console.WriteLine("-------------------------");
                        return;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void EditionMenu()
        {
            while (true)
            {
                menu.ShowEditDictionaryMenu();
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("-------------------------");
                        dictionary.EditKeyWord(dataStorage);
                        Console.WriteLine("-------------------------");
                        break;

                    case 2:
                        Console.WriteLine("-------------------------");
                        dictionary.EditTranslation(dataStorage);
                        Console.WriteLine("-------------------------");
                        break;

                    case 3:
                        Console.WriteLine("-------------------------");
                        dictionary.DeleteWord(dataStorage);
                        Console.WriteLine("-------------------------");
                        break;

                    case 4:
                        Console.WriteLine("-------------------------");
                        return;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

