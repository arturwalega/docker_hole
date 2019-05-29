using System.ComponentModel;
using System.Runtime.InteropServices;
using Shared.Docker.Models;
using RestSharp;

namespace Shared.Docker
{
    public class DockerClient
    {
        private string baseAdress;
        public DockerClient() {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (isWindows)
            {
                baseAdress = "http://localhost:2375";
            }

            var isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            if (isLinux)
            {
                baseAdress = "unix:/var/run/docker.sock";
            }
        }

        private RestClient CreateClient(string path){
            return new RestClient(baseAdress + path);
        }

        public Models.Container[] GetContainersList(){
            RestRequest restRequest = new RestRequest(Method.GET);
            var result = CreateClient("/containers/json").Execute(restRequest).Content;
            var containers = Models.Container.FromJson(result);
            return containers;
        }
    }
}