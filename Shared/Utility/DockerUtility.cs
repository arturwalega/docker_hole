using System;
using System.Collections.Generic;
using Docker.DotNet;

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

        public static DockerClient CreateDockerClient(){
            return new DockerClientConfiguration(new Uri("http://localhost:2375")).CreateClient();
        }
    }
}