using System.Threading.Tasks;
using Shared.ConsoleManagement;

namespace AdminClient
{
    public class Start
    {
        public Start()
        {
            Menu menu = new Menu(this.GetType());
        }

        private static async Task StartAsync(Menu menu)
        {
            await menu.RunAsync();
        }
    }
}