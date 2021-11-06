using MakTasks;
using System.Diagnostics.CodeAnalysis;

namespace AvlTree
{
	public class AvTreeEqualityComparer : IEqualityComparer<AvTree>
	{
		public bool Equals(AvTree? first, AvTree? second)
		{
			var firstSequence = AvlTreeGuide.GetRoundedTree(first);
			var secondSequence = AvlTreeGuide.GetRoundedTree(second);

			return firstSequence.SequenceEqual(secondSequence);
		}

		public int GetHashCode([DisallowNull] AvTree obj)
		{
			return obj.GetHashCode();
		}
	}
}
