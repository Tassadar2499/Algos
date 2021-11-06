namespace MakTasks
{
	public static class NodeExtensionFuncs
	{
		public static int GetBalanceFactor(this Node? node) => GetHeight(node?.Right) - GetHeight(node?.Left);

		public static int GetFixedHeight(this Node node)
		{
			var leftHeight = GetHeight(node.Left);
			var rightHeight = GetHeight(node.Right);

			return Math.Max(leftHeight, rightHeight) + 1;
		}

		public static Node FindMin(this Node node)
		{
			return node.Left == null
				? node
				: FindMin(node.Left);
		}

		private static int GetHeight(this Node? node) => node?.Height ?? 0;
	}
}
