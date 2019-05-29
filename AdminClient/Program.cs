using System;
using System.Threading.Tasks;
using AdminClient.Options;
using Shared.ConsoleManagement;

namespace AdminClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = typeof(Program).AssemblyQualifiedName;
            Menu menu = new Menu(typeof(Program));

            menu.Run();
        }
    }
}
