using Microsoft.Xna.Framework;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public class TowerManager
    {
        public TowerManager() { }

        public bool CanPlaceTower(Tower newTower)
        {
            Color[] pixels = new Color[newTower.texture.Width * newTower.texture.Height];
            Color[] pixels2 = new Color[newTower.texture.Width * newTower.texture.Height];
            newTower.texture.GetData<Color>(pixels2);
            Game1.renderTarget.GetData(0, newTower.hitbox, pixels, 0, pixels.Length);
            for (int i = 0; i < pixels.Length; ++i)
            {
                if (pixels[i].A > 0.0f && pixels2[i].A > 0.0f)
                    return false;
            }
            return true;
        }
    }
}
