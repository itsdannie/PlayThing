using CatAFKGame.Core.Config.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CatAFKGame.Core.Managers
{
    public class SpriteManager
    {
        private Texture2D _spriteSheet;
        private SpriteConfig _config;
        private IDictionary<string, IList<Rectangle>> _animations;

        public SpriteManager(SpriteConfig config)
        {
            _config = config;
            _animations = new Dictionary<string, IList<Rectangle>>();
        }

        public Texture2D SpriteSheet { get => _spriteSheet; }
        public int FrameHeight { get => _config.FrameHeight; }
        public int FrameWidth { get => _config.FrameWidth; }

        public void LoadContent(ContentManager content, GraphicsDeviceManager _graphics)
        {
            _spriteSheet = content.Load<Texture2D>(_config.AssetName);
            foreach (var animation in _config.Animations)
            {
                List<Rectangle> frames = new();
                for (int frameCount = 0; frameCount < animation.FramesCount; frameCount++)
                {
                    int previousFrames = (animation.FrameStart + frameCount) * _config.FrameWidth;
                    int row = (int)Math.Ceiling((double)(previousFrames + _config.FrameWidth) / _spriteSheet.Width);
                    int y = (row - 1) * _config.FrameHeight;
                    int x = previousFrames % _spriteSheet.Width;

                    frames.Add(new(x, y, _config.FrameWidth, _config.FrameHeight));
                }
                _animations.Add(animation.Name, frames);
            }
        }

        public IList<Rectangle> GetFrames(string animationName)
        {
            if (!_animations.ContainsKey(animationName))
                throw new ArgumentOutOfRangeException($"No animation frames found for '{animationName}.'");

            return _animations[animationName];
        }
    }
}