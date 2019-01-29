using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogger
{
    public class Logger
    {
        private readonly string filename; //stała a readonly -> conts musi miec od razu wartosc przypisaną, a readonly raz ale w dowolnej metodzie


        public Logger() //ctr tab tab ->tworzenie konstruktora
        {
                
        }

        public Logger(string filename) //ctrl + . -> tworzenie properties / fields
        {
            this.filename = filename;
        }
    }
}
