using System.IO;
using CommandLine;

namespace Endomondo.Export
{
    public class Options
    {
        [Value(0, MetaName = "email", Required = true, HelpText = "Endomondo username.")]
        public string Email { get; set; }

        [Value(1, MetaName = "password", Required = true, HelpText = "Endomondo password.")]
        public string Password { get; set; }

        [Option(Required = false, HelpText = "An absolute path to a directory to save workouts.")]
        public string Path { get; set; } = Directory.GetCurrentDirectory();

        [Option(Required = false, HelpText = "How many recent workouts to download. Default value 7.")]
        public int Limit { get; set; } = 7;
    }
}
