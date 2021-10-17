using System.Collections.Generic;
using System.Linq;
using BiDirectionalSearch.Graph;

namespace BiDirectionalSearch
{
    public static class Utils
    {
        public static void EnqueueRange<T>(this Queue<T> queue, IEnumerable<T> items)
        {
            foreach (var item in items)
                queue.Enqueue(item);
        }

        public static Node FindOrCreate(this IEnumerable<Node> collection, string name)
            => collection.FirstOrDefault(n => n.Name == name)
               ?? new Node(name);
    }
}