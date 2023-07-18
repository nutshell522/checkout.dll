using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkoutProcess.dll
{
    public class POS
    {
        public readonly List<DiscountRuleBase> ActivedRules = new List<DiscountRuleBase>();

		public bool CheckoutProcess(CartContext cart)
		{
			// reset cart
			cart.AppliedDiscounts.Clear();

			cart.TotalPrice = cart.PurchasedItems.Select(p => p.Price).Sum();
			foreach (var rule in this.ActivedRules)
			{
				var discounts = rule.Process(cart);
				cart.AppliedDiscounts.AddRange(discounts);
				if (rule.ExclusiveTag != null)
				{
					foreach (var d in discounts)
					{
						foreach (var p in d.Products) p.Tags.Add(rule.ExclusiveTag);
					}
				}
				cart.TotalPrice -= discounts.Select(d => d.Amount).Sum();
			}
			return true;
		}
	}
}
