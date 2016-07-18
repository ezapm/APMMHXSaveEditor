using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APMMHXSaveEditor.Data;

namespace APMMHXSaveEditor.Util
{
    public static class Tools
    {
        /// <summary>
        /// Unlock all bits in a 40 byte shop.
        /// </summary>
        /// <param name="shops">The shop[] to change</param>
        public static void CraftWeaponShopUnlock(Shop[] shops)
        {
            for (int i = 0; i < shops.Length; i++)
            {
                for (int j = 4; j < 20; j++)
                {
                    shops[i].ShopData[j] = 0xFF; //Available Weapons
                    shops[i].ShopData[j + 20] = 0xFF; //New Flags
                }
            }
        }

        /// <summary>
        /// Unlock all bits in a 392 byte shop
        /// </summary>
        /// <param name="shops">shop to fill</param>
        public static void CraftArmorUnlock(Shop[] shops)
        {
            for (int i = 0; i < shops.Length; i++)
            {
                for (int j = 4; j < 192; j++)
                {
                    shops[i].ShopData[j] = 0x33; //Available Armors
                    shops[i].ShopData[j + 192] = 0x33; //New Flags
                }
            }
        }

        /// <summary>
        /// Unlock all bits in a 48 byte shop shop
        /// </summary>
        /// <param name="shops">shop to fill</param>
        public static void CraftPalicoGearUnlock(Shop[] shops)
        {
            for (int i = 0; i < shops.Length; i++)
            {
                for (int j = 4; j < 48; j++)
                {
                    shops[i].ShopData[j] = 0xFF; //Available Gear
                    shops[i].ShopData[j + 48] = 0xFF; //New Flags
                }
            }
        }

        /// <summary>
        /// Set all ItemAmount in Item[] to 99
        /// </summary>
        /// <param name="items">Item array to max out</param>
        public static void MaxItems(Item[] items)
        {
            foreach (Item item in items)
            {
                if (item.ItemID != 0)
                {
                    item.ItemAmount = 99;
                }
            }
        }
    }
}
