using System;
using static System.Console;
using System.IO;
using System.Text;

namespace ConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the application arguments passed through docker. 
            // Two arguments are expected:
            // First argument is the input file name (without the directory path).
            // It is to exists on host machine.
            // Second argument is the output file name (without the directory path).
            // It will be created by this application and saved on host machine.
            if(args.Length != 2) {
                throw new ArgumentException("Application expected two arguments.");
            }
            var argIndex = 0;
            foreach (var item in args)
            {
                WriteLine($"Arg #{argIndex++}: {item}");
            }

            // Get the "MESSAGE" environment value passed through docker
            var envName = "MESSAGE";
            var envValue = Environment.GetEnvironmentVariable(envName, 
                EnvironmentVariableTarget.Process);
            WriteLine($"Environment variable value: {envValue}");

            // The input data directory. It is to contain an expected input file.
            // Expected that this directory will be mapped throught docker-volume.
            var inputDir = Directory.CreateDirectory("./input");
            var inputFile = Path.Combine(inputDir.FullName, args[0]);

            // The output data directory. The result file will be saved here.
            // Expected that this directory will be mapped through docker-volume,
            // otherwise you can't get result file.
            var outDirName = "./output";
            var outputDir = Directory.CreateDirectory(outDirName);
            var outputFile = Path.Combine(outputDir.FullName, args[1]);

            Write("Your name: "); // Bob, Jack, etc.
            var name = ReadLine();

            if(File.Exists(inputFile)) {
                var content = File.ReadAllText(inputFile, Encoding.UTF8)
                    .Replace("<name>", name);
                File.WriteAllText(outputFile, content, Encoding.UTF8);
                WriteLine($"Result file: {outDirName}/{args[1]}");
            }
            else {
                WriteLine($"The input file '{inputFile}' not found.");
            }
        }
    }
}
