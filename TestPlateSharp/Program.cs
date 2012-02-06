using System;

namespace TestPlateSharp
{
	/// <summary>
	/// Console program to run all tests in this assembly.
	/// </summary>
	class Program
	{
		static int Main(string[] args)
		{
			return new Program().RunConsoleRunner(args);

			// Low-level NUnit example. Go ahead, experiment with it.
			// Colorize test results, send to your pager, etc...
			//
			// return new RecycleBin.LowNUnit().RunTests();
		}

		/// <summary>
		/// Just launch console runner on this assembly.
		/// </summary>
		/// <param name="args">Ignored, actually: merge args is not an easy task</param>
		/// <returns>Error code</returns>
		private int RunConsoleRunner(string[] args)
		{
			var args2 = new String[]
			{
				GetType().Assembly.Location
			};

			return NUnit.ConsoleRunner.Runner.Main(args2);
		}

	}
}
