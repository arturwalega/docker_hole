using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.ConsoleManagement
{
    public class Menu
    {
        List<IMenuItem> options;
        Type currentClassInfo;

        public Menu(Type currentClassInfo)
        {
            this.currentClassInfo = currentClassInfo;
            options = new List<IMenuItem>();
            List<string> objects = GetAllEntities();
            AssignObjects(objects);          
        }

        void ShowOptions()
        {
            int counter = 1;
            foreach (var item in options)
            {
                Console.WriteLine("{0}. {1}", counter, item.ShowMenuItemString());
                counter++;
            }
            Console.WriteLine("0. Exit");
        }

        async Task<int> ChooseOptionAsync()
        {
            int selectedOption = ReadIntInput();
            if (selectedOption == 0)
                return -1;
            IMenuItem item = GetMenuItemByID(selectedOption);
            if (item != null)
            {
                Console.Clear();
                await item.EnterOptionAsync();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("There's no option with number {0}", selectedOption);
            }
            return 1;
        }

        string ReadInput()
        {
            string line = Console.ReadLine();
            return line;
        }

        int ReadIntInput()
        {
            try
            {
                return int.Parse(ReadInput());
            }
            catch (Exception)
            {
                Console.WriteLine("Entered text is not number");
                return -1;
            }
        }
        IMenuItem GetMenuItemByID(int id)
        {
            foreach (var item in options)
            {
                if (item.GetID() == id)
                    return item;
            }
            return null;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                ShowOptions();
                if (await ChooseOptionAsync().ConfigureAwait(false) == -1)
                    return;
            }
        }

        private List<string> GetAllEntities()
        {
            System.Console.WriteLine($"Test: {0}", this.currentClassInfo.Namespace);
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                 .Where(x => typeof(IMenuItem).IsAssignableFrom(x) && x.Namespace.Contains(currentClassInfo.Namespace) && !x.IsInterface && !x.IsAbstract)
                 .Select(x => x.Name).ToList();
        }

        private void AssignObjects(List<string> objectsNames)
        {
            int counter = 1;
            string namespaceName = currentClassInfo.Namespace.ToString();
            foreach (var item in objectsNames)
            {
                var className = namespaceName + '.' + "Options." + item + ", " + namespaceName + ",  Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
                var type = Type.GetType(className);
                var myObject = (IMenuItem)Activator.CreateInstance(type);
                myObject.SetID(counter);
                options.Add(myObject);
                counter++;
            }
        }
    }    
}

