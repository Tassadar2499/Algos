using AvlTree;
using FluentAssertions;
using MakTasks;
using System.Linq;
using Xunit;

namespace AvlTreeTest
{
	public class DefaultTests
	{
		[Fact]
		public void Is_avl_tree_creation_correct()
		{
			//arrange
			var expected = CreateTestTree();
			var arr = Enumerable.Range(1, 15).ToArray();

			//act
			var actual = AvlTreeCreator.Create(arr);

			//assert
			var comparer = new AvTreeEqualityComparer();
			var isEquals = comparer.Equals(actual, expected);
			isEquals.Should().BeTrue();
		}

		private static AvTree CreateTestTree()
		{
			var node = new Node(8)
			{
				Left = new (4)
				{
					Left = new (2)
					{
						Left = new (1),
						Right = new (3)
					},
					Right = new (6)
					{
						Left = new (5),
						Right = new (7)
					}
				},
				Right = new (12)
				{
					Left = new (10)
					{
						Left = new (9),
						Right = new (11)
					},
					Right = new (14)
					{
						Left = new (13),
						Right = new (15)
					}
				}
			};

			return new AvTree(node);
		}
	}
}