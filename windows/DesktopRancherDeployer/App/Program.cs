// C# program to illustrate how
// to read a file in C#
using System;
using System.IO;

class Program {
	static async Task Main(string[] args)
	{
		// Store the path of the textfile in your system
		string file = @"/workspaces/RancherDesktop/DesktopRancherDeployer/Main.xaml";

		Console.WriteLine("Reading xaml File.... using File.ReadAllText()");

		// To read the entire file at once
		if (File.Exists(file)) {
			// Read all the content in one string
			// and display the string
			string str = File.ReadAllText(file);
			Console.WriteLine(str);
            //File.WriteAllText(@"/DesktopRancherDeployer/App/XAML/main.xml", file);
		}
		Console.WriteLine();

        // Keeps Container Up and Running til stopped manually
        var counter = 0;
        var max = args.Length is not 0 ? Convert.ToInt32(args[0]) : -1;
        while (max is -1 || counter < max)
        {
            Console.WriteLine($"Counter: {++counter}");
            await Task.Delay(TimeSpan.FromMilliseconds(1_000));
        }

        // Save then Run
        // Ctrl + C to stop the program: dotnet run
        // if Run is successful then publish: dotnet publish -c Release
        // build the image: docker build -t rancherdesktop -f Dockerfile .
        // Verify successful build: docker images
        // Stop and Remove previous build
        // Create the container: docker create --name rancherdesktop-core rancherdesktop
	}
}