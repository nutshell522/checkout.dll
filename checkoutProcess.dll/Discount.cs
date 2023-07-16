using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkoutProcess.dll
{
    public class Discount
    {
        public int Id;
        public DiscountRuleBase Rule;
        public Product[] Products;
        public decimal Amount;
    }
}
