namespace Shared.ConsoleManagement
{
    interface IMenuItem
    {
        string ShowMenuItemString();
        void EnterOption();
        void SetID(int id);
        int GetID();
    }
}