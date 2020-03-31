using System;
using System.IO;
using System.Globalization;
using Course.Entities;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path of your file: ");
            string sourcePath = Console.ReadLine();
            Item product;

            try
            {
                string[] list = File.ReadAllLines(sourcePath);

                string sourceFolder = Path.GetDirectoryName(sourcePath);
                string targetFolder = sourceFolder + @"\out";
                string targetFile = targetFolder + @"\summary.csv";

                Directory.CreateDirectory(targetFolder);

                using (StreamWriter sw = File.AppendText(targetFile))
                {
                    foreach (string x in list)
                    {
                        string[] var = x.Split(';');
                        string name = var[0];
                        double price = double.Parse(var[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(var[2]);
                        product = new Item(name, price, quantity);
                        sw.WriteLine(product);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Program Error");
                Console.WriteLine(e.Message);
            }
        }
    }
}
