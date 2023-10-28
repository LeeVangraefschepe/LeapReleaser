using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapReleaser
{
    public class CMakeHelper
    {
        public static string Base { get; private set; } = "# Root cmake\r\ncmake_minimum_required(VERSION 3.22)\r\n\r\nProject(Example VERSION 1.0.0)\r\nset(CMAKE_CXX_STANDARD 20)\r\nset(CMAKE_CXX_STANDARD_REQUIRED ON)\r\n\r\nif (MSVC)\r\n    add_compile_options(/W4 /WX)\r\nelse()\r\n    add_compile_options(-Wall -Wextra -Werror)\r\nendif()\r\n\r\n# Copy files\r\nset(DATA_FILES \"${CMAKE_CURRENT_SOURCE_DIR}/Data\")\r\nset(DESTINATION_COPY \"${CMAKE_BINARY_DIR}/Example/Data\")\r\n\r\n# Engine\r\nadd_subdirectory(3rdParty)\r\n\r\n# Game Project\r\nadd_subdirectory(Example)";
        public static string ThirdParty { get; private set; } = "# 3rdParty CMake\r\nadd_subdirectory(3rdParty)\r\nadd_subdirectory(Engine)";
        public static string Engine { get; private set; } = "# Engine CMake\r\nadd_subdirectory(AudioEngine)\r\nadd_subdirectory(EngineUtils)\r\nadd_subdirectory(GraphicsEngine)\r\nadd_subdirectory(InputEngine)\r\nadd_subdirectory(LeapEngine)\r\nadd_subdirectory(NetworkingEngine)\r\nadd_subdirectory(PhysicsEngine)";

        public static string GenerateEngine(string includeVar, string libVar, string libName)
        {
            return $"# Subengine CMake\r\nset({includeVar} \"${{CMAKE_CURRENT_SOURCE_DIR}}/include\" CACHE PATH \"\")\r\n\r\nif(CMAKE_BUILD_TYPE STREQUAL \"Debug\")\r\n\tset({libVar} \"${{CMAKE_CURRENT_SOURCE_DIR}}/lib/debug/{libName}.lib\" CACHE PATH \"\")\r\nelse()\r\n\tset({libVar} \"${{CMAKE_CURRENT_SOURCE_DIR}}lib/release/{libName}.lib\" CACHE PATH \"\")\r\nendif()";
        }
    }
}
