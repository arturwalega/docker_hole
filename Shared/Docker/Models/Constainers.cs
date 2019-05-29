namespace Shared.Docker.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Container
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Names")]
        public string[] Names { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("ImageID")]
        public string ImageId { get; set; }

        [JsonProperty("Command")]
        public string Command { get; set; }

        [JsonProperty("Created")]
        public long Created { get; set; }

        [JsonProperty("Ports")]
        public Port[] Ports { get; set; }

        [JsonProperty("Labels")]
        public Labels Labels { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("HostConfig")]
        public HostConfig HostConfig { get; set; }

        [JsonProperty("NetworkSettings")]
        public NetworkSettings NetworkSettings { get; set; }

        [JsonProperty("Mounts")]
        public Mount[] Mounts { get; set; }

        public string GetName(){
            var name = "";
            foreach (var item in Names)
            {
                name += item;
            }
            return name + "\t" + Image;
        }
    }

    public partial class HostConfig
    {
        [JsonProperty("NetworkMode")]
        public string NetworkMode { get; set; }
    }

    public partial class Labels
    {
    }

    public partial class Mount
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Destination")]
        public string Destination { get; set; }

        [JsonProperty("Driver")]
        public string Driver { get; set; }

        [JsonProperty("Mode")]
        public string Mode { get; set; }

        [JsonProperty("RW")]
        public bool Rw { get; set; }

        [JsonProperty("Propagation")]
        public string Propagation { get; set; }
    }

    public partial class NetworkSettings
    {
        [JsonProperty("Networks")]
        public Networks Networks { get; set; }
    }

    public partial class Networks
    {
        [JsonProperty("bridge")]
        public Bridge Bridge { get; set; }
    }

    public partial class Bridge
    {
        [JsonProperty("IPAMConfig")]
        public object IpamConfig { get; set; }

        [JsonProperty("Links")]
        public object Links { get; set; }

        [JsonProperty("Aliases")]
        public object Aliases { get; set; }

        [JsonProperty("NetworkID")]
        public string NetworkId { get; set; }

        [JsonProperty("EndpointID")]
        public string EndpointId { get; set; }

        [JsonProperty("Gateway")]
        public string Gateway { get; set; }

        [JsonProperty("IPAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("IPPrefixLen")]
        public long IpPrefixLen { get; set; }

        [JsonProperty("IPv6Gateway")]
        public string IPv6Gateway { get; set; }

        [JsonProperty("GlobalIPv6Address")]
        public string GlobalIPv6Address { get; set; }

        [JsonProperty("GlobalIPv6PrefixLen")]
        public long GlobalIPv6PrefixLen { get; set; }

        [JsonProperty("MacAddress")]
        public string MacAddress { get; set; }

        [JsonProperty("DriverOpts")]
        public object DriverOpts { get; set; }
    }

    public partial class Port
    {
        [JsonProperty("PrivatePort")]
        public long PrivatePort { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }
    }

    public partial class Container
    {
        public static Container[] FromJson(string json) => JsonConvert.DeserializeObject<Container[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Container[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}