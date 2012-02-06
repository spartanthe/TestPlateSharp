using System;
using NUnit.Framework;

namespace TestPlateSharp
{
	/// <summary>
	/// Start testing, here are some bare examples to start with.
	/// </summary>
	[TestFixture]
	class MyTests1
	{
		[TestCase]
		public void OneIsEqualToOne_Passes()
		{
			Assert.AreEqual(1, 1, "1 == 1 should pass.");
		}

		[TestCase]
		public void OneIsEqualToTwo_Fails()
		{
			Assert.AreEqual(1, 2, "?! 1 == 2");
		}
	
		[TestCase]
		public void IThrowException()
		{
			throw new Exception("?! throw new Exception");
		}

		[TestCase]
		public void IAmInconclusive()
		{
			Assert.Inconclusive("?! Assert.Inconclusive");
		}
	}
}
