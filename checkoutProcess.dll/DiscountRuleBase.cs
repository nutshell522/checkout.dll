using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace checkoutProcess.dll
{
    public abstract class DiscountRuleBase
    {
        public int Id;
        public string Name;
        public string Note;
        public abstract IEnumerable<Discount> Process(CartContext cart);

		public string ExclusiveTag = null;
	}
}
