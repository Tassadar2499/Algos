using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("kek");
			var binTree = new BinaryTree();
			binTree.Add(10);
			binTree.Add(6);
			binTree.Add(5);
			binTree.Add(8);
			binTree.Add(7);
			binTree.Add(14);
			binTree.Add(12);
			binTree.Add(15);

			Console.WriteLine("Прямой");
			binTree.CLR(binTree.RootNode);
			Console.WriteLine("Внутренний");
			binTree.LCR(binTree.RootNode);
			Console.WriteLine("Обратный");
			binTree.RCL(binTree.RootNode);

			Console.ReadKey();
		}
	}
}
