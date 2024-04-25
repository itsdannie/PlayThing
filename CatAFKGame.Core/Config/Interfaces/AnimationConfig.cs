using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAFKGame.Core.Config.Interfaces
{
    public class SpriteConfig
    {
        public string AssetName { get; set; }
        public int FrameHeight { get; set; }
        public int FrameWidth { get; set; }
        public ICollection<AnimationConfig> Animations { get; set; }
    }

    public class AnimationConfig
    {
        public string Name { get; set; }
        public int FrameStart { get; set; }
        public int FramesCount { get; set; }
    }

    public class CharacterConfig
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public SpriteConfig SpriteConfig { get; set; }
    }
}
