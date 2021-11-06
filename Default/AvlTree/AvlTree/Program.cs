// See https://aka.ms/new-console-template for more information
using AvlTree;
using MakTasks;

var arr = Enumerable.Range(1, 15).ToArray();

var tree = AvlTreeCreator.Create(arr);
var result = AvlTreeGuide.GetRoundedTree(tree);

foreach (var item in result)
	Console.WriteLine(item);