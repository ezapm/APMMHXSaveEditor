using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using APMMHXSaveEditor.Data;
using APMMHXSaveEditor.Util;

namespace APMMHXSaveEditor.Util
{
    public class DataExtractor
    {
        public string FilePath { get; set; }
        public byte[] FileData { get; set; }

        /// <summary>
        /// An object used to extract data out of a byte[]
        /// </summary>
        /// <param name="filePath">File path of the file</param>
        public DataExtractor(string filePath)
        {
            this.FilePath = filePath;
            this.FileData = File.ReadAllBytes(filePath);
        }

        /// <summary>
        /// Get a save file from the FileData bytes
        /// </summary>
        /// <returns>A save file object from the file given</returns>
        public SaveFile GetSaveFile()
        {
            Player[] players = new Player[3];
            BinaryReader binaryReader = new BinaryReader((Stream) new MemoryStream(FileData));

            for (int index = 0; index < 3; index++)
            {
                Player player = new Player();
                if (FileData[Offsets.FIRST_CHAR_SLOT_USED + index] == 0)
                {
                    players[index] = null;
                    continue;
                }

                //Player Base Offset
                binaryReader.BaseStream.Seek(Offsets.FIRST_CHARACTER_OFFSET + (index * 4), SeekOrigin.Begin);
                player.SaveOffset = binaryReader.ReadUInt32();

                //Player General
                binaryReader.BaseStream.Seek(player.SaveOffset, SeekOrigin.Begin);
                //player.Name = Encoding.UTF8.GetString(binaryReader.ReadBytes(32), 0, 32); //Loading Screen. Might have problem when you save as prowler
                binaryReader.ReadBytes(32); //Skips first 32 bytes
                player.PlayTime = binaryReader.ReadUInt32();
                player.Funds = binaryReader.ReadInt32(); //How much money is on loading screen
                player.HunterRank = binaryReader.ReadUInt16();
                binaryReader.ReadUInt16(); //Skip 2 1-byte unknowns
                player.HunterArt1 = binaryReader.ReadUInt16();
                player.HunterArt2 = binaryReader.ReadUInt16();
                player.HunterArt3 = binaryReader.ReadUInt16();
                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.STORED_NAME_OFFSET, SeekOrigin.Begin);
                player.Name = Encoding.UTF8.GetString(binaryReader.ReadBytes(32), 0, 32);

                //Player Details
                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.CHARACTER_VOICE_OFFSET, SeekOrigin.Begin);
                player.Voice = binaryReader.ReadByte();
                player.EyeColor = binaryReader.ReadByte();
                player.Clothing = binaryReader.ReadByte();
                player.Gender = binaryReader.ReadByte();
                player.HuntingStyle = binaryReader.ReadByte();
                player.HairStyle = binaryReader.ReadByte();
                player.Face = binaryReader.ReadByte();
                player.Features = binaryReader.ReadByte();

                //Player Colors
                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.CHARACTER_SKIN_COLOR_OFFSET, SeekOrigin.Begin);
                player.SkinColorRGBA = binaryReader.ReadBytes(4);
                player.HairColorRGBA = binaryReader.ReadBytes(4);
                player.FeaturesColorRGBA = binaryReader.ReadBytes(4);
                player.ClothingColorRGBA = binaryReader.ReadBytes(4);

                //Points
                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.HR_POINTS_OFFSET, SeekOrigin.Begin);
                player.HRPoints = binaryReader.ReadInt32();
                player.Zenny = binaryReader.ReadInt32();
                binaryReader.ReadInt32(); //Skip 4-byte unkown
                player.AcademyPoints = binaryReader.ReadInt32();
                player.BerunaPoints = binaryReader.ReadInt32();
                player.KokotoPoints = binaryReader.ReadInt32();
                player.PokkePoints = binaryReader.ReadInt32();
                player.YukumoPoints = binaryReader.ReadInt32();

                //Item Box
                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.ITEM_BOX_OFFSET, SeekOrigin.Begin);
                byte[] itemBoxBytes = binaryReader.ReadBytes(Constants.SIZEOF_ITEMBOX);
                player.ItemBox = GetItems(itemBoxBytes);

                //Pouch
                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.POUCH_OFFSET, SeekOrigin.Begin);
                byte[] itemPouchBytes = binaryReader.ReadBytes(Constants.SIZEOF_ITEMPOUCH);
                player.ItemPouch = GetItems(itemPouchBytes);

                //Equipment
                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.EQUIPMENT_BOX_OFFSET, SeekOrigin.Begin);
                player.EquipmentBox = new Equipment[Constants.TOTAL_ITEM_BOX_SLOTS];
                for (int equipmentIndex = 0; equipmentIndex < Constants.TOTAL_ITEM_BOX_SLOTS; equipmentIndex++)
                {
                    player.EquipmentBox[equipmentIndex] = new Equipment(binaryReader.ReadBytes(Constants.SIZEOF_EQUIPMENT));
                }

                //Palicos
                player.Palicos = new Palico[Constants.TOTAL_PALICOS];
                for(int pIndex = 0; pIndex < Constants.TOTAL_PALICOS; pIndex++)
                {
                    binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.PALICO_OFFSET + (pIndex * Constants.SIZEOF_PALICO), SeekOrigin.Begin);
                    player.Palicos[pIndex] = GetPalcio(binaryReader.ReadBytes(Constants.SIZEOF_PALICO));
                }

                //Palico Equipment
                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.PALICO_EQUIPMENT_OFFSET, SeekOrigin.Begin);
                player.PalicoEquipment = new Equipment[Constants.TOTAL_PALICO_EQUIPMENT_SLOTS];
                for (int i = 0; i < Constants.TOTAL_PALICO_EQUIPMENT_SLOTS; i++)
                {
                    player.PalicoEquipment[i] = new Equipment(binaryReader.ReadBytes(Constants.SIZEOF_EQUIPMENT));
                }
                
                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.PLAYER_GUILD_CARD_OFFSET, SeekOrigin.Begin);
                player.PlayerGuildCard = new GuildCard(binaryReader.ReadBytes(Constants.SIZEOF_GUILD_CARD));

                //Shops
                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.CRAFTABLE_ARMOR_SHOP_OFFSET, SeekOrigin.Begin);
                player.CraftableArmorShops = new Shop[Constants.TOTAL_CRAFTABLE_ARMOR_SHOPS];
                for (int i = 0; i < Constants.TOTAL_CRAFTABLE_ARMOR_SHOPS; i++)
                {
                    player.CraftableArmorShops[i] = new Shop(binaryReader.ReadBytes(Constants.SIZEOF_CRAFTABLE_ARMOR));
                }

                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.CRAFTABLE_WEAPONS_OFFSET, SeekOrigin.Begin);
                player.CraftableWeaponShops = new Shop[Constants.TOTAL_CRAFTABLE_WEAPON_SHOPS];
                int weaponIndex = 0;
                for (int i = 0; i < 15; i++)
                {
                    if (i == 5) //Skip the medium bow gun. I dont even know why capcom has this. 
                    {
                        binaryReader.ReadBytes(Constants.SIZEOF_CRAFTABLE_WEAPON);
                        continue;
                    }
                    player.CraftableWeaponShops[weaponIndex] = new Shop(binaryReader.ReadBytes(Constants.SIZEOF_CRAFTABLE_WEAPON));
                    weaponIndex++;
                }

                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.CRAFTABLE_PALICO_GEAR_OFFSET, SeekOrigin.Begin);
                player.CraftablePalicoShops = new Shop[Constants.TOTAL_CRAFTABLE_PALICO_SHOPS];
                for (int i = 0; i < Constants.TOTAL_CRAFTABLE_PALICO_SHOPS; i++)
                {
                    player.CraftablePalicoShops[i] = new Shop(binaryReader.ReadBytes(Constants.SIZEOF_CRAFTABLE_PALICO_GEAR));
                }

                //Unlocked Box Data
                binaryReader.BaseStream.Seek(player.SaveOffset + Offsets.UNLOCKED_BOXES_OFFSET, SeekOrigin.Begin);
                player.UnlockedBoxData = binaryReader.ReadBytes(8);

                players[index] = player;
            }

            return new SaveFile(players);
        }

        /// <summary>
        /// Edit the FileData bytes to match the save file
        /// </summary>
        /// <param name="saveFile">The save file to save</param>
        public void SaveData(SaveFile saveFile)
        {
            BinaryWriter binaryWriter = new BinaryWriter((Stream)new MemoryStream(FileData));
            for (int index = 0; index < 3; index++)
            {
                if (FileData[Offsets.FIRST_CHAR_SLOT_USED + index] == 0)
                {
                    continue;
                }

                Player player = saveFile.Players[index];

                //General
                binaryWriter.BaseStream.Seek(player.SaveOffset, SeekOrigin.Begin);
                byte[] nameBuff = new byte[Constants.SIZEOF_NAME];
                Encoding.UTF8.GetBytes(player.Name, 0, player.Name.Length, nameBuff, 0);
                binaryWriter.Write(nameBuff);
                binaryWriter.Write(player.PlayTime);
                binaryWriter.Write(player.Funds);
                binaryWriter.Write(player.HunterRank);
                binaryWriter.BaseStream.Seek(2, SeekOrigin.Current); //Skip 2
                binaryWriter.Write(player.HunterArt1);
                binaryWriter.Write(player.HunterArt2);
                binaryWriter.Write(player.HunterArt3);

                //Stored Name
                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.STORED_NAME_OFFSET, SeekOrigin.Begin);
                binaryWriter.Write(nameBuff);

                //Stored Play Time
                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.STORED_PLAY_TIME_OFFSET, SeekOrigin.Begin);
                binaryWriter.Write(player.PlayTime);
                
                //Player Details
                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.CHARACTER_VOICE_OFFSET, SeekOrigin.Begin);
                binaryWriter.Write(player.Voice);
                binaryWriter.Write(player.EyeColor);
                binaryWriter.Write(player.Clothing);
                binaryWriter.Write(player.Gender);
                binaryWriter.Write(player.HuntingStyle);
                binaryWriter.Write(player.HairStyle);
                binaryWriter.Write(player.Face);
                binaryWriter.Write(player.Features);

                //Player Colors
                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.CHARACTER_SKIN_COLOR_OFFSET, SeekOrigin.Begin);
                binaryWriter.Write(player.SkinColorRGBA);
                binaryWriter.Write(player.HairColorRGBA);
                binaryWriter.Write(player.FeaturesColorRGBA);
                binaryWriter.Write(player.ClothingColorRGBA);

                //Points
                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.HR_POINTS_OFFSET, SeekOrigin.Begin);
                binaryWriter.Write(player.HRPoints);
                binaryWriter.Write(player.Zenny);
                binaryWriter.BaseStream.Seek(4, SeekOrigin.Current); //Skip 4 unknown
                binaryWriter.Write(player.AcademyPoints);
                binaryWriter.Write(player.BerunaPoints);
                binaryWriter.Write(player.KokotoPoints);
                binaryWriter.Write(player.PokkePoints);
                binaryWriter.Write(player.YukumoPoints);

                //Item Box
                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.ITEM_BOX_OFFSET, SeekOrigin.Begin);
                byte[] itemBoxBytes = PackItems(player.ItemBox);
                binaryWriter.Write(itemBoxBytes);

                //Item Pouch
                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.POUCH_OFFSET, SeekOrigin.Begin);
                byte[] itemPouchBytes = PackItems(player.ItemPouch);
                binaryWriter.Write(itemPouchBytes);

                //Equipment
                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.EQUIPMENT_BOX_OFFSET, SeekOrigin.Begin);
                for (int equipmentIndex = 0; equipmentIndex < Constants.TOTAL_ITEM_BOX_SLOTS; equipmentIndex++)
                {
                    binaryWriter.Write(player.EquipmentBox[equipmentIndex].EquipmentBytes);
                }

                //Palicos
                for (int pIndex = 0; pIndex < Constants.TOTAL_PALICOS; pIndex++)
                {
                    binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.PALICO_OFFSET + (pIndex * Constants.SIZEOF_PALICO), SeekOrigin.Begin);
                    binaryWriter.Write(PackPalico(player.Palicos[pIndex]));
                }

                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.PALICO_EQUIPMENT_OFFSET, SeekOrigin.Begin);
                for (int i = 0; i < Constants.TOTAL_PALICO_EQUIPMENT_SLOTS; i++)
                {
                    binaryWriter.Write(player.PalicoEquipment[i].EquipmentBytes);
                }

                //Guild Card
                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.PLAYER_GUILD_CARD_OFFSET, SeekOrigin.Begin);
                binaryWriter.Write(player.PlayerGuildCard.GuildCardData);

                //Shops
                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.CRAFTABLE_ARMOR_SHOP_OFFSET, SeekOrigin.Begin);
                for (int i = 0; i < Constants.TOTAL_CRAFTABLE_ARMOR_SHOPS; i++)
                {
                    binaryWriter.Write(player.CraftableArmorShops[i].ShopData);
                }

                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.CRAFTABLE_WEAPONS_OFFSET, SeekOrigin.Begin);
                int weaponIndex = 0;
                for (int i = 0; i < 15; i++)
                {
                    if (i == 5) //Skip the medium bow gun. I dont even know why capcom has this. 
                    {
                        binaryWriter.Seek(40, SeekOrigin.Current);
                        continue;
                    }
                    binaryWriter.Write(player.CraftableWeaponShops[weaponIndex].ShopData);
                    weaponIndex++;
                }

                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.CRAFTABLE_PALICO_GEAR_OFFSET, SeekOrigin.Begin);
                for (int i = 0; i < Constants.TOTAL_CRAFTABLE_PALICO_SHOPS; i++)
                {
                    binaryWriter.Write(player.CraftablePalicoShops[i].ShopData);
                }

                //Unlocked Box Data
                binaryWriter.BaseStream.Seek(player.SaveOffset + Offsets.UNLOCKED_BOXES_OFFSET, SeekOrigin.Begin);
                binaryWriter.Write(player.UnlockedBoxData);
            }
        }

        /// <summary>
        /// Get an array of items
        /// </summary>
        /// <param name="buffer">byte array of items</param>
        /// <returns>Returns an item array</returns>
        public static Item[] GetItems(byte[] buff)
        {
            double totalItems = buff.Length / 2.25; 
            Item[] items = new Item[(int)totalItems];

            uint byteindex = 0;
            uint num1 = 0;
            uint num2 = 0;
            for (int index = 0; index < items.Length; index++)
            {
                byte num3 = 0;
                while (num2 < 18U)
                {
                    num3 = buff[byteindex++];
                    uint num4 = num1 >> 8;
                    num1 = (uint)((int)num3 << 24 | (int)num4 & 16777215);
                    num2 += 8U;
                }
                if (num2 >= 18U)
                {
                    uint num4 = num1 >> 32 - (int)num2 & 262143U;
                    num1 = (uint)num3 << 24;
                    num2 -= 18U;
                    items[index] = new Item(num4 & 2047U, num4 >> 11);
                }
            }

            return items;
        }

        /// <summary>
        /// Pack items into a byte array using the game save algorithm.
        /// </summary>
        /// <param name="items">The items to pack</param>
        /// <returns>Packed byte arrray</returns>
        public static byte[] PackItems(Item[] items)
        {
            int byteIndex = 0;
            double totalItems = 2.25 * items.Length; //Yeah this is pretty bad. Might kick me in the ass.
            byte[] buffer = new byte[(int)totalItems];
            
            uint num1 = 0;
            uint num2 = 0;
            for (int index = 0; index < items.Length; ++index)
            {
                num1 = (items[index].ItemAmount << 11 | items[index].ItemID) << (int)num2 | num1;
                num2 += 18U;
                while (num2 >= 8U)
                {
                    buffer[byteIndex++] = (byte)num1;
                    num1 >>= 8;
                    num2 -= 8U;
                }
            }
            return buffer;
        }

        /// <summary>
        /// Get palico from byte[]
        /// </summary>
        /// <param name="buffer">buffer containing the palico data</param>
        /// <returns></returns>
        public static Palico GetPalcio(byte[] buffer)
        {
            Palico palico = new Palico();
            BinaryReader binaryReader = new BinaryReader((Stream) new MemoryStream(buffer));

            palico.Name = Encoding.UTF8.GetString(binaryReader.ReadBytes(Constants.SIZEOF_NAME), 0, Constants.SIZEOF_NAME);
            palico.XP = binaryReader.ReadUInt32();
            palico.Level = binaryReader.ReadByte();
            palico.Forte = binaryReader.ReadByte();
            palico.Enthusiasm = binaryReader.ReadByte();
            palico.Target = binaryReader.ReadByte();
            palico.EquippedActions = binaryReader.ReadBytes(8);
            palico.EquippedSkills = binaryReader.ReadBytes(8);
            palico.LearnedActions = binaryReader.ReadBytes(16);
            palico.LearnedSkills = binaryReader.ReadBytes(12);
            palico.LearnedActionRNG = binaryReader.ReadUInt16();
            palico.LearnedSkillRNG = binaryReader.ReadUInt16();
            palico.Unknown1 = binaryReader.ReadBytes(8);
            palico.Greeting = Encoding.UTF8.GetString(binaryReader.ReadBytes(Constants.SIZEOF_PALICO_GREETINGS), 0, Constants.SIZEOF_PALICO_GREETINGS);
            palico.NameGiver = Encoding.UTF8.GetString(binaryReader.ReadBytes(Constants.SIZEOF_NAME), 0, Constants.SIZEOF_NAME);
            palico.PreviousMaster = Encoding.UTF8.GetString(binaryReader.ReadBytes(Constants.SIZEOF_NAME), 0, Constants.SIZEOF_NAME);
            palico.Unknown2 = binaryReader.ReadBytes(62);
            palico.CoatRGBAValue = binaryReader.ReadBytes(4);
            palico.LeftEyeRGBAValue = binaryReader.ReadBytes(4);
            palico.RightEyeRGBAValue = binaryReader.ReadBytes(4);
            palico.VestRGBAValue = binaryReader.ReadBytes(4);
            palico.Unknown3 = binaryReader.ReadBytes(21);

            return palico;
        }


        /// <summary>
        /// Convert palico to it's byte[]
        /// </summary>
        /// <param name="palico">Palico to pack</param>
        /// <returns></returns>
        public static byte[] PackPalico(Palico palico)
        {
            byte[] buffer = new byte[Constants.SIZEOF_PALICO];
            BinaryWriter binaryWriter = new BinaryWriter((Stream)new MemoryStream(buffer));

            byte[] palicoNameBuff = new byte[Constants.SIZEOF_NAME];
            Encoding.UTF8.GetBytes(palico.Name, 0, palico.Name.Length, palicoNameBuff, 0);
            binaryWriter.Write(palicoNameBuff);
            binaryWriter.Write(palico.XP);
            binaryWriter.Write(palico.Level);
            binaryWriter.Write(palico.Forte);
            binaryWriter.Write(palico.Enthusiasm);
            binaryWriter.Write(palico.Target);
            binaryWriter.Write(palico.EquippedActions);
            binaryWriter.Write(palico.EquippedSkills);
            binaryWriter.Write(palico.LearnedActions);
            binaryWriter.Write(palico.LearnedSkills);
            binaryWriter.Write(palico.LearnedActionRNG);
            binaryWriter.Write(palico.LearnedSkillRNG);
            binaryWriter.Write(palico.Unknown1);

            //Texts
            byte[] palicoGreetingsBuff = new byte[Constants.SIZEOF_PALICO_GREETINGS];
            Encoding.UTF8.GetBytes(palico.Greeting, 0, palico.Greeting.Length, palicoGreetingsBuff, 0);
            binaryWriter.Write(palicoGreetingsBuff);
            byte[] palicoNamegiverBuff = new byte[Constants.SIZEOF_NAME];
            Encoding.UTF8.GetBytes(palico.NameGiver, 0, palico.NameGiver.Length, palicoNamegiverBuff, 0);
            binaryWriter.Write(palicoNamegiverBuff);
            byte[] palicoPreviousOwner = new byte[Constants.SIZEOF_NAME];
            Encoding.UTF8.GetBytes(palico.PreviousMaster, 0, palico.PreviousMaster.Length, palicoPreviousOwner, 0);
            binaryWriter.Write(palicoPreviousOwner);

            //RGBA
            binaryWriter.Write(palico.Unknown2);
            binaryWriter.Write(palico.CoatRGBAValue);
            binaryWriter.Write(palico.LeftEyeRGBAValue);
            binaryWriter.Write(palico.RightEyeRGBAValue);
            binaryWriter.Write(palico.VestRGBAValue);
            binaryWriter.Write(palico.Unknown3);

            return buffer;
        }
    }
}
