using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CISESPORT
{
    
    internal class Team
    {
        Player player;
        List<Player> players = new List<Player>();
        private int ageSum = 0;
        private string team;
        private string name;
        private string lastname;
        
        public void addperson2Class(Player p)
        {
            this.players.Add(p);
        }

        

    }
}
