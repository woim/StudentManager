using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//using Mono.Options;
using ClassLibrary;
using NDesk.Options;

namespace StudentManager
{
    class Program
    {
        static void ShowHelp(OptionSet options)
        {
            Console.WriteLine("Usage: StudentManager.exe [OPTIONS]");
            Console.WriteLine("Manage a school data base.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            options.WriteOptionDescriptions(Console.Out);
        }

        static void Main(string[] args)
        {
            // these variables will be set when the command line is parsed
            bool shouldShowHelp = false;
            string dataBaseName = null;
            string classNameToAdd = null;
            string classNameToRemove = null;
            string className = null;
            string studentName = null;

            // thses are the available options, not that they set the variables
            var options = new OptionSet {
                { "d|dataBase=", "the database.", v => dataBaseName = v },
                { "addClass=", "add class to database.", v => classNameToAdd = v },
                { "removeClass=", "remove class from database.", v => classNameToRemove = v },
                { "class=", "specify class on which we want to add/remove a student", v => className = v },
                { "addStudent=", "specify student name [foremat: Name,FirstName1,FirstName2,FirstNameN]", v => studentName = v },
                { "h|help", "show help message and exit", v => shouldShowHelp = v != null },
            };
            
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
            
            // Print help message
            if (shouldShowHelp || args.Length == 0)
            {
                ShowHelp(options);
                return;
            }

            // Create the data base and load it with arhive
            if ( String.IsNullOrEmpty(dataBaseName) )
            {
                Console.WriteLine("No file for database specified.");
                return;
            }

            // Load the data base
            DataBase dataBase = new DataBase(dataBaseName);


            // Add a class
            if (!String.IsNullOrEmpty(classNameToAdd))
            {
                try
                {
                    dataBase.AddClass(classNameToAdd);
                }
                catch (Exception error)
                {
                    Console.Write(error.Message);
                }
            }
            
            // Remove a class            
            if (!String.IsNullOrEmpty(classNameToRemove))
            {
                try
                {
                    dataBase.RemoveClass(classNameToRemove);
                }
                catch (Exception error)
                {
                    Console.Write(error.Message);
                }
            }

            // Add a student
            if (!String.IsNullOrEmpty(studentName))
            {
                if (!String.IsNullOrEmpty(className))
                {                    
                    try
                    {
                        dataBase.SelectCourse(className).AddStudent(studentName);
                    }
                    catch (Exception error)
                    {
                        Console.Write(error.Message);
                    }
                }
                else
                {
                    Console.Write("Error class not specified.");
                }
            }
             

            // Wrtie the database
            dataBase.Save();
        }
    }
}
 