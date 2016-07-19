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
        public byte Level { get; set; }
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
        public byte[] RGBAValue { get; set; }

        public Palico()
        { 
        }

        public override string ToString()
        {
            if (this.Name == "")
                return "[Empty]";
            else
                return string.Format("[Lv. {0,2}] {1}", this.Level, this.Name);
        }
    }
}
