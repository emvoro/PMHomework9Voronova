using System;
using System.Text.Json;
using System.IO;

namespace PrimesTestApp.Deserialization
{
    public class Deserialization
    {
        public string Path { get; set; }

        public Uri BaseAddress { get; set; }

        public Deserialization(string path)
        {
            Path = path;
            var json = File.ReadAllText(Path);
            var settings = JsonSerializer.Deserialize<BaseAddress>(json);
            BaseAddress = new Uri(settings.Address);
        }
    }
}
