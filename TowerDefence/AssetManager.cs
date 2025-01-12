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
        public static SpriteFont font;

        public static void LoadAllTextures(ContentManager content )
        {
            allTextures.Add(content.Load<Texture2D>("GoldTexture"));
            allTextures.Add(content.Load<Texture2D>("Virus"));
            allTextures.Add(content.Load<Texture2D>("HealPreview"));
            allTextures.Add(content.Load<Texture2D>("AntiVirus"));
            allTextures.Add(content.Load<Texture2D>("CircuitBoard"));
            font = content.Load<SpriteFont>("font");
        }
    }
}
