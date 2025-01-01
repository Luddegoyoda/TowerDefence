using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class Healthbar
    {
        int maxHealth;
        int curerentHealth;
        Rectangle redFill, outline;

        public Healthbar(int maxHealth)
        {
            this.maxHealth = maxHealth;
            
        }


    }
}
