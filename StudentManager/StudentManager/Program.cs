using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Mono.Options;
using ClassLibrary;

namespace StudentManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // these variables will be set when the command line is parsed
            //var verbosity = 0;
            var shouldShowHelp = true;
            string dataBaseName = null;
            string className = null;
            //var repeat = 1;

            // thses are the available options, not that they set the variables
            var options = new OptionSet {
                { "d|dataBase", "the database.", d => dataBaseName = d },
                { "addClass=", "add class to the database.", addClass => className = addClass },
                //{ "r|repeat=", "the number of times to repeat the greeting.", (int r) => repeat = r },
                //{ "v", "increase debug message verbosity", v => {
                //    if (v != null)
                //        ++verbosity;
                //} },
                { "h|help", "show help message and exit", h => shouldShowHelp = h != null },
            };

            Console.WriteLine("Usage: StudentManager.exe [OPTIONS]");
            Console.WriteLine("Manage a school data base.");
            Console.WriteLine();

            // output the options
            Console.WriteLine("Options:");
            options.WriteOptionDescriptions(Console.Out);

            List<string> extra;
            try
            {
                // parse the command line
                extra = options.Parse(args);
            }
            catch (OptionException e)
            {
                // output some error message
                Console.Write("StudentManager: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `StudentManager.exe --help' for more information.");
                return;
            }

            // Create the data base and load it with arhive
            DataBase dataBase = new DataBase(dataBaseName);
            
            if (!String.IsNullOrEmpty(className))
            {
                dataBase.AddClass(className);
            }
        }
    }
}
