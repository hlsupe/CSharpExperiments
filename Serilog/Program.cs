using System;
using System.Collections.Generic;

namespace Serilog
{
	internal class Program
	{
		private static void Main()
		{
			var log = new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.WriteTo.Console()
				.WriteTo.File("log.txt",
					rollingInterval: RollingInterval.Day,
					rollOnFileSizeLimit: true,
					fileSizeLimitBytes: 512)
				.CreateLogger();

			log.Information("Hello, Serilog!");

			var position = new { Latitude = 25, Longitude = 134 };
			var elapsedMs = 34;
			var products = new List<string> { "Paper", "Pencil", "Pen" };
			log.Information("Processed {Position} in {Elapsed} ms.", position, elapsedMs);
			log.Information("Ordered {@products}", products);
			log.Information("Added {UserName}", "Sarah");
			log.Information("Added {UserName:l}", "Sarah");
			log.Information("PI is {PI}", Math.PI);
			log.Information("PI is {PI:0.00}", Math.PI);
			log.Verbose("This is verbose.");
			log.Debug("This is debug.");
			log.Warning("This is warning");
			log.Error("This is error");
			log.Fatal("This is Fatal");

			Log.CloseAndFlush();
			Console.ReadKey();
		}
	}
}