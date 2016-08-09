using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMMHXSaveEditor.Data
{
    public class Palico
    {
        //General
        public string Name { get; set; }
        public UInt32 XP { get; set; }
        public byte Level { get; set; } //Note that level 1 = 0
        public byte Forte { get; set; }
        public byte Enthusiasm { get; set; }
        public byte Target { get; set; }

        //Skills
        public byte[] EquippedActions { get; set; }
        public byte[] EquippedSkills { get; set; }
        public byte[] LearnedActions { get; set; }
        public byte[] LearnedSkills { get; set; }
        public UInt16 LearnedActionRNG { get; set; }
        public UInt16 LearnedSkillRNG { get; set; }

        //Text
        public string Greeting { get; set; }
        public string NameGiver { get; set; }
        public string PreviousMaster { get; set; }

        //Design
        public byte[] CoatRGBAValue { get; set; }
        public byte[] LeftEyeRGBAValue { get; set; }
        public byte[] RightEyeRGBAValue { get; set; }
        public byte[] VestRGBAValue { get; set; }
        public byte Voice { get; set; }
        public byte Eyes { get; set; }
        public byte Clothing { get; set; }
        public byte Coat { get; set; }
        public byte Ears { get; set; }
        public byte Tail { get; set; }

        
        //Unknown Values
        public byte[] Unknown1 { get; set; } //Place Holder Offset 0x58 Size 8
        public byte[] Unknown2 { get; set; } //Place Holder Offset 0xDC Size 51
        public byte[] Unknown3 { get; set; } //Place Holder Offset 0x0112 Size 2
        public byte[] Unknown4 { get; set; } //Place Holder Offset 0x0117 Size 3
        public byte[] Unknown5 { get; set; } //Place Holder Offset 0x012A Size 21

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
