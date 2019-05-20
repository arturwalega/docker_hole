using System;
using Shared.ConsoleManagement;

namespace AdminClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(typeof(Program));
        }
    }
}
