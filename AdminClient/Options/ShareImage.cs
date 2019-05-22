using Shared.ConsoleManagement;
using System;

namespace AdminClient.Options
{
    public class ShareImage : MenuItem
    {
        public override void EnterOption()
        {
            while(true){
                // runRequest();
                System.Console.WriteLine("<- Previous, Next ->, Esc - Exit");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        //previous();
                        break;
                    case ConsoleKey.RightArrow:
                        //next();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }

        public override string ShowMenuItemString()
        {
            return "Change password strength policy.";
        }
    }
}