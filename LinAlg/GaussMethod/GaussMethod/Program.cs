using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaussMethod
{
	public static class Program
	{
		static void Main(string[] args)
		{
			var firstLine = Console.ReadLine();
			var strArr = firstLine.Split(' ');
			var countOfEquation = int.Parse(strArr[0]);
			var countOfVariables = int.Parse(strArr[1]);

			var matrix = ReadInput(countOfEquation).ToArray();

			var answer = RunGausMethod(matrix, countOfVariables);

			Console.WriteLine(answer);

			Console.ReadKey();
		}

		public static string RunGausMethod(double[][] matrix, int countOfVariables)
		{			
			var reducedMatrix = Clone(matrix);

			foreach (var array in reducedMatrix)
				array[^1] = 0;

			DirectTraversal(matrix);
			DirectTraversal(reducedMatrix);

			var rangDefault = matrix.Length - matrix.Count(IsZero);
			var rangReduced = reducedMatrix.Length - reducedMatrix.Count(IsZero);

			if (rangReduced != rangDefault)
				return "NO";

			if (rangDefault < countOfVariables)
				return "INF";

			var answers = GetAnswer(matrix);

			return $"YES{Environment.NewLine}{string.Join(", ", answers)}";
		}

		private static void DirectTraversal(double[][] matrix)
		{
			var length = matrix.Length;

			for (int i = 0; i < length; i++)
			{
				if (matrix[i][i] == 0)
					continue;

				Parallel.For(i + 1, length, j => DirectTraversalStep(matrix, i, j));
			}
		}

		private static void DirectTraversalStep(double[][] matrix, int i, int j)
		{
			var coefficient = matrix[j][i] / matrix[i][i];

			matrix[j] = matrix[j]
				.Zip(matrix[i], (f, s) => f - s * coefficient)
				.ToArray();
		}

		private static double[] GetAnswer(double[][] matrix)
		{
			var answers = new List<double>();
			for (int i = matrix.Length - 1; i > -1; i--)
			{
				var array = matrix[i];

				double sum = 0;
				var answersCount = answers.Count;
				for (int j = 0; j < answersCount; j++)
					sum += answers[j] * array[^(j + 2)];

				var newAnswer = (array[^1] - sum) / array[^(answersCount + 2)];
				answers.Add(newAnswer);
			}

			answers.Reverse();

			return answers.ToArray();
		}

		private static IEnumerable<double[]> ReadInput(int countOfEquation)
		{
			for (int i = 0; i < countOfEquation; i++)
			{
				var str = Console.ReadLine();

				yield return str.Split(' ').Select(s => double.Parse(s)).ToArray();
			}
		}

		private static double[][] Clone(double[][] matrix)
		{
			var newMatrix = new double[matrix.Length][];
			newMatrix = matrix.Select(a => a.Clone() as double[]).ToArray();

			return newMatrix;
		}

		private static bool IsZero(IEnumerable<double> array)
			=> array.All(n => n == 0);
	}
}
