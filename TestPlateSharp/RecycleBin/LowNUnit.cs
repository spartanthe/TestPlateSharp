using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Core;

namespace TestPlateSharp.RecycleBin
{
	/// <summary>
	/// Deep dive to NUnit... when you have free time.
	/// </summary>
	class LowNUnit : EventListener, ITestFilter
	{
		public void RunTests()
		{
			// Create test runner
			var testRunner = new SimpleTestRunner();

			// Load this assembly to test runner
			var assemblies = new List<string>();
			assemblies.Add(GetType().Assembly.Location);

			var testPackage = new TestPackage(GetType().FullName, assemblies);

			bool loaded = testRunner.Load(testPackage);
			if (!loaded)
				throw new InvalidOperationException("Can't load this assembly into test package");

			// Run all tests in this assembly
			testRunner.BeginRun(this, this);
			testRunner.Wait();

			// Summarize
			TestResult testResult = testRunner.EndRun();
			Console.WriteLine("testResult={0}", testResult);
		}


		#region EventListener Members

		// -- Runs

		public void RunStarted(string name, int testCount)
		{
			Console.WriteLine("RunStarted, name='{0}' #{1}", name, testCount);
		}

		public void RunFinished(Exception exception)
		{
			Console.WriteLine(":( => {0}", exception);
			Console.WriteLine(exception.StackTrace);
		}

		public void RunFinished(TestResult result)
		{
			Console.WriteLine(":( => {0}", result);
		}

		// -- -- Suites

		public void SuiteStarted(TestName testName)
		{
			Console.WriteLine("RUN SUITE {0}", testName);
		}

		public void SuiteFinished(TestResult result)
		{
			Console.WriteLine("END SUITE {0}", result);
		}

		// -- -- -- Tests

		public void TestStarted(TestName testName)
		{
			Console.WriteLine("TEST START {0}", testName);
		}

		public void TestFinished(TestResult result)
		{
			Console.WriteLine("END TEST : {0}", result);
		}

		public void TestOutput(TestOutput testOutput)
		{
			Console.WriteLine("TestOutput : {0}", testOutput);
		}

		// -- Exceptions

		public void UnhandledException(Exception exception)
		{
			Console.WriteLine(":( => {0}", exception);
			Console.WriteLine(exception.StackTrace);
		}

		#endregion

		#region ITestFilter Members

		bool ITestFilter.IsEmpty
		{
			get { return false; }
		}

		bool ITestFilter.Match(ITest test)
		{
			return true;
		}

		bool ITestFilter.Pass(ITest test)
		{
			return true;
		}

		#endregion
	}
}
