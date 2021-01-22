using System;
using System.Collections.Generic;
using System.Text;

namespace DijkstraAlgo
{
	public class Edge
	{
		public Node Node { get; }
		public int Length { get; }

		public Edge(Node node, int length)
		{
			Node = node;
			Length = length;
		}
	}
}
