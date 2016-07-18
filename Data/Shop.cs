using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMMHXSaveEditor.Data
{
    public class Shop
    {
        public byte[] ShopData { get; set; }

        public Shop(byte[] ShopData)
        {
            this.ShopData = ShopData;
        }
    }
}
