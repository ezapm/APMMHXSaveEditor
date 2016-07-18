using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMMHXSaveEditor.Data
{
    public class Equipment
    {
        public byte[] EquipmentBytes { get; set; }

        public Equipment(byte[] bytes)
        {
            this.EquipmentBytes = bytes;
        }

        public Equipment GetClone()
        {
            if (this.EquipmentBytes == null)
                return null;

            int length = this.EquipmentBytes.Length;

            byte[] temp = new byte[length];
            for (int i = 0; i < temp.Length; i++)
            {
                byte b = this.EquipmentBytes[i];
                temp[i] = b;
            }

            return new Equipment(temp);
        }

        public Equipment(Equipment equip)
        {
            byte[] temp = new byte[equip.EquipmentBytes.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                byte b = equip.EquipmentBytes[i];
                temp[i] = b;
            }

            EquipmentBytes = temp;
        }

        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}
