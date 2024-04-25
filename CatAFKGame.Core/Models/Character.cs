using CatAFKGame.Core.Config.Interfaces;
using CatAFKGame.Core.Managers;
using CatAFKGame.Core.Models.Enums;
using CatAFKGame.Core.Models.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAFKGame.Core.Models
{
    public class Character: ICharacter
    {
        private readonly CharacterConfig _config;
        private readonly AnimationManager _animationManager;
        private readonly SpriteManager _spriteSheetManager;
      
        private Vector2 _position { get; set; }
        private Orientation _orientation { get; set; }

        public Character(CharacterConfig config, Vector2 position, Orientation orientation = Orientation.Right)
        {
            _config = config;
            _spriteSheetManager = new SpriteManager(config.SpriteConfig);
            _animationManager = new AnimationManager(_spriteSheetManager);
            _position = position;
            _orientation = orientation;
        }

        public int Health { get; set; }


        public void LoadContent(ContentManager content, GraphicsDeviceManager _graphics)
        {
            _spriteSheetManager.LoadContent(content, _graphics);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animationManager.Draw(spriteBatch, _position);
        }

        public void Update(GameTime gameTime)
        {
            SpriteEffects effect = _orientation == Orientation.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            _animationManager.Play("idle", effect);
            _animationManager.Update(gameTime);
        }
    }
}
