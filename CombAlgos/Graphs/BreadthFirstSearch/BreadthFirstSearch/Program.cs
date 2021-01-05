using System;
using System.Collections.Generic;
using System.Linq;

namespace BreadthFirstSearch
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var nodes = BuildGraph();

			var startNode = nodes.First(n => n.Name == "A");
			var path = BreadthSearch(startNode);

			Console.WriteLine(path);
			Console.ReadKey();
		}

		private static string BreadthSearch(Node startNode)
		{
			var visited = new HashSet<Node>();

			var nodesQueue = new Queue<Node>();
			nodesQueue.Enqueue(startNode);

			while (nodesQueue.Count != 0)
			{
				var currentNode = nodesQueue.Dequeue();
				visited.Add(currentNode);

				if (currentNode.Name == "F")
					break;

				var nextNodes = currentNode.RelatedNodes.Where(n => !visited.Contains(n));
				nodesQueue.EnqueueRange(nextNodes);
			}

			return string.Join("=>", visited.Select(v => v.Name));
		}

		private static HashSet<Node> BuildGraph()
		{
			var letters = Resource.Graph
				.Split(Environment.NewLine)
				.Select(l => l.Split('-'))
				.Select(l => (First: l[0], Second: l[1]));

			var nodes = new HashSet<Node>();

			foreach (var (first, second) in letters)
			{
				var firstNode = nodes.FindOrCreate(first);
				var secondNode = nodes.FindOrCreate(second);

				firstNode.RelatedNodes.Add(secondNode);
				secondNode.RelatedNodes.Add(firstNode);

				nodes.Add(firstNode);
				nodes.Add(secondNode);
			}

			return nodes;
		}
	}
}