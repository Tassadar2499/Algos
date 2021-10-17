using System.Collections.Generic;

namespace BiDirectionalSearch.Graph
{
    public class Node
    {
        public string Name { get; }
        public readonly HashSet<Node> RelatedNodes;

        public Node(string name)
        {
            Name = name;
            RelatedNodes = new HashSet<Node>();
        }
        
        private bool Equals(Node other)
        {
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            
            return obj.GetType() == GetType() && Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            return Name != null ? Name.GetHashCode() : 0;
        }

        public override string ToString() => Name;
    }
}