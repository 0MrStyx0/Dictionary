using ProjectDictionary.ClassDataStore;
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
        private static void DictionaryChoice(ref DataStore storage, out int ID, out string exit)
        {
            ID = 0;
            exit = "";
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
                    Console.Write("Choose dictionary (q to exit) --> ");
                    string dictionaryChoice = Console.ReadLine();
                    if (dictionaryChoice == "q")
                    {
                        exit = dictionaryChoice;
                        Console.Clear();
                        break;
                    }

                    ID = Convert.ToInt32(dictionaryChoice);

                    if (ID == 0 || ID > storage.getSize())
                    {
                        throw new Exception("ERROR! DESCRIPTION:Out of range!");
                    }
                    break;
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
        private static void TranslateAddition(ref DataStore storage, ref Words word, string wordWrite, int ID)
        {
            Console.Clear();
            Console.WriteLine("Dictionary: " + storage.Dictionaries[ID - 1].Name);
            Console.WriteLine("Word --> " + word.Name);
            while (true)
            {
                try
                {
                    Console.Write("Translation (q to exit) --> ");
                    string translationWrite = Console.ReadLine();
                    if (translationWrite == "q")
                    {
                        Console.Clear();
                        storage.Dictionaries[ID - 1].Words.Add(word);
                        break;
                    }

                    for (int i = 0; i < word.Translations.Count; i++)
                    {
                        if (translationWrite == word.Translations[i].Translation)
                        {
                            throw new Exception("ERROR! DESCRIPTION: the word already has this translation!");
                        }
                    }

                    int dictionaryNameLength = storage.Dictionaries[ID - 1].Name.Length;
                    string dictionaryName = storage.Dictionaries[ID - 1].Name;
                    string languageTranslation = "";
                    for (int i = 0; i < dictionaryNameLength; i++)
                    {
                        if (dictionaryName[i] == '-')
                        {
                            for (int j = 0; j < dictionaryName.Substring(i + 1).Length; j++)
                            {
                                languageTranslation += dictionaryName.Substring(i + 1)[j];
                            }
                            break;
                        }
                    }

                    Translations translation = new Translations() { Language = languageTranslation, Translation = translationWrite };
                    word.Translations.Add(translation);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static void WordAddition(ref DataStore storage, int ID)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Dictionary: " + storage.Dictionaries[ID - 1].Name);
                    Console.Write("Word (q to exit) --> ");
                    string wordWrite = Console.ReadLine();
                    if (wordWrite == "q")
                    {
                        Console.Clear();
                        break;
                    }

                    for (int i = 0; i < storage.Dictionaries[ID - 1].Words.Count; i++)
                    {
                        if (wordWrite == storage.Dictionaries[ID - 1].Words[i].Name)
                        {
                            throw new Exception("ERROR! DESCRIPTION: the dictionary already has this word!");
                        }
                    }

                    int dictionaryNameLength = storage.Dictionaries[ID - 1].Name.Length;
                    string dictionaryName = storage.Dictionaries[ID - 1].Name;
                    string languageWord = "";
                    for (int i = 0; i < dictionaryNameLength; i++)
                    {
                        if (dictionaryName[i] != '-')
                        {
                            languageWord += dictionaryName[i];
                        }
                        else break;
                    }

                    Words word = new Words() { Language = languageWord, Name = wordWrite };
                    Operation.TranslateAddition(ref storage, ref word, wordWrite, ID);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
        private static void Show(ref DataStore storage, int ID)
        {
            Console.Clear();
            Console.WriteLine($"\t\t\t\tDICTIONARY:\n\t\t\t{storage.Dictionaries[ID - 1].Name}");
            int size1 = storage.Dictionaries[ID - 1].Words.Count;


            char letter = ' ';
            if (storage.Dictionaries[ID - 1].MainLanguage == "Russian")
            {
                for (int l = 0; l < 29; l++)
                {
                    if (l == 0) letter = 'А';
                    else if (l == 1) letter = 'Б';
                    else if (l == 2) letter = 'В';
                    else if (l == 3) letter = 'Г';
                    else if (l == 4) letter = 'Д';
                    else if (l == 5) letter = 'Е';
                    else if (l == 6) letter = 'Ж';
                    else if (l == 7) letter = 'З';
                    else if (l == 8) letter = 'И';
                    else if (l == 9) letter = 'Й';
                    else if (l == 10) letter = 'К';
                    else if (l == 11) letter = 'Л';
                    else if (l == 12) letter = 'М';
                    else if (l == 13) letter = 'Н';
                    else if (l == 14) letter = 'О';
                    else if (l == 15) letter = 'П';
                    else if (l == 16) letter = 'Р';
                    else if (l == 17) letter = 'С';
                    else if (l == 18) letter = 'Т';
                    else if (l == 19) letter = 'У';
                    else if (l == 20) letter = 'Ф';
                    else if (l == 21) letter = 'Х';
                    else if (l == 22) letter = 'Ц';
                    else if (l == 23) letter = 'Ч';
                    else if (l == 24) letter = 'Ш';
                    else if (l == 25) letter = 'Щ';
                    else if (l == 26) letter = 'Э';
                    else if (l == 27) letter = 'Ю';
                    else if (l == 28) letter = 'Я';
                    Console.WriteLine("\t" + letter + "\n-------------------");
                    for (int i = 0; i < size1; i++)
                    {
                        if (storage.Dictionaries[ID - 1].Words[i].Name[0] == letter)
                        {
                            Console.Write(storage.Dictionaries[ID - 1].Words[i].Name + " -- ");
                            for (int j = 0; j < storage.Dictionaries[ID - 1].Words[i].Translations.Count; j++)
                            {
                                if (j == storage.Dictionaries[ID - 1].Words[i].Translations.Count - 1)
                                {
                                    Console.Write(storage.Dictionaries[ID - 1].Words[i].Translations[j].Translation);
                                }
                                else
                                {
                                    Console.Write(storage.Dictionaries[ID - 1].Words[i].Translations[j].Translation + ", ");
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
            else
            {
                for (int l = 0; l < 26; l++)
                {
                    if (l == 0) letter = 'A';
                    else if (l == 1) letter = 'B';
                    else if (l == 2) letter = 'C';
                    else if (l == 3) letter = 'D';
                    else if (l == 4) letter = 'E';
                    else if (l == 5) letter = 'F';
                    else if (l == 6) letter = 'G';
                    else if (l == 7) letter = 'H';
                    else if (l == 8) letter = 'I';
                    else if (l == 9) letter = 'J';
                    else if (l == 10) letter = 'K';
                    else if (l == 11) letter = 'L';
                    else if (l == 12) letter = 'M';
                    else if (l == 13) letter = 'N';
                    else if (l == 14) letter = 'O';
                    else if (l == 15) letter = 'P';
                    else if (l == 16) letter = 'Q';
                    else if (l == 17) letter = 'R';
                    else if (l == 18) letter = 'S';
                    else if (l == 19) letter = 'T';
                    else if (l == 20) letter = 'U';
                    else if (l == 21) letter = 'V';
                    else if (l == 22) letter = 'W';
                    else if (l == 23) letter = 'X';
                    else if (l == 24) letter = 'Y';
                    else if (l == 25) letter = 'Z';
                    Console.WriteLine("\t" + letter + "\n-------------------");
                    for (int i = 0; i < size1; i++)
                    {
                        if (storage.Dictionaries[ID - 1].Words[i].Name[0] == letter)
                        {
                            Console.Write(storage.Dictionaries[ID - 1].Words[i].Name + " -- ");
                            for (int j = 0; j < storage.Dictionaries[ID - 1].Words[i].Translations.Count; j++)
                            {
                                if (j == storage.Dictionaries[ID - 1].Words[i].Translations.Count - 1)
                                {
                                    Console.Write(storage.Dictionaries[ID - 1].Words[i].Translations[j].Translation);
                                }
                                else
                                {
                                    Console.Write(storage.Dictionaries[ID - 1].Words[i].Translations[j].Translation + ", ");
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
            Console.WriteLine("PRESS ENTER TO ESCAPE");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            Console.Clear();
        }
        private static void Searching(ref DataStore storage, int ID, string option)
        {
            while (true)
            {
                if (storage.Dictionaries[ID - 1].Words.Count == 0)
                {
                    Console.Clear();
                    throw new Exception("You haven't created any words!");
                }
                try
                {
                    Console.Clear();
                    Console.WriteLine("Dictionary: " + storage.Dictionaries[ID - 1].Name);
                    Console.Write("Word (q to exit) --> ");
                    string word = Console.ReadLine();
                    if (word == "q")
                    {
                        Console.Clear();
                        break;
                    }

                    bool isFound = false;
                    for (int i = 0; i < storage.Dictionaries[ID - 1].Words.Count; i++)
                    {
                        if (word == storage.Dictionaries[ID - 1].Words[i].Name)
                        {
                            isFound = true;
                            if (option == "AddTranslation")
                            {
                                Operation.Filling(ref storage, ID, i);
                            }
                            else if (option == "ReplaceWord")
                            {
                                Operation.ProcessReplaceWord(ref storage, ID, i);
                            }
                            else if (option == "ReplaceTranslation")
                            {
                                Operation.ProcessReplaceTranslation(ref storage, ID, i);
                            }
                            else if (option == "DeleteWord")
                            {
                                storage.Dictionaries[ID - 1].Words.RemoveAt(i);
                                Console.WriteLine("Delete succesfull!");
                                Thread.Sleep(2000);
                            }
                            else if (option == "DeleteTranslation") 
                            {
                                Operation.ProcessDeleteTranslation(ref storage, ID, i);
                            }
                            break;
                        }
                        else if (isFound == false && i == storage.Dictionaries[ID - 1].Words.Count - 1)
                        {
                            throw new Exception("ERROR! DESCRIPTION: cant find the word!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
        private static void Filling(ref DataStore storage, int ID, int i)
        {
            Console.Clear();
            Console.WriteLine("Dictionary: " + storage.Dictionaries[ID - 1].Name);
            Console.WriteLine("Word --> " + storage.Dictionaries[ID - 1].Words[i].Name);
            while (true)
            {
                try
                {
                    Console.Write("Translation (q to exit) --> ");
                    string translation = Console.ReadLine();
                    if (translation == "q")
                    {
                        Console.Clear();
                        break;
                    }

                    for (int j = 0; j < storage.Dictionaries[ID - 1].Words[i].Translations.Count; j++)
                    {
                        if (translation == storage.Dictionaries[ID - 1].Words[i].Translations[j].Translation)
                        {
                            throw new Exception("ERROR! DESCRIPTION: the word already has this translation!");
                        }
                    }

                    int dictionaryNameLength = storage.Dictionaries[ID - 1].Name.Length;
                    string dictionaryName = storage.Dictionaries[ID - 1].Name;
                    string languageTranslation = "";
                    for (int j = 0; j < dictionaryNameLength; j++)
                    {
                        if (dictionaryName[j] == '-')
                        {
                            for (int k = 0; k < dictionaryName.Substring(j + 1).Length; k++)
                            {
                                languageTranslation += dictionaryName.Substring(j + 1)[k];
                            }
                            break;
                        }
                    }
                    Translations value = new Translations() { Language = languageTranslation, Translation = translation };
                    storage.Dictionaries[ID - 1].Words[i].Translations.Add(value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static void ProcessReplaceWord(ref DataStore storage, int ID, int i)
        {
            Console.Clear();
            Console.WriteLine("Dictionary: " + storage.Dictionaries[ID - 1].Name);
            Console.WriteLine("Word --> " + storage.Dictionaries[ID - 1].Words[i].Name);
            while (true)
            {
                try
                {
                    Console.Write("Replace (q to exit) --> ");
                    string replace = Console.ReadLine();
                    if (replace == "q")
                    {
                        Console.Clear();
                        break;
                    }
                    storage.Dictionaries[ID - 1].Words[i].Name = replace;
                    Console.WriteLine("Replace successfull!");
                    Thread.Sleep(2000);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                }
            }
        }
        private static void ProcessReplaceTranslation(ref DataStore storage, int ID, int i)
        {
            Console.Clear();
            Console.WriteLine("Dictionary: " + storage.Dictionaries[ID - 1].Name);
            Console.WriteLine("Word --> " + storage.Dictionaries[ID - 1].Words[i].Name);

            while (true)
            {
                try
                {
                    Console.Write("Translation (q to exit) --> ");
                    string translation = Console.ReadLine();
                    if (translation == "q")
                    {
                        Console.Clear();
                        break;
                    }
                    for (int j = 0; j < storage.Dictionaries[ID - 1].Words[i].Translations.Count; j++)
                    {
                        if (translation == storage.Dictionaries[ID - 1].Words[i].Translations[j].Translation)
                        {
                            Console.Write("Replace (q to exit) --> ");
                            string replace = Console.ReadLine();
                            if (replace == "q")
                            {
                                break;
                            }

                            storage.Dictionaries[ID - 1].Words[i].Translations[j].Translation = replace;
                            Console.WriteLine("Replace succesfull!");
                            Thread.Sleep(2000);
                            break;
                        }
                        else if (j == storage.Dictionaries[ID - 1].Words[i].Translations.Count - 1) 
                        {
                            throw new Exception("ERROR! DESCRIPTION: cant find the translation!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                }
            }
        }
        private static void ProcessDeleteTranslation(ref DataStore storage, int ID, int i)
        {
            Console.Clear();
            Console.WriteLine("Dictionary: " + storage.Dictionaries[ID - 1].Name);
            Console.WriteLine("Word --> " + storage.Dictionaries[ID - 1].Words[i].Name);

            while (true)
            {
                try
                {
                    Console.Write("Translation (q to exit) --> ");
                    string translation = Console.ReadLine();
                    if (translation == "q")
                    {
                        Console.Clear();
                        break;
                    }

                    if(storage.Dictionaries[ID - 1].Words[i].Translations.Count == 1)
                    {
                        throw new Exception("ERROR! DESCRIPTION: you cant delete word with one translation!");
                    }

                    for (int j = 0; j < storage.Dictionaries[ID - 1].Words[i].Translations.Count; j++)
                    {
                        if (translation == storage.Dictionaries[ID - 1].Words[i].Translations[j].Translation)
                        {
                            storage.Dictionaries[ID - 1].Words[i].Translations.RemoveAt(j);
                            Console.WriteLine("Delete succesfull!");
                            Thread.Sleep(2000);
                            break;
                        }
                        else if (j == storage.Dictionaries[ID - 1].Words[i].Translations.Count - 1)
                        {
                            throw new Exception("ERROR! DESCRIPTION: cant find the translation!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                }
            }
        }
    }
}