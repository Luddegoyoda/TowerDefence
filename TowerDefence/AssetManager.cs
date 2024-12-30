using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public static class AssetManager
    {
       public static List<Texture2D> allTextures = new List<Texture2D>();

        public static void LoadAllTextures(ContentManager content )
        {
            allTextures.Add(content.Load<Texture2D>("photomode_31072024_224844"));
            allTextures.Add(content.Load<Texture2D>("Virus"));
        }
    }
}
