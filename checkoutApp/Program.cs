using checkoutProcess.dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace checkoutApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var products = LoadProducts();
			foreach (var p in products)
			{
				Console.WriteLine($"- {p.Name}      {p.Price:C}");
			}
			Console.WriteLine($"Total: {CheckoutProcess(products.ToArray()):C}");
			Console.ReadLine();
		}
		static decimal CheckoutProcess(Product[] products)
		{
			decimal amount = 0;
			foreach (var p in products)
			{
				amount += p.Price;
			}
			return amount;
		}

		static IEnumerable<Product> LoadProducts()
		{
			return JsonConvert.DeserializeObject<Product[]>(File.ReadAllText(@"products.json"));
		}
	}
}
