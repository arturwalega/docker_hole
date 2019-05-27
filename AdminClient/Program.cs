using System;
using System.Threading.Tasks;
using AdminClient.Options;
using Shared.ConsoleManagement;

namespace AdminClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var test = typeof(Program).AssemblyQualifiedName;
            Menu menu = new Menu(typeof(Program));

            await menu.RunAsync();
        }
    }
}
