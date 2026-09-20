using Behavioral.TemplateMethod.Example1;
using Behavioral.TemplateMethod.Example2;

namespace Behavioral.TemplateMethod
{
    public class TemplateMethodRunner
    {
        public static void Execute()
        {
            Console.WriteLine();
            Console.WriteLine("========= TEMPLATE METHOD =========");
            Console.WriteLine();

            #region Example 1 : 

            Console.WriteLine();
            Console.WriteLine("========= Example 1 : =========");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("----- ConcreteClass1 : -----");
            Console.WriteLine();

            var templateMethodInstance = new ConcreteClass();

            templateMethodInstance.TemplateMethod();

            Console.WriteLine();
            Console.WriteLine("----- ConcreteClass2 : -----");
            Console.WriteLine();

            var templateMethodInstance2 = new ConcreteClass2();

            templateMethodInstance2.TemplateMethod();

            #endregion

            #region Example 2 : 

            Console.WriteLine();
            Console.WriteLine("========= Example 2 : =========");
            Console.WriteLine();

            FileParser csvParser = new CSVParser();
            JSONParser jSONParser = new JSONParser();

            var csvData = csvParser.ParseFile("C:\\Users\\heito\\Desktop\\designpatterns\\DesignPatterns\\Behavioral\\TemplateMethod\\config.csv");
            var jsonData = jSONParser.ParseFile("C:\\Users\\heito\\Desktop\\designpatterns\\DesignPatterns\\Behavioral\\TemplateMethod\\config.json");
            
            Console.WriteLine();
            Console.WriteLine("Printing CSV Data : ");
            foreach(var pair in csvData)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
            Console.WriteLine();

            Console.WriteLine("Printing JSON Data : ");
            foreach (var pair in jsonData)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
            Console.WriteLine();

            #endregion
        }
    }
}
