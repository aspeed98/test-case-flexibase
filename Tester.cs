using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_case_flexibase
{
	public static class Tester
	{
		public static void Test1()
		{
			Console.WriteLine($"\n{new string('*', 18)}\n     Test  #1\n{new string('*', 18)}");

			List<object> list = new List<object>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
			ListLogger.Log(list);

			List<object> remade = new RemakeList(list, ComparisionFunctions.DividedNoRemainder,
				new List<Tuple<Dictionary<object, object>, object?>>()
				{
					new (new Dictionary<object, object>()
					{
						{ 3, "fizz" },
						{ 5, "buzz" }
					}, null)
				}
				).Result();
			ListLogger.Log(remade);
		}
		public static void Test2()
		{
			Console.WriteLine($"\n{new string('*', 18)}\n     Test  #2\n{new string('*', 18)}");

			List<object> list = new List<object>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
			ListLogger.Log(list);

			List<object> remade = new RemakeList(list, ComparisionFunctions.DividedNoRemainder,
				new List<Tuple<Dictionary<object, object>, object?>>()
				{
					new (new Dictionary<object, object>()
					{
						{ 3, "fizz" },
						{ 5, "buzz" },
						{ 4, "muzz" },
						{ 7, "guzz" }
					}, null)
				}
				).Result();
			ListLogger.Log(remade);
		}
		public static void Test3()
		{
			Console.WriteLine($"\n{new string('*', 18)}\n     Test  #3\n{new string('*', 18)}");

			List<object> list = new List<object>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
			ListLogger.Log(list);

			List<object> remade = new RemakeList(list, ComparisionFunctions.DividedNoRemainder,
				new List<Tuple<Dictionary<object, object>, object?>>()
				{
					new (new Dictionary<object, object>()
					{
						{ 3, "dog" },
						{ 5, "cat" },
					}, "good-boy"),
					new (new Dictionary<object, object>()
					{
						{ 4, "muzz" },
						{ 7, "guzz" }
					}, null)
				}
				).Result();
			ListLogger.Log(remade);
		}
	}
	public static class ListLogger
	{
		public static void Log(List<object> list)
		{
			Console.WriteLine($"\nList has {list.Count} items:");
			for (int i = 0; i < list.Count; i++)
				Console.WriteLine($"#{i,3} {list[i],10}");
		}
	}
	public static class InfoLogger
	{
		public static void Log(string message)
		{
			ConsoleColor defaultColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(message);
			Console.ForegroundColor = defaultColor;
		}
	}
}
