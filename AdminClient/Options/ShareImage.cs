using Docker.DotNet;
using Docker.DotNet.Models;
using Shared.ConsoleManagement;
using Shared.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AdminClient.Options
{
    public class ShareImage : MenuItem
    {
        public override async Task EnterOptionAsync()
        {
            DockerClient client = DockerUtility.CreateDockerClient();

            IList<ContainerListResponse> containers = await client.Containers.ListContainersAsync(
            new ContainersListParameters()
            {
                Limit = 10,
            });

            for (int i = 0; i < containers.Count; i++)
            {
                System.Console.WriteLine(i + ": " + DockerUtility.ConcatenateName(containers[i].Names));
            }
            int containerId = -1;
            while (true)
            {
                try
                {
                    var containerIdString = System.Console.ReadLine();
                    containerId = int.Parse(containerIdString);
                    break;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("Wrong number choose once again");
                }
            }

            if(containerId >= 0 && containerId < containers.Count){
                var constainer = containers[containerId];
                var task = client.Containers.ExportContainerAsync(constainer.ID);
                task.Wait();
                var stream = task.Result;
                // System.NotSupportedException everywhere
                FileStream fileStream = File.Create(DockerUtility.ConcatenateName(constainer.Names), (int)stream.Length);
                // Initialize the bytes array with the stream length and then fill it with data
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(bytesInStream, 0, bytesInStream.Length);    
                // Use write method to write to the file specified above
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                //Close the filestream
                fileStream.Close();
            }
        }

        public override string ShowMenuItemString()
        {
            return "Choose which of docker container will you choose to send to server.";
        }
    }
}