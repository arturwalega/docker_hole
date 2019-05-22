using Shared.ConsoleManagement;

namespace AdminClient
{
    public class Start
    {
        public Start()
        {
            Menu menu = new Menu(this.GetType());
            menu.Run();
        }
    }
}