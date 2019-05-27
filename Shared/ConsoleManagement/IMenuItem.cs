using System.Threading.Tasks;

namespace Shared.ConsoleManagement
{
    public interface IMenuItem
    {
        string ShowMenuItemString();
        void SetID(int id);
        int GetID();
        Task EnterOptionAsync();
    }
}