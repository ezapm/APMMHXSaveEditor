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

        /// <summary>
        /// Set all ItemID ItemAmount in Item[] to 0
        /// </summary>
        /// <param name="items">Item array to clear out</param>
        public static void ClearItems(Item[] items)
        {
            foreach (Item item in items)
            {
                item.ItemID = 0;
                item.ItemAmount = 0;
            }
        }

        /// <summary>
        /// Set all ItemID ItemAmount in Item[] to 0 in a set range
        /// </summary>
        /// <param name="items">Item list to clear</param>
        /// <param name="startIndex">Start index (index 0)</param>
        /// <param name="endIndex">End index</param>
        public static void ClearItems(Item[] items, int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                items[i].ItemID = 0;
                items[i].ItemAmount = 0;
            }
        }

        /// <summary>
        /// Set all bytes in equipment[] to 0 
        /// </summary>
        /// <param name="equipments"></param>
        public static void ClearEquipment(Equipment[] equipments)
        {
            foreach (Equipment equip in equipments)
            {
                Array.Clear(equip.EquipmentBytes, 0, Constants.SIZEOF_EQUIPMENT);
            }
        }


        /// <summary>
        /// Set all bytes in equipment[] to 0 in a specified range
        /// </summary>
        /// <param name="equipments">Equipment[] to clear</param>
        /// <param name="startIndex">Start index (index 0)</param>
        /// <param name="endIndex">End index</param>
        public static void ClearEquipment(Equipment[] equipments, int startIndex, int endIndex)
        {
            for (int eqIndex = startIndex; eqIndex < endIndex; eqIndex++)
            {
                Array.Clear(equipments[eqIndex].EquipmentBytes, 0, Constants.SIZEOF_EQUIPMENT);
            }
        }

        /// <summary>
        /// Unlock all boxes and palico boxes
        /// </summary>
        /// <param name="boxData">box data bytes</param>
        public static void UnlockAllBoxes(byte[] boxData)
        {
            byte[] unlockData = new byte[] { 0x00, 0x20, 0x60, 0x40, 0x00, 0x20, 0x60, 0x40 };
            Buffer.BlockCopy(unlockData, 0, boxData, 0, unlockData.Length);
        }


        /// <summary>
        /// Get a blank equipment with proper byte size
        /// </summary>
        /// <returns>Returns a blank equipment</returns>
        public static Equipment GetBlankEquipment()
        {
            return new Equipment(new byte[Constants.SIZEOF_EQUIPMENT]);
        }
    }
}
