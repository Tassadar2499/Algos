using MakTasks;

namespace AvlTree
{
	public static class AvlTreeGuide
	{
		public static List<int> GetRoundedTree(AvTree? tree)
		{
			var view = new List<int>();
			RoundTree(tree?.Root, view);

			return view;
		}

		private static void RoundTree(Node? node, List<int> view)
		{
			if (node == null)
				return;

			view.Add(node.Key);
			RoundTree(node.Left, view);
			RoundTree(node.Right, view);
		}
	}
}
