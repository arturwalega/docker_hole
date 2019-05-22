using System;
using AdminClient.Options;
using Shared.ConsoleManagement;

namespace AdminClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = typeof(ShareImage).AssemblyQualifiedName;
            System.Console.WriteLine($"No fajnie: {0}", test.ToString());  
            Menu menu = new Menu(typeof(Program));
            
            menu.Run();
        }
    }
}
