using ProjectDictionary.ClassDataStore;
using ProjectDictionary.ClassDictionary;
using ProjectDictionary.ClassPathes;
using ProjectDictionary.ClassTranslations;
using ProjectDictionary.ClassWords;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDictionary.ClassOperation
{
    internal partial class Operation
    {
        public static void CreateDictionary(ref DataStore storage, ref Pathes pathes)
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
                    string path = $"Dictionaries\\{dictionary.Name}";
                    dictionary.Path = path;
                    storage.Add(dictionary);
                      
                    DirectoryInfo directory = new DirectoryInfo(path);
                    directory.Create();

                    pathes.Paths.Add(path);

                    string wordsPath = $"{directory.FullName}\\words.txt";
                    FileInfo words = new FileInfo(wordsPath);
                    FileStream fsWords = words.Create();
                    fsWords.Close();

                    string translationsPath = $"{directory.FullName}\\translations.txt";
                    FileInfo translations = new FileInfo(translationsPath);
                    FileStream fsTranslations = translations.Create();
                    fsTranslations.Close();
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
        public static void DeleteDictionary(ref DataStore storage, ref Pathes pathes)
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
                            string path = $"Dictionaries\\{storage.Dictionaries[i].Name}";
                            for(int j = 0; j < pathes.Paths.Count; j++)
                            {
                                if (path == pathes.Paths[j])
                                {
                                    pathes.Paths.RemoveAt(j);
                                }
                            }
                            DirectoryInfo directory = new DirectoryInfo(path);
                            directory.Delete(true);
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
        public static void SaveData(ref DataStore storage, ref Pathes pathes)
        {
            string pathesFile = "pathes.txt";

            using (StreamWriter writer = new StreamWriter(pathesFile, false, System.Text.Encoding.UTF8))
            {
                for (int i = 0; i < pathes.Paths.Count; i++)
                {
                    writer.WriteLine(pathes.Paths[i]);
                }
            }

            for (int i = 0; i < pathes.Paths.Count; i++) 
            {
                string wordsPath = $"{pathes.Paths[i]}\\words.txt";
                using (StreamWriter writer = new StreamWriter(wordsPath, false, System.Text.Encoding.UTF8))
                {
                    for (int j = 0; j < storage.Dictionaries.Count; j++) 
                    {
                        if (pathes.Paths[i] == storage.Dictionaries[j].Path)
                        {
                            for (int k = 0; k < storage.Dictionaries[j].Words.Count; k++)
                            {
                                writer.WriteLine(storage.Dictionaries[j].Words[k].Name);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < pathes.Paths.Count; i++)
            {
                string translationsPath = $"{pathes.Paths[i]}\\translations.txt";
                using (StreamWriter writer = new StreamWriter(translationsPath, false, System.Text.Encoding.UTF8))
                {
                    for (int j = 0; j < storage.Dictionaries.Count; j++)
                    {
                        if (pathes.Paths[i] == storage.Dictionaries[j].Path)
                        {
                            for (int k = 0; k < storage.Dictionaries[j].Words.Count; k++)
                            {
                                for (int m = 0; m < storage.Dictionaries[j].Words[k].Translations.Count; m++) 
                                {
                                    writer.WriteLine(storage.Dictionaries[j].Words[k].Translations[m].Translation);
                                }
                                writer.WriteLine("&");
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Data was saved!");
            Thread.Sleep(2000);
        }
        public static void LoadData(ref DataStore storage, ref Pathes pathes)
        {
            string pathesFile = "pathes.txt";
            FileInfo fileInfo = new FileInfo(pathesFile);
            if(!fileInfo.Exists )
            {
                FileStream fs = fileInfo.Create();
                fs.Close();
            }

            using (StreamReader reader = new StreamReader(pathesFile, System.Text.Encoding.UTF8)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    pathes.Paths.Add(line);
                }
            }

            for (int i = 0; i < pathes.Paths.Count; i++)
            {
                string dictionaryName = pathes.Paths[i].Substring(13);
                string mainLanguage = "";
                for (int j = 0; j < dictionaryName.Length; j++)
                {
                    if (dictionaryName[j] != '-')
                    {
                        mainLanguage += dictionaryName[j];
                    }
                    else break;
                }

                Dictionary dictionary = new Dictionary() { Name = dictionaryName, Path = pathes.Paths[i], MainLanguage = mainLanguage };
                storage.Dictionaries.Add(dictionary);
            }

            for (int i = 0; i < pathes.Paths.Count; i++)
            {
                string wordsPath = $"{pathes.Paths[i]}\\words.txt";
                using(StreamReader reader = new StreamReader(wordsPath, System.Text.Encoding.UTF8))
                {
                    for(int j = 0; j < storage.Dictionaries.Count; j++)
                    {
                        if (pathes.Paths[i] == storage.Dictionaries[j].Path)
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                Words word = new Words() { Language = storage.Dictionaries[j].MainLanguage, Name = line };
                                storage.Dictionaries[j].Words.Add(word);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < pathes.Paths.Count; i++)
            {
                string translationsPath = $"{pathes.Paths[i]}\\translations.txt";
                using (StreamReader reader = new StreamReader(translationsPath, System.Text.Encoding.UTF8))
                {
                    for (int j = 0; j < storage.Dictionaries.Count; j++)
                    {
                        if (pathes.Paths[i] == storage.Dictionaries[j].Path)
                        {
                            for (int k = 0; k < storage.Dictionaries[j].Words.Count; k++)
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (line == "&")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        int dictionaryNameLength = storage.Dictionaries[j].Name.Length;
                                        string dictionaryName = storage.Dictionaries[j].Name;
                                        string languageTranslation = "";
                                        for (int m = 0; m < dictionaryNameLength; m++)
                                        {
                                            if (dictionaryName[m] == '-')
                                            {
                                                for (int l = 0; l < dictionaryName.Substring(m + 1).Length; l++)
                                                {
                                                    languageTranslation += dictionaryName.Substring(m + 1)[l];
                                                }
                                                break;
                                            }
                                        }
                                        Translations translation = new Translations() { Language = languageTranslation, Translation = line };
                                        storage.Dictionaries[j].Words[k].Translations.Add(translation);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}