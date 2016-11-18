using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fclp;



namespace StudentManager
{
    public class ApplicationArguments
    {
        public int RecordId { get; set; }
        public bool Silent { get; set; }
        public string NewValue { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello");

            // create a generic parser for the ApplicationArguments type
            var p = new FluentCommandLineParser<ApplicationArguments>();

            // specify which property the value will be assigned too.
            p.Setup(arg => arg.RecordId)
             .As('r', "record") // define the short and long option name
             .Required() // using the standard fluent Api to declare this Option as required.
             .WithDescription("Execute operation in silent mode without feedback");

            p.Setup(arg => arg.NewValue)
             .As('v', "value")
             .Required();

            p.Setup(arg => arg.Silent)
             .As('s', "silent")
             .SetDefault(false); // use the standard fluent Api to define a default value if non is specified in the arguments

            p.SetupHelp("?", "help")
             .Callback(text => Console.WriteLine(text));

            // triggers the SetupHelp Callback which writes the text to the console
            p.HelpOption.ShowHelp(p.Options);

            var result = p.Parse(args);            

            //if (result.HasErrors == false)
            //{
            //    // use the instantiated ApplicationArguments object from the Object property on the parser.
            //    application.Run(p.Object);
            //}
        }
    }
}
