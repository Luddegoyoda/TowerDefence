using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class SoundManager
    {
        public static List<SoundEffectInstance> allSoundEffects = new List<SoundEffectInstance>();

        public static void PlayEffect(SoundEffectInstance clip)
        {
            clip.IsLooped = false;
            clip.Play();
        }


        public static void LoadAllSounds(ContentManager content)
        {
            SoundEffect newSound = content.Load<SoundEffect>("hitHurt");
            SoundEffectInstance soundInstance = newSound.CreateInstance();
            allSoundEffects.Add(soundInstance);

        }
    }
}
