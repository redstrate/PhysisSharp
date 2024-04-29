using PhysisSharp;

namespace Example;

internal static class Program
{
    private static void Main(string[] args)
    {
        // Collect our arguments
        var gameDir = args[0];
        var filePath = args[1];
        var destinationPath = args[2];

        GameData gameData;
        try
        {
            // Create a GameData class, this manages the repositories. It allows us to easily extract files.
            gameData = new GameData(gameDir);
        }
        catch (Exception)
        {
            Console.WriteLine($"Invalid game directory ({gameDir})!");
            return;
        }
        
        // Extract said file:
        var file = gameData.Extract(filePath);
        if (file == null)
        {
            Console.WriteLine($"File {filePath} not found!");
            return;
        }

        try
        {
            // Since GameData::extract returns a byte buffer, it's trivial to write that to a file on disk.
            File.WriteAllBytes(destinationPath, file.Data.ToArray());
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Failed to write to {file} because {exception.Message}");
            return;
        }

        Console.WriteLine($"Successfully extracted {filePath} to {destinationPath}!");
    }
}