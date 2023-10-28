using System;
using System.IO;
using System.Reflection;

namespace LeapReleaser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Get leap paths
            Console.Write("Leap path: ");
            var path = Console.ReadLine();
            var debugPath = $"{path}\\out\\build\\x64-Debug";
            var releasePath = $"{path}\\out\\build\\x64-Release";

            // Check if directory is valid
            if (!Directory.Exists(debugPath))
            {
                Console.WriteLine($"Program exited no valid path for debug. ({debugPath})");
                return;
            }
            if (!Directory.Exists(releasePath))
            {
                Console.WriteLine($"Program exited no valid path for release. ({releasePath})");
                return;
            }

            // Get .exe folder & check if Example exists
            var baseFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!Directory.Exists($"{baseFolder}\\Example"))
            {
                Console.WriteLine("No example folder found next to the .exe");
                return;
            }
            
            // Delete LeapRelease if it already exists
            if (Directory.Exists($"{baseFolder}\\LeapRelease")) Directory.Delete($"{baseFolder}\\LeapRelease", true);


            Console.WriteLine("Starting copy process");
            Directory.CreateDirectory($"{baseFolder}\\LeapRelease");

            // Copy Example folder to LeapRelease
            CopyDirectory($"{baseFolder}\\Example", $"{baseFolder}\\LeapRelease\\Example");

            // Set base folder to LeapRelease
            baseFolder = $"{baseFolder}\\LeapRelease";

            // Write root CMake
            File.WriteAllText($"{baseFolder}/CMakeLists.txt",CMakeHelper.Base);

            // Copy engine data
            Directory.CreateDirectory($"{baseFolder}\\Data");
            CopyDirectory($"{path}\\Data\\Engine", $"{baseFolder}\\Data\\Engine");

            // Create 3rdParty folder & write CMake for it
            Directory.CreateDirectory($"{baseFolder}\\3rdParty");
            File.WriteAllText($"{baseFolder}\\3rdParty\\CMakeLists.txt", CMakeHelper.ThirdParty);

            // Create engine 3rd party & copy it
            Directory.CreateDirectory($"{baseFolder}\\3rdParty\\3rdParty");
            CopyDirectory($"{path}\\3rdParty", $"{baseFolder}\\3rdParty\\3rdParty");

            // Create engine & generate CMake for it
            Directory.CreateDirectory($"{baseFolder}\\3rdParty\\Engine");
            GenerateFullEngine($"{baseFolder}\\3rdParty\\Engine", path);
        }

        private static void GenerateFullEngine(string path, string pathOut)
        {
            File.WriteAllText($"{path}\\CMakeLists.txt", CMakeHelper.Engine);
            GenerateEngine(path, pathOut, "LeapEngine", "LeapEngine", "LEAP_LIB", "LEAP_INCLUDE");
            GenerateEngine(path, pathOut, "Audio", "AudioEngine", "LEAP_AUDIO_LIB", "LEAP_AUDIO_INCLUDE");
            GenerateEngine(path, pathOut, "Graphics", "GraphicsEngine", "LEAP_GRAPHICS_LIB", "LEAP_GRAPHICS_INCLUDE");
            GenerateEngine(path, pathOut, "Inputs", "InputEngine", "LEAP_INPUT_LIB", "LEAP_INPUT_INCLUDE");
            GenerateEngine(path, pathOut, "Networking", "NetworkingEngine", "LEAP_NETWORK_LIB", "LEAP_NETWORK_INCLUDE");
            GenerateEngine(path, pathOut, "Physics", "PhysicsEngine", "LEAP_PHYSICS_LIB", "LEAP_PHYSICS_INCLUDE");
            GenerateEngine(path, pathOut, "Utils", "EngineUtils", "LEAP_UTILS_LIB", "LEAP_UTILS_INCLUDE");
        }

        private static void GenerateEngine(string path, string pathOut, string engineName, string libName, string libVar, string inclVar)
        {
            // Set path to lib name & create folder & generate CMake
            path = $"{path}\\{libName}";
            Directory.CreateDirectory($"{path}");
            File.WriteAllText($"{path}\\CMakeLists.txt", CMakeHelper.GenerateEngine(inclVar, libVar, libName));

            // Copy the include directory from leap (header only)
            Directory.CreateDirectory($"{path}\\include");
            CopyDirectory($"{pathOut}\\{engineName}", $"{path}\\include", true);

            // Copy the .lib files
            Directory.CreateDirectory($"{path}\\lib");
            Directory.CreateDirectory($"{path}\\lib\\debug");
            File.Copy($"{pathOut}\\out\\build\\x64-Debug\\{engineName}\\{libName}.lib", $"{path}\\lib\\debug\\{libName}.lib");
            Directory.CreateDirectory($"{path}\\lib\\release");
            File.Copy($"{pathOut}\\out\\build\\x64-Release\\{engineName}\\{libName}.lib", $"{path}\\lib\\release\\{libName}.lib");
        }

        static void CopyDirectory(string sourceDir, string destinationDir, bool headerOnly = false)
        {
            // Create destination folder if not exists
            if (!Directory.Exists(destinationDir)) Directory.CreateDirectory(destinationDir);

            // Get all files from current directory
            string[] files = Directory.GetFiles(sourceDir);

            // Loop over all files and copy them to the dir
            foreach (string file in files)
            {
                if (headerOnly && file[file.Length-1] != 'h') continue;
                Console.WriteLine(file);
                
                string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
                File.Copy(file, destFile);
            }

            // Get all subdirectories
            string[] subdirectories = Directory.GetDirectories(sourceDir);

            // Recursive function call to do the sub directories
            foreach (string subdir in subdirectories)
            {
                string destSubDir = Path.Combine(destinationDir, Path.GetFileName(subdir));
                CopyDirectory(subdir, destSubDir, headerOnly);
            }
        }
    }
}