using Microsoft.VisualStudio.Coverage.Analysis;
using System;
using System.Collections.Generic;
using System.IO;

namespace CoverageConverter
{
    class Program
    {
        public static string key;
        static void Main(string[] args)
        {

            if (args.Length != 1)
            {
                Console.WriteLine("Coverage Convert - reads VStest binary code coverage data, and outputs it in XML format.");
                Console.WriteLine("Usage  ConverageConvert <Key of directory>");
                Environment.Exit(1);
            }

            key = args[0];
            List<string> directories = new List<string>(Directory.GetDirectories("."));
            directories.RemoveAll(exclude);

            foreach (var dir in directories)
            {

                string subDir = (new List<string>(Directory.GetDirectories(dir + @"\in"))) [0];
                List<string> files = new List<string>(Directory.GetFiles(subDir));

                foreach (var f in files)
                {
                    if (f.EndsWith(".coverage"))
                    {
                        Console.WriteLine("converting: " + f);
                        convert(f);
                    }
                }


            }

        }

        private static void convert(string filePath)
        {
            using (CoverageInfo info = CoverageInfo.CreateFromFile(

                filePath,
                new string[] { @"C:\repos\ConsoleApp2\UnitTestProject1\bin\Debug" },
                new string[] { }))
            {
                CoverageDS data = info.BuildDataSet();
                data.WriteXml("TestResults.coveragexml");
            }
        }

        private static bool exclude(string str)
        {
            string[] dir = str.Split('\\');
            return (!dir[dir.Length-1].StartsWith(key));
        }
    }
}