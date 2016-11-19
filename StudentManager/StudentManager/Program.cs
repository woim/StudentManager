using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mono.Options;


namespace StudentManager
{

    class Program
    {

 

        static void Main(string[] args)
        {
            Console.Write("Hello");

            // these variables will be set when the command line is parsed
            var verbosity = 0;
            var shouldShowHelp = false;
            var names = new List<string>();
            var repeat = 1;

            // thses are the available options, not that they set the variables
            var options = new OptionSet {
                { "n|name=", "the name of someone to greet.", n => names.Add (n) },
                { "r|repeat=", "the number of times to repeat the greeting.", (int r) => repeat = r },
                { "v", "increase debug message verbosity", v => {
                    if (v != null)
                        ++verbosity;
                } },
                { "h|help", "show this message and exit", h => shouldShowHelp = h != null },
            };

            Console.WriteLine("Usage: OptionsSample.exe [OPTIONS]+ message");
            Console.WriteLine("Greet a list of individuals with an optional message.");
            Console.WriteLine("If no message is specified, a generic greeting is used.");
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
                Console.Write("greet: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `greet --help' for more information.");
                return;
            }
        }
    }
}
