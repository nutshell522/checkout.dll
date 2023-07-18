using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkoutProcess.dll
{
    public class CartContext
    {
        public readonly List<Product> PurchasedItems = new List<Product>();
        public readonly List<Discount> AppliedDiscounts = new List<Discount>();
        public decimal TotalPrice = 0m;
		public IEnumerable<Product> GetVisiblePurchasedItems(string exclusiveTag)
		{
			if (string.IsNullOrEmpty(exclusiveTag)) return this.PurchasedItems;
			return this.PurchasedItems.Where(p => !p.Tags.Contains(exclusiveTag));
		}
	}
}
