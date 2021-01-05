using System.Collections.Generic;

namespace BreadthFirstSearch
{
	public class Node
	{
		public readonly string Name;
		public readonly HashSet<Node> RelatedNodes;

		public Node(string name)
		{
			Name = name;
			RelatedNodes = new HashSet<Node>();
		}
	}
}