using ProjectDictionary.ClassDataStore;
using ProjectDictionary.ClassDictionary;
using ProjectDictionary.ClassTranslations;
using ProjectDictionary.ClassWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDictionary.ClassOperation
{
    internal partial class Operation
    {
        public static void CreateDictionary(ref DataStore storage)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Recommended for russian language: write 'Russian' or 'russian' in name");
                    Console.Write("Name (q to exit) --> ");
                    string name = Console.ReadLine();
                    if (name == "q")
                    {
                        Console.Clear();
                        break;
                    }

                    Dictionary dictionary = new Dictionary() { Name = name };
                    string MainLanguage = "";
                    for (int i = 0; i < dictionary.Name.Length; i++) 
                    {
                        if (dictionary.Name[i] != '-')
                        {
                            MainLanguage += dictionary.Name[i];
                        }
                        else break;
                    }
                    dictionary.MainLanguage = MainLanguage;
                    storage.Add(dictionary);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                }
            }
        }
        public static void ShowDictionaries(ref DataStore storage)
        {
            Console.Clear();
            Console.WriteLine("DICTIONARY LIST\n");
            foreach (Dictionary dictionary in storage)
            {
                Console.WriteLine(dictionary.Name + "\n");
            }
            Console.WriteLine("PRESS ENTER TO ESCAPE");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            Console.Clear();
        }
        public static void DeleteDictionary(ref DataStore storage)
        {
            while (true)
            {
                if (storage.getSize() == 0)
                {
                    Console.Clear();
                    throw new Exception("You haven't created any dictionary");
                }
                try
                {
                    Console.Clear();
                    for (int i = 0; i < storage.getSize(); i++)
                    {
                        Console.WriteLine((i + 1) + "." + storage.Dictionaries[i].Name);
                    }

                    Console.Write("Choose to delete (q to exit) --> ");
                    string choice = Console.ReadLine();
                    if (choice == "q")
                    {
                        Console.Clear();
                        break;
                    }

                    if (Convert.ToInt32(choice) == 0 || Convert.ToInt32(choice) > storage.getSize()) 
                    {
                        throw new Exception("ERROR! DESCRIPTION:Out of range!");
                    }

                    for (int i = 0; i < storage.getSize(); i++)
                    {
                        if (Convert.ToInt32(choice) == i + 1)
                        {
                            storage.Delete(i);
                        }
                    }
                    if (storage.getSize() == 0)
                    {
                        Console.Clear();
                        break;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("ERROR! DESCRIPTION: Value is too larg for INT!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERROR! DESCRIPTION: Only number!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
        public static void AddWord(ref DataStore storage)
        {
            int ID;
            string exit;
            while (true)
            {
                Operation.DictionaryChoice(ref storage, out ID, out exit);
                if (exit == "q")
                {
                    Console.Clear();
                    return;
                }
                else Operation.WordAddition(ref storage, ID);
            }
        }
        public static void ShowDictionary(ref DataStore storage)
        {
            int ID;
            string exit;
            while (true)
            {
                Operation.DictionaryChoice(ref storage, out ID, out exit);
                if (exit == "q")
                {
                    Console.Clear();
                    return;
                }
                else Operation.Show(ref storage, ID);
            }
        }
        public static void AddTranslation(ref DataStore storage)
        {
            int ID;
            string exit;
            string option = "AddTranslation";
            while (true)
            {
                Operation.DictionaryChoice(ref storage, out ID, out exit);
                if (exit == "q")
                {
                    Console.Clear();
                    return;
                }
                else Operation.Searching(ref storage, ID, option);
            }
        }
        public static void ReplaceWord(ref DataStore storage)
        {
            int ID;
            string exit;
            string option = "ReplaceWord";
            while (true)
            {
                Operation.DictionaryChoice(ref storage, out ID, out exit);
                if (exit == "q")
                {
                    Console.Clear();
                    return;
                }
                else Operation.Searching(ref storage, ID, option);
            }
        }
        public static void ReplaceTranslation(ref DataStore storage)
        {
            int ID;
            string exit;
            string option = "ReplaceTranslation";
            while (true)
            {
                Operation.DictionaryChoice(ref storage, out ID, out exit);
                if (exit == "q")
                {
                    Console.Clear();
                    return;
                }
                else Operation.Searching(ref storage, ID, option);
            }
        }
        public static void DeleteWord(ref DataStore storage)
        {
            int ID;
            string exit;
            string option = "DeleteWord";
            while (true)
            {
                Operation.DictionaryChoice(ref storage, out ID, out exit);
                if (exit == "q")
                {
                    Console.Clear();
                    return;
                }
                else Operation.Searching(ref storage, ID, option);
            }
        }
        public static void DeleteTranslation(ref DataStore storage)
        {
            int ID;
            string exit;
            string option = "DeleteTranslation";
            while (true)
            {
                Operation.DictionaryChoice(ref storage, out ID, out exit);
                if (exit == "q")
                {
                    Console.Clear();
                    return;
                }
                else Operation.Searching(ref storage, ID, option);
            }
        }
    }
}