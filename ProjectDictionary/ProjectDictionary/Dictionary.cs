using ProjectDictionary.ClassWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDictionary.ClassDictionary
{
    internal class Dictionary
    {
        public List<Words> Words { get; } = new List<Words>();

        public string MainLanguage {  get; set; }

        private static int num = 0;
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == "")
                {
                    throw new Exception("ERROR! DESCRIPTION: Empty value!");
                }
                bool isFound = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if ((value[i] < 'A' || value[i] > 'Z') && (value[i] < 'a' || value[i] > 'z') && value[i] != '-')
                    {
                        throw new Exception("ERROR! DESCRIPTION: Only letters and no space !");
                    }
                    else if (value[0] < 'A' || value[0] > 'Z')
                    {
                        throw new Exception("ERROR! DESCRIPTION: First letter must be uppercase!");
                    }
                    else if (i > 0 && (value[i] >= 'A' && value[i] <= 'Z'))
                    {
                        throw new Exception("ERROR! DESCRIPTION: Incorrect spelling, all letters except the first must be lowercase!");
                    }
                    else if (value[i] == '-' && i == value.Length - 1)
                    {
                        throw new Exception("ERROR! DESCRIPTION: Incorrect Name!");
                    }
                    else if(value[i] == '-'&& value[i+1] == '-')
                    {
                        throw new Exception("ERROR! DESCRIPTION: Only one hyphen!");
                    }
                    else if (value[i] == '-') isFound = true;
                    else if (isFound == false && i == value.Length - 1)
                    {
                        throw new Exception("ERROR! DESCRIPTION: Name must have '-' between 2 languages");
                    }
                }
                name = value;
            }
        }
        public Dictionary()
        {
            num++;
        }

        ~Dictionary()
        {
            num--;
        }
    }
}
