using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Momentum;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			SQLSimplifier sql = new SQLSimplifier();
			sql.Connect("ealdb1.eal.local", "EJL34_DB", "ejl34_usr", "Baz1nga34");
			Console.WriteLine("1: test delete");
			Console.WriteLine("2: test update");
			Console.WriteLine("3: test search");
			switch (Console.ReadLine())
			{
				case "1":
					int a = sql.Delete("AarskortMomentum", "ID", "1");
					Console.WriteLine("Deleted: "+a);
					break;
				case "2":
					Dictionary<string, string> list = new Dictionary<string, string>();
					list.Add("Fornavn", "Kartoffel");
					list.Add("Tlf", "10101010");
					int i = sql.Update("AarskortMomentum", list, 1);
					Console.WriteLine("Updated: "+ i);
					break;
				case "3":
					sql.Search();
					break;
			}
			sql.Dispose();
		}
	}
}
