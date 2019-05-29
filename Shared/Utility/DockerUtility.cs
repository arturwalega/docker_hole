using System;
using System.Collections.Generic;

namespace Shared.Utility
{
    public class DockerUtility
    {
        public static string ConcatenateName(IList<string> names){
            var name = "";
            foreach (var item in names)
            {
                name += item + " ";
            }
            return name;
        }
    }
}