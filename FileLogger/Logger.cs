using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogger
{
    public class Logger
    {
        private readonly string fileName; //stała a readonly -> conts musi miec od razu wartosc przypisaną, a readonly raz ale w dowolnej metodzie
        private static string directory; //zmienne w klasie bez modyfikatora dostepu maja domyślnie private, key z appconfig


        //const string filename2 = "stała";

        public Logger() //ctr tab tab ->tworzenie konstruktora
        {
            setDirectory();
        }

        public Logger(string filename) //ctrl + . -> tworzenie properties / fields
        {
            this.fileName = filename; // konstruktor -> stworzenie obiektu, this -> odniesienie do aktualnego obiektu
            setDirectory();
        }

        public void Log(string text)
        {
          
            try
            {
                // File.AppendAllLines(Path.Combine(directory, fileName), new string[] { text });
                CreateDirectory();
                File.AppendAllText(Path.Combine(directory, fileName), $"{Environment.NewLine} Data: {DateTime.Now.ToShortDateString()} Informacja: {text}");
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Log(text);
            }

        }

        private static void CreateDirectory()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void setDirectory()
        {
            try
            {
                //var file = System.Configuration.ConfigurationManager.OpenExeConfiguration("~/FileLogger.dll.config");
                directory = System.Configuration.ConfigurationManager.AppSettings["dir"];
            }
            catch  (FileNotFoundException fnfe)
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
