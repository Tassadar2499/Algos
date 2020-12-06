using GaussMethod;
using System;
using Xunit;

namespace GaussMethod_Tests
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			var matrix = new double[][]
			{
				new double[] { 4, 2, 1, 1 },
				new double[] { 7, 8, 9, 1 },
				new double[] { 9, 1, 3, 2 }
			};

			var gg = Program.RunGausMethod(matrix, 3);
		}
	}
}
