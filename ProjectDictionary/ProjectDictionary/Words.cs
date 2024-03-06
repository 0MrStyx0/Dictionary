using ProjectDictionary.ClassTranslations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDictionary.ClassWords
{
    internal class Words
    {
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

                if (Language == "Russian")
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if ((value[i] < 'А' || value[i] > 'Я') && (value[i] < 'а' || value[i] > 'я'))
                        {
                            throw new Exception("ERROR! DESCRIPTION: Only letters and no space ! Main language must be russian!");
                        }
                        else if (value[0] < 'А' || value[0] > 'Я')
                        {
                            throw new Exception("ERROR! DESCRIPTION: First letter must be uppercase!");
                        }
                        else if (i > 0 && (value[i] >= 'А' && value[i] <= 'Я'))
                        {
                            throw new Exception("ERROR! DESCRIPTION: Incorrect spelling, all letters except the first must be lowercase!");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if ((value[i] < 'A' || value[i] > 'Z') && (value[i] < 'a' || value[i] > 'z') && value[i] != '-')
                        {
                            throw new Exception("ERROR! DESCRIPTION: Only letters and no space ! Use Basic Latin letters!");
                        }
                        else if (value[0] < 'A' || value[0] > 'Z')
                        {
                            throw new Exception("ERROR! DESCRIPTION: First letter must be uppercase!");
                        }
                        else if (i > 0 && (value[i] >= 'A' && value[i] <= 'Z'))
                        {
                            throw new Exception("ERROR! DESCRIPTION: Incorrect spelling, all letters except the first must be lowercase!");
                        }
                    }
                }
                name = value;
            }
        }

        public string Language { get; set; }
        public List<Translations> Translations { get; } = new List<Translations>();
    }
}
