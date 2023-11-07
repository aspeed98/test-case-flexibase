using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_case_flexibase
{
	public class RemakeList
	{
		// fields
		private List<object> _list;
		private Func<object, object, bool> _compareFunction;
		private List<Tuple<Dictionary<object, object>, object?>> _replacements;

		// properties
		public List<object> list
		{ get { return this._list; } set { this._list = value; } }
		public Func<object, object, bool> compareFunction
		{ get { return this._compareFunction; } set { this._compareFunction = value; } }
		public List<Tuple<Dictionary<object, object>, object?>> replacements
		{ get { return this._replacements; } set { this._replacements = value; } }

		// constructors
		public RemakeList(List<object> list, Func<object, object, bool> compareFunction, List<Tuple<Dictionary<object, object>, object?>> replacements)
		{
			this.list = list;
			this.compareFunction = compareFunction;
			this.replacements = replacements;
		}

		// methods
		/// <summary>
		/// Dictionaries lay inside Tuples with the second Item2 = object(nullable)
		/// This second item is used in case all dictionary values suits the compareFunction
		/// Thus by making a list of tuples containing dictionaries and all-suitable value,
		/// we can achieve any desired result
		/// </summary>
		public List<object> Result()
		{
			for (int i = 0; i < list.Count; i++)
			{
				List<object> remade = new List<object>();

				foreach (var tup in replacements)
				{
					int changes = 0;
					List<object> redo = new List<object>();
					foreach (var key in tup.Item1.Keys)
					{
						if (compareFunction(list[i], key))
						{
							changes++;
							redo.Add(tup.Item1[key]);
						}
					}
					if (tup.Item2 != null && changes == tup.Item1.Count)
					{
						remade.Insert(0, tup.Item2);
					}
					else if (changes > 0)
					{
						remade.AddRange(redo);
					}
				}

				if (remade.Count > 0)
					list[i] = String.Join('-', remade);
			}
			return list;
		}
	}
	public static class ComparisionFunctions
	{
		public static bool DividedNoRemainder(object number, object divider)
		{
			if (number is int && divider is int)
				return (int)number % (int)divider == 0;
			return false;
		}
	}
}
