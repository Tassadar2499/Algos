namespace BreadthFirstSearch
{
	public class Edge
	{
		public Node First { get; }
		public Node Second { get; }

		public Edge(Node first, Node second)
		{
			First = first;
			Second = second;

			First.RelatedNodes.Add(Second);
			Second.RelatedNodes.Add(First);
		}
	}
}