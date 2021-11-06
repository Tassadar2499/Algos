namespace MakTasks
{
	public static class NodeExtensionActions
	{
		public static Node Insert(this Node? node, int key)
		{
			if (node == null)
				return new (key);

			if (node.Key > key)
				node.Left = Insert(node.Left, key);
			else if (node.Key < key)
				node.Right = Insert(node.Right, key);

			return Balance(node);
		}

		public static Node? Remove(this Node? node, int key)
		{
			if (node == null)
				return null;

			if (key < node.Key)
			{
				node.Left = Remove(node.Left, key);
				return Balance(node);
			}

			if (key > node.Key)
			{ 
				node.Right = Remove(node.Right, key);
				return Balance(node);
			}

			var left = node.Left;
			var right = node.Right;

			if (right == null)
				return left;

			var min = right.FindMin();
			min.Right = RemoveMin(right);
			min.Left = left;

			return Balance(min);
		}

		private static Node Balance(Node node)
		{
			FixHeight(node);

			var balanceFactor = node.GetBalanceFactor();

			if (balanceFactor == 2)
			{
				var rightBalanceFactor = node.Right.GetBalanceFactor();
				if (rightBalanceFactor < 0)
					node.Right = RotateRight(node.Right!);

				return RotateLeft(node);
			}

			if (balanceFactor == -2)
			{
				var leftBalanceFactor = node.Left.GetBalanceFactor();
				if (leftBalanceFactor > 0)
					node.Left = RotateLeft(node.Left!);

				return RotateRight(node.Right!);
			}

			return node;
		}


		private static Node RotateRight(Node node)
		{
			var toChange = node.Left;
			node.Left = toChange!.Right;
			toChange.Right = node;

			node.Parent = toChange;

			FixHeight(node);
			FixHeight(toChange);

			return toChange;
		}

		private static Node RotateLeft(Node node)
		{
			var toChange = node.Right;
			node.Right = toChange!.Left;
			toChange.Left = node;

			node.Parent = toChange;

			FixHeight(node);
			FixHeight(toChange);

			return toChange;
		}

		private static Node RemoveMin(Node node)
		{
			if (node.Left == null)
				return node.Right!;

			node.Left = RemoveMin(node.Left);

			return Balance(node);
		}

		private static void FixHeight(Node? node)
		{
			if (node == null)
				return;

			node.Height = node.GetFixedHeight();
		}
	}
}
