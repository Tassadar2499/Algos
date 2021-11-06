// See https://aka.ms/new-console-template for more information
using MakTasks;

var arr = Enumerable.Range(1, 15).ToArray();

var tree = new AvlTree(1);

foreach (var item in arr)
	tree.Insert(item);

var gg = 0;