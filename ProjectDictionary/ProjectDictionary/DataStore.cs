using ProjectDictionary.ClassDictionary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDictionary.ClassDataStore
{
    internal class DataStore : IEnumerable
    {
        public List<Dictionary> Dictionaries { get; } = new List<Dictionary>();

        public void Add(Dictionary dictionary)
        {
            for (int i = 0; i < Dictionaries.Count; i++)
            {
                if(dictionary.Name == Dictionaries[i].Name)
                {
                    throw new Exception("ERROR! DESCRIPTION: Dictionary is already created!");
                }
            }
            Dictionaries.Add(dictionary);
        }

        public void Delete(int num)
        {
            Dictionaries.RemoveAt(num);
        }

        public int getSize()
        {
            return Dictionaries.Count;
        }
        public IEnumerator GetEnumerator()
        {
            return Dictionaries.GetEnumerator();
        }
    }
}