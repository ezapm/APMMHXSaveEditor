using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMMHXSaveEditor.Data
{
    public class Player
    {
        public UInt32 SaveOffset { get; set; }
        //General Info
        public string Name { get; set; }
        public UInt32 PlayTime { get; set; }
        public int Funds { get; set; }
        public UInt16 HunterRank { get; set; }
        public UInt16 HunterArt1 { get; set; }
        public UInt16 HunterArt2 { get; set; }
        public UInt16 HunterArt3 { get; set; }

        //Character Details
        public byte Voice { get; set; }
        public byte EyeColor { get; set; }
        public byte Clothing { get; set; }
        public byte Gender { get; set; } //TWO GENDERS Male = 0; Female = 1;
        public byte HuntingStyle { get; set; }
        public byte HairStyle { get; set; }
        public byte Face { get; set; }
        public byte Features { get; set; }

        //Character Colors
        public byte[] SkinColorRGBA { get; set; }
        public byte[] HairColorRGBA { get; set; }
        public byte[] FeaturesColorRGBA { get; set; }
        public byte[] ClothingColorRGBA { get; set; }

        //Points
        public int HRPoints { get; set; }
        public int Zenny { get; set; }
        public int AcademyPoints { get; set; }
        public int BerunaPoints { get; set; }
        public int KokotoPoints { get; set; }
        public int PokkePoints { get; set; }
        public int YukumoPoints { get; set; }

        public Equipment[] EquipmentBox { get; set; }
        public Item[] ItemBox { get; set; }
        public Item[] ItemPouch { get; set; }
        public Palico[] Palicos { get; set; }
        public Equipment[] PalicoEquipment { get; set; }

        //Shop Data
        public Shop[] CraftableArmorShops { get; set; }
        public Shop[] CraftableWeaponShops { get; set; }
        public Shop[] CraftablePalicoShops { get; set; }

        public byte[] UnlockedBoxData { get; set; } //Holds data for unlocked boxes
        public byte[] UnlockedFoodData { get; set; } 
        public byte[] AwardData { get; set; }

        public GuildCard PlayerGuildCard { get; set; }

        //Shoutouts
        public string[] ShoutOuts { get; set; }
        public string[] AutomaticShoutOuts { get; set; }

        public Player()
        {
        }

        public override string ToString()
        {
            return string.Format("{0} + [HR: {1}]", this.Name, this.HunterRank);
        }
    }
}
