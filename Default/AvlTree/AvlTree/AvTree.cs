namespace MakTasks
{
	public class AvTree
	{
		public Node Root { get; private set; }

		public AvTree(Node root)
		{
			Root = root;
		}

		public AvTree(int key) : this(new Node(key))
		{
		}

		public void Insert(int key)
		{
			var newNode = Root.Insert(key);
			Root = newNode;
		}
	}
}
