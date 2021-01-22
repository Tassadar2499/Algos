using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DijkstraAlgo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var lines = Resource.Graph.Split(Environment.NewLine);
			var nodes = GraphBuilder.GetNodes(lines).ToArray();
			foreach (var line in lines)
				GraphBuilder.ConnectNodesByLine(line, nodes);

			var startNode = nodes.First(n => n.Name == "A");
			startNode.Value = 0;

			Algo.Run(nodes, startNode);

			var finishNode = nodes.First(n => n.Name == "F");
			var path = GetReversePath(startNode, finishNode).Reverse();

			Console.WriteLine(string.Join("=>", path));
			Console.ReadKey();
		}

		private static IEnumerable<string> GetReversePath(Node start, Node finish)
		{
			for (var current = finish; !current.Equals(start); current = current.PreviousNode)
				yield return current.Name;

			yield return start.Name;
		}
	}
}