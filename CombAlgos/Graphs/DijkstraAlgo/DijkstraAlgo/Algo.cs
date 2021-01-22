using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DijkstraAlgo
{
	public static class Algo
	{
		public static void Run(Node[] nodes, Node currentNode)
		{
			while (!nodes.All(n => n.IsChecked))
			{
				var relatedEdges = currentNode.Edges;
				foreach (var edge in relatedEdges)
				{
					var mark = currentNode.Value + edge.Length;
					var nextNode = edge.Node;

					if (mark < nextNode.Value)
					{
						nextNode.Value = mark;
						nextNode.PreviousNode = currentNode;
					}
				}

				currentNode.IsChecked = true;
				currentNode = relatedEdges.Select(e => e.Node).FirstOrDefault(n => !n.IsChecked)
					?? nodes.FirstOrDefault(n => !n.IsChecked);
			}
		}
	}
}
