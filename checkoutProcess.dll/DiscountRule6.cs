﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkoutProcess.dll
{
    public class DiscountRule6 : DiscountRuleBase
    {
        private string TargetTag;
        private int PercentOff;
        public DiscountRule6(string targetTag, int percentOff)
        {
            this.Name = "滿件折扣6";
            this.Note = $"滿{targetTag}二件結帳{10 - percentOff / 10}折";

            this.TargetTag = targetTag;
            this.PercentOff = percentOff;
        }
        public override IEnumerable<Discount> Process(CartContext cart)
        {
            List<Product> matched = new List<Product>();
            foreach (var p in cart.PurchasedItems.Where(p => p.Tags.Contains(this.TargetTag)).OrderByDescending(p => p.Price))
            {
                matched.Add(p);
                if (matched.Count == 2)
                {
                    yield return new Discount()
                    {
                        Amount = matched.Sum(x => x.Price) * this.PercentOff / 100,
                        Products = matched.ToArray(),
                        Rule = this
                    };
                    matched.Clear();
                }
            }
        }
    }
}
