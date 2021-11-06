using MakTasks;

namespace AvlTree
{
	public static class AvlTreeCreator
	{
		public static AvTree Create(int[] arr)
		{
			var tree = new AvTree(arr[0]);

			foreach (var item in arr.Skip(1))
				tree.Insert(item);

			return tree;
		}
	}
}
