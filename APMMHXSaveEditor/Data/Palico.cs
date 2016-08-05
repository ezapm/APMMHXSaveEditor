using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMMHXSaveEditor.Data
{
    public class Palico
    {
        public string Name { get; set; }
        public UInt32 XP { get; set; }
        public byte Level { get; set; } //Note that level 1 = 0
        public byte Forte { get; set; }
        public byte Enthusiasm { get; set; }
        public byte Target { get; set; }
        public byte[] EquippedActions { get; set; }
        public byte[] EquippedSkills { get; set; }
        public byte[] LearnedActions { get; set; }
        public byte[] LearnedSkills { get; set; }
        public UInt16 LearnedActionRNG { get; set; }
        public UInt16 LearnedSkillRNG { get; set; }
        public string Greeting { get; set; }
        public string NameGiver { get; set; }
        public string PreviousMaster { get; set; }
        public byte[] CoatRGBAValue { get; set; }
        public byte[] LeftEyeRGBAValue { get; set; }
        public byte[] RightEyeRGBAValue { get; set; }
        public byte[] VestRGBAValue { get; set; }
        
        //Unknown Values
        public byte[] Unknown1 { get; set; } //Place Holder Offset 0x58 Size 8
        public byte[] Unknown2 { get; set; } //Place Holder Offset 0xDC Size 62
        public byte[] Unknown3 { get; set; } //Place Holder Offset 0x11E Size 21


        public Palico()
        { 
        }

        public override string ToString()
        {
            if (this.Name == "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0")
                return "[Empty]";
            else
                return string.Format("[Lv. {0,2}] {1}", (this.Level + 1), this.Name);
        }
    }
}
