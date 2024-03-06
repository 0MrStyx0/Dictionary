using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDictionary.ClassTranslations
{
    internal class Translations
    {
        private string translation;
        public string Translation
        {
            get { return translation; }
            set
            {
                if (value == "")
                {
                    throw new Exception("ERROR! DESCRIPTION: Empty value!");
                }

                if (Language == "russian")
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if ((value[i] < 'а' || value[i] > 'я'))
                        {
                            throw new Exception("ERROR! DESCRIPTION: Only letters and no space ! Main language must be russian! Only lower case!");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if ((value[i] < 'a' || value[i] > 'z') && value[i] != '-')
                        {
                            throw new Exception("ERROR! DESCRIPTION: Only letters and no space ! Use Basic Latin letters! Only lower case!");
                        }
                    }
                }
                translation = value;
            }
        }

        public string Language { get; set; }
    }
}
