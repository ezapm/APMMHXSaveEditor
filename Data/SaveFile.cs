using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMMHXSaveEditor.Data
{
    public class SaveFile
    {
        public Player[] Players;

        public SaveFile(Player[] players)
        {
            this.Players = players;
        }

    }
}
