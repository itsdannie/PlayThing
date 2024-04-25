using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAFKGame.Core.Models
{
    public class Animation
    {
        public Animation(string name, Texture2D texture, IList<Rectangle> frames, SpriteEffects effect)
        {
            Texture = texture;
            FrameSpeed = 0.1f;
            IsLooping = true;
            Frames = frames;
            Name = name;
            Effect = effect;
        }

        public string Name { get; set; }
        public int CurrentFrame { get; set; }
        public float FrameSpeed { get; set; }
        public bool IsLooping { get; set; }
        public  SpriteEffects Effect { get; set; }
        public Texture2D Texture { get; private set; }
        public IList<Rectangle> Frames { get; private set; }
    }
}
