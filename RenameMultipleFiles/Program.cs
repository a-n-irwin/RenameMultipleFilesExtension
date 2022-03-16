using System;
using System.IO;

namespace RenameMultipleFilesExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowHeaderInterface();


            Console.Write("Enter path to files: ");

            string dir = Console.ReadLine();

            // Error message to handle empty path
            if (dir == String.Empty)
            {
                ShowErrorMessage("Path can not be empty!");
                return;
            }


            // remove encloseing double quotes
            if (dir[0] == dir[dir.Length - 1] && dir[0] == '"')
                dir = dir.Substring(1, dir.Length - 2);


            // check if the directory does not exist
            if (!Directory.Exists(dir))
            {
                ShowErrorMessage("Directory does not exist!");
                // end the program
                return;
            }


            Console.Write("Target extension: ");

            // get the target extension to replace
            string targetExt = Console.ReadLine();



            // Error message to handle empty target extension
            if (targetExt == String.Empty)
            {
                ShowErrorMessage("Target extension can not be empty!");
                return;
            }


            Console.Write("New extension: ");

            // get the new extension to rename the files to 
            string ext = Console.ReadLine();



            // Error message to handle empty new extension
            if (ext == String.Empty)
            {
                ShowErrorMessage("Extension can not be empty!");
                return;
            }


            // file names in the directory
            string[] files = Directory.GetFiles(dir,"*." + targetExt,SearchOption.AllDirectories);


            // rename file extensions
            foreach (string name in files)
            {
                File.Move(name, name.Substring(0, name.LastIndexOf(".") + 1) + ext);
            }


            Console.Read();
        }



        public static void ShowHeaderInterface()
        {
            WriteColor("\n\t\t---------- Welcome to File Extension Renamer! ----------\n\n", ConsoleColor.Green);

            WriteColor("\t\t\t\t Version: ", ConsoleColor.Green);
            Console.WriteLine("1.0");

            WriteColor("\t\t\t\tDeveloper: ", ConsoleColor.Green);
            Console.WriteLine("ANRI");

            WriteColor("\t\t\tEmail: ", ConsoleColor.Green);
            Console.WriteLine("yours.truly.anri@gmail.com");


            WriteColor("\n\t\tAbout: ", ConsoleColor.Green);
            Console.WriteLine("Rename the extension of multiple files. All files\n\t\twill have the same file extension. Drag in a directory\n\t\twhich contain the files, or one with subdirectories with\n\t\tthe files.\n\t\t");

            WriteColor("\t\t----------------------------------------------------------\n\n\n", ConsoleColor.Green);
        }



        public static void WriteColor(string message, ConsoleColor color)
        {
            ConsoleColor fgc = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.Write(message);

            Console.ForegroundColor = fgc;
        }


        public static void ShowErrorMessage(string message)
        {
            WriteColor("ERROR: ", ConsoleColor.Red);
            Console.WriteLine(message);

            Console.WriteLine("Please restart the program.\n");
            Console.Read();
        }
    }
}
