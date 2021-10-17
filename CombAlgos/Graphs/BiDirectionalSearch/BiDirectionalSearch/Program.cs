using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiDirectionalSearch.Graph;

namespace BiDirectionalSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = BuildGraph();
            
            var startNode = nodes.First(n => n.Name == "A");
            var endNode = nodes.First(n => n.Name == "F");
            
            var result = Search(startNode, endNode);
            
            Console.WriteLine(result);
        }
        
        private static string Search(Node startNode, Node endNode)
        {
            var visitedStart = new HashSet<Node>();
            var visitedEnd = new HashSet<Node>();

            var nodesQueueStart = new Queue<Node>();
            nodesQueueStart.Enqueue(startNode);

            var nodesQueueEnd = new Queue<Node>();
            nodesQueueEnd.Enqueue(endNode);

            while (nodesQueueStart.Count != 0)
            {
                var currentNodeStart = nodesQueueStart.Dequeue();
                visitedStart.Add(currentNodeStart);

                var currentNodeEnd = nodesQueueEnd.Dequeue();
                visitedEnd.Add(currentNodeEnd);

                if (visitedStart.Intersect(visitedEnd).Any())
                    break;

                var nextNodesStart = currentNodeStart.RelatedNodes.Where(n => !visitedStart.Contains(n));
                nodesQueueStart.EnqueueRange(nextNodesStart);

                var nextNodesEnd = currentNodeEnd.RelatedNodes.Where(n => !visitedEnd.Contains(n));
                nodesQueueEnd.EnqueueRange(nextNodesEnd);
            }

            var result = visitedStart
                .Union(visitedEnd.Reverse())
                .Distinct()
                .Select(v => v.ToString());

            return string.Join("=>", result);
        }
        
        private static HashSet<Node> BuildGraph()
        {
            var letters = Resource.Graph
                .Split(Environment.NewLine)
                .Select(l => l.Split('-'))
                .Select(l => (First: l[0], Second: l[1]));

            var nodes = new HashSet<Node>();

            foreach (var (first, second) in letters)
            {
                var firstNode = nodes.FindOrCreate(first);
                var secondNode = nodes.FindOrCreate(second);

                firstNode.RelatedNodes.Add(secondNode);
                secondNode.RelatedNodes.Add(firstNode);

                nodes.Add(firstNode);
                nodes.Add(secondNode);
            }

            return nodes;
        }
    }
}