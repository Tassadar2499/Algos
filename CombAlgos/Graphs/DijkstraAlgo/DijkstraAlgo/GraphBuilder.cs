using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DijkstraAlgo
{
	public static class GraphBuilder
	{
		public static void ConnectNodesByLine(string line, Node[] nodes)
		{
			var strArr = line.Split("=>");
			var firstNode = nodes.First(n => n.Name == strArr[0]);
			var secondNode = nodes.First(n => n.Name == strArr[1]);
			var length = int.Parse(strArr[2]);

			firstNode.Edges.Add(new Edge(secondNode, length));
		}

		public static IEnumerable<Node> GetNodes(IEnumerable<string> lines)
			=> GetNodeNames(lines).Distinct().Select(n => new Node(n));

		private static IEnumerable<string> GetNodeNames(IEnumerable<string> lines)
		{
			foreach (var line in lines)
			{
				var strArr = line.Split("=>");
				yield return strArr[0];
				yield return strArr[1];
			}
		}
	}
}
