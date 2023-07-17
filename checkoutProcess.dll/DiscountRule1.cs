using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkoutProcess.dll
{
    public class DiscountRule1 : DiscountRuleBase
    {
        private string TargetTag;
        private int MinCount;
        private decimal DiscountAmount;

        public DiscountRule1(string targetTag, int minBuyCount, decimal discountAmount)
        {
            this.Name = "滿件折扣1";
            this.Note = $"{targetTag}滿{minBuyCount}件折{discountAmount}";
            this.TargetTag = targetTag;
            this.MinCount = minBuyCount;
            this.DiscountAmount = discountAmount;
        }

        public override IEnumerable<Discount> Process(CartContext cart)
        {
            List<Product> matched = new List<Product>();
            foreach (var p in cart.PurchasedItems.Where(p => p.Tags.Contains(this.TargetTag)))
            {
                matched.Add(p);
                if (matched.Count == this.MinCount)
                {
                    yield return new Discount()
                    {
                        Amount = this.DiscountAmount,
                        Products = matched.ToArray(),
                        Rule = this
                    };
                    matched.Clear();
                }
            }
        }
    }
}
