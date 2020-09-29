using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace UkolOdVitka1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WaitRandomTimeThenExecute();
                PickNumberAndWriteToFile();
            }
           
           





            Console.ReadKey();
        }

        public static string GetFilePath()
        {
            string filePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string filePathTxt = filePath + "\\dataToProcess.txt";
            filePathTxt = filePathTxt.Remove(0, 6);
            return filePathTxt;
        }
        public static string GetNumberbetveen0to5()
        {
            string _number = "";
            while (_number != "0"&& _number != "1" && _number != "2" && _number != "3" && _number != "4" && _number != "5") 
            {
                Console.WriteLine("zadejte 1-5 pro zadani hodnoty\n0 pro ukončení programu");
                _number = Console.ReadLine();
            }
            return _number; 
        }

        public static void PickNumberAndWriteToFile()
        {
           

            if (!File.Exists(GetFilePath()))
            {
                File.WriteAllText(GetFilePath(), "");
            }

            string SNumberToSave = "";
            while (SNumberToSave != "0")
            {
                SNumberToSave = GetNumberbetveen0to5();
                if (SNumberToSave == "1" || SNumberToSave == "2" || SNumberToSave == "3" || SNumberToSave == "4" || SNumberToSave == "5")
                {
                    File.AppendAllText(GetFilePath(), SNumberToSave + Environment.NewLine);
                    Console.WriteLine("cislo pridano");
                }
            }
        }
        public static string ReadFirsLine()
        {
            string lastNumberOfFile = File.ReadAllLines(GetFilePath()).First();
            return lastNumberOfFile;
            
            // DataToSave data = new DataToSave(lastNumberOfFile);
           // Console.WriteLine(data.ToString());
        }



       public static void DeleteFirstLine()
        {
            var AllLines = File.ReadAllLines(GetFilePath());
            File.WriteAllLines(GetFilePath(), AllLines.Skip(1));
        }

        public static void ExecuteReading()
        {
            try
            {
                string sfirstLine = ReadFirsLine();
                DataToSave data = new DataToSave(sfirstLine);
                Console.WriteLine(data.ToString());
                DeleteFirstLine();
            }
            catch (Exception)
            {

                Console.WriteLine("Zasobnik je prazdny");
            }
            
        }

        public static Task WaitRandomTimeThenExecute()
        {
            int randomNumber = 1000 * GenerateRandomNumber(1, 10);
            return Task.Run(() =>
            {
                Thread.Sleep(randomNumber);
                ExecuteReading();
            });
        }
        public static int GenerateRandomNumber(int min, int max)
        {
            Random _random = new Random();
            return _random.Next(min, max);
        }
    }
    


}
