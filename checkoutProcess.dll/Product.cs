using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkoutProcess.dll
{
    public class Product
    {   
        // 此處id是product group Id 對應商品、規格、尺寸 而非prductID
        public int Id;
        public string Name;
        public decimal Price;
        public string Color;
        public string Size;
        public HashSet<string> Tags;

    }
}
