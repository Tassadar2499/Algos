using System;
using System.Collections.Generic;
using System.Text;

namespace DijkstraAlgo
{
	public class Node
	{
		public string Name { get; }
		public bool IsChecked { get; set; }
		public int Value { get; set; }
		public Node PreviousNode { get; set; }
		public HashSet<Edge> Edges { get; set; } 

		public Node(string name)
		{
			Name = name;
			IsChecked = false;
			Value = int.MaxValue;
			Edges = new HashSet<Edge>();
		}

		public override bool Equals(object obj)
		{
			return obj is Node node && Name == node.Name;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Name, IsChecked, Value);
		}
	}
}
