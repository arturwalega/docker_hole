using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.ConsoleManagement
{
    public class Menu
    {
        List<IMenuItem> options;
        Type currentClassInfo;

        public Menu(Type currentClassInfo)
        {
            options = new List<IMenuItem>();
            List<string> objects = GetAllEntities();
            AssignObjects(objects);
            this.currentClassInfo = currentClassInfo;
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

        int ChooseOption()
        {
            int selectedOption = ReadIntInput();
            if (selectedOption == 0)
                return -1;
            IMenuItem item = GetMenuItemByID(selectedOption);
            if (item != null)
            {
                Console.Clear();
                item.EnterOption();
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

        public void Run()
        {
            while (true)
            {
                ShowOptions();
                if (ChooseOption() == -1)
                    return;
            }
        }

        private List<string> GetAllEntities()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                 .Where(x => typeof(IMenuItem).IsAssignableFrom(x) && x.Namespace.Equals(currentClassInfo.Namespace) && !x.IsInterface && !x.IsAbstract)
                 .Select(x => x.Name).ToList();
        }

        private void AssignObjects(List<string> objectsNames)
        {
            int counter = 1;
            string namespaceName = typeof(Menu).Namespace;
            foreach (var item in objectsNames)
            {
                var type = Type.GetType(namespaceName + '.' + item);
                var myObject = (IMenuItem)Activator.CreateInstance(type);
                myObject.SetID(counter);
                options.Add(myObject);
                counter++;
            }
        }
    }
}

