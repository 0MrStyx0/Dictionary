using ProjectDictionary.ClassDataStore;
using ProjectDictionary.ClassDictionary;
using ProjectDictionary.ClassOperation;
using ProjectDictionary.ClassPathes;

DataStore storage = new DataStore();
Pathes pathes = new Pathes();

Operation.LoadData(ref storage, ref pathes);

while (true)
{
    try
    {
        Console.WriteLine("MENU");
        Console.WriteLine("1.Create Dictionary\n2.List\n3.Delete Dictionary\n" +
            "4.Add Word\n5.Add Translation\n6.Replace Word\n7.Replace Translation\n" +
            "8.Delete Word\n9.Delete translation\n10.Show Dictionary\n11.Exit");
        Console.Write("--> ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Operation.CreateDictionary(ref storage, ref pathes);
                break;

            case 2:
                Operation.ShowDictionaries(ref storage);
                break;

            case 3:
                Operation.DeleteDictionary(ref storage, ref pathes);
                break;

            case 4:
                Operation.AddWord(ref storage);
                break;

            case 5:
                Operation.AddTranslation(ref storage);
                break;

            case 6:
                Operation.ReplaceWord(ref storage);
                break;

            case 7:
                Operation.ReplaceTranslation(ref storage);
                break;

            case 8:
                Operation.DeleteWord(ref storage);
                break;

            case 9:
                Operation.DeleteTranslation(ref storage);
                break;

            case 10:
                Operation.ShowDictionary(ref storage);
                break;

            case 11:
                Operation.SaveData(ref storage, ref pathes);
                Console.Clear();
                return;

            default:
                throw new Exception("ERROR! DESCRIPTION: Wrong menu choice!");
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
        Console.WriteLine("ERROR! DESCRIPTION: No letters or empty value! Only numbers in INT format!");
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