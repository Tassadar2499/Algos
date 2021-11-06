namespace MakTasks
{
	public class Node
	{
		public Node(int key)
		{
			Key = key;
			Height = 1;
		}

		public int Key { get; set; }
		public int Height { get; set; }
		public Node? Parent { get; set; }
		public Node? Left { get; set; }
		public Node? Right { get; set; }
	}
}
