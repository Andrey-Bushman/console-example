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
            // Get the application arguments. Two arguments are expected:
            // First argument is the input file name (without the directory path).
            // Second argument is the output file name (without the directory path).
            if(args.Length != 2) {
                throw new ArgumentException("Application expected two arguments.");
            }
            var argIndex = 0;
            foreach (var item in args)
            {
                WriteLine($"Arg #{argIndex++}: {item}");
            }

            // Get the "MESSAGE" environment value
            var envName = "MESSAGE";
            var envValue = Environment.GetEnvironmentVariable(envName, 
                EnvironmentVariableTarget.Process);
            WriteLine($"Environment variable value: {envValue}");

            // The input directory. It contains an input file.
            // Expected that this directory will be mapped throught volume.
            var inputDir = Directory.CreateDirectory("./input");
            var inputFile = Path.Combine(inputDir.FullName, args[0]);

            // The output directory. The result file will be created here.
            // Expected that this directory will be mapped throught volume.
            var outputDir = Directory.CreateDirectory("./output");
            var outputFile = Path.Combine(outputDir.FullName, args[1]);

            Write("Your name: "); // Bob, Jack, etc.
            var name = ReadLine();

            if(File.Exists(inputFile)) {
                var content = File.ReadAllText(inputFile, Encoding.UTF8)
                    .Replace("<name>", name);
                File.WriteAllText(outputFile, content, Encoding.UTF8);
            }
            else {
                WriteLine($"The input file '{inputFile}' not found.");
            }
        }
    }
}
