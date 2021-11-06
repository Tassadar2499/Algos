namespace MakTasks
{
	public class AvlTree
	{
		public Node Root { get; private set; }

		public AvlTree(int key)
		{
			Root = new Node(key);
		}

		public void Insert(int key)
		{
			var newNode = Root.Insert(key);
			Root = newNode;
		}
	}
}
