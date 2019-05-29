using System.Threading.Tasks;

namespace Shared.ConsoleManagement
{
    public abstract class MenuItem : IMenuItem
    {
        int id;
        public int GetID(){
            return id;
        }
        public void SetID(int id){
            this.id = id;
        }
        public abstract string ShowMenuItemString();
        public abstract void EnterOption();
    }
}