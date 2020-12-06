using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BinaryTree
{
	public class BinaryTree
	{
		public class BinaryNode
		{
			public readonly int Value;
			public BinaryNode Left { get; set; }
			public BinaryNode Right { get; set; }

			public BinaryNode(int value)
			{
				Value = value;
			}
		}

		public BinaryNode RootNode { get; private set; }

		private void Add(BinaryNode node, BinaryNode currentNode)
		{
			if (RootNode == null)
				RootNode = node;
			else
			{
				if (currentNode.Value >= node.Value)
				{
					if (currentNode.Left == null)
						currentNode.Left = node;
					else
						Add(node, currentNode.Left);
				}
				else
				{
					if (currentNode.Right == null)
						currentNode.Right = node;
					else
						Add(node, currentNode.Right);
				}
			}
		}

		public void Add(int value)
		{
			Add(new BinaryNode(value), RootNode);
		}

		// прямой обход (CLR - center, left, right)
		public void CLR(BinaryNode node)
		{
			if (node != null)
			{
				Console.WriteLine(node.Value.ToString());
				CLR(node.Left);
				CLR(node.Right);
			}
		}
		// Внутренний обход (LCR - left, center, right) 
		public void LCR(BinaryNode node)
		{
			if (node != null)
			{
				LCR(node.Left);
				Console.WriteLine(node.Value.ToString());
				LCR(node.Right);
			}
		}
		// Обратный обход (RCL - left, right, center)
		public void RCL(BinaryNode node)
		{
			if (node != null)
			{
				RCL(node.Left);
				RCL(node.Right);
				Console.WriteLine(node.Value.ToString());
			}
		}
	}
}