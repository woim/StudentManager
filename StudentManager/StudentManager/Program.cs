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
 
            bool add = false;
            bool remove = false;
            string className = null;
            string studentName = null;

            // thses are the available options, not that they set the variables
            var options = new OptionSet {
                { "d|dataBase=", "the database.", v => dataBaseName = v },
                { "class=", "specify class on which we want to add/remove a student", v => className = v },
                { "student=", "specify student name [foremat: Name,FirstName1,FirstName2,FirstNameN]", v => studentName = v },
                { "a|add", "add an item to the data base either a class or a student" , v => add = v != null},
                { "r|remove", "remove an item from the data base either a class or a student" , v => remove = v != null},
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
            
            // Create the data base and load it with archive
            if ( String.IsNullOrEmpty(dataBaseName) )
            {
                Console.WriteLine("No file for database specified.");
                return;
            }

            DataBase dataBase = null;
            try
            {
                dataBase = new DataBase(dataBaseName);
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
            }    

            // Add a class
            if ( add == true && !String.IsNullOrEmpty(className) && String.IsNullOrEmpty(studentName) )
            {
                try
                {
                    dataBase.AddClass(className);
                }
                catch (Exception error)
                {
                    Console.Write(error.Message);
                }
            }

            // Remove a class
            if ( remove == true && !String.IsNullOrEmpty(className) && String.IsNullOrEmpty(studentName) )
            {
                try
                {
                    dataBase.RemoveClass(className);
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
                    if (add == true)
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
                }
                else
                {
                    Console.Write("Error class not specified.");
                    return;
                }
            }

            // Remove a student
            if (!String.IsNullOrEmpty(studentName))
            {
                if (!String.IsNullOrEmpty(className))
                {
                    if (remove == true)
                    {
                        try
                        {
                            dataBase.SelectCourse(className).RemoveStudent(studentName);
                        }
                        catch (Exception error)
                        {
                            Console.Write(error.Message);
                        }
                    }
                }
                else
                {
                    Console.Write("Error class not specified.");
                    return;
                }
            }
            
            // Wrtie the database
            dataBase.Save();
        }
    }
}
 