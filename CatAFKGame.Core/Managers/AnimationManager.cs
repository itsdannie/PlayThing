using CatAFKGame.Core.Models;
using CatAFKGame.Core.Models.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatAFKGame.Core.Managers
{
    public class AnimationManager
    {
        private Animation _animation;
        private float _timer;
        private readonly SpriteManager _spriteManager;

        public AnimationManager(SpriteManager spriteManager)
        {
            _spriteManager = spriteManager;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (_animation == null)
                return;

            spriteBatch.Draw(_animation.Texture,
                position,
                _animation.Frames[_animation.CurrentFrame],
                Color.White,
                0.0f,
                new Vector2(0,0), 
                1.0f,
                _animation.Effect,
                0.0f);


            //spriteBatch.Draw(_animation.Texture,
            //    position,
            //    _animation.Frames[_animation.CurrentFrame],
            //    Color.White);
        }

        /// <summary>
        /// Gets a texture origin at the bottom center of each frame.
        /// </summary>
        //public Vector2 Origin
        //{
        //    get { return new Vector2(_spriteManager.FrameWidth / 2.0f, _spriteManager.FrameHeight); }
        //}


        public void Play(string animationName, SpriteEffects effect)
        {
            if (_animation?.Name == animationName)
                return;

            _animation = new Animation(animationName, _spriteManager.SpriteSheet, _spriteManager.GetFrames(animationName), effect);
            _animation.CurrentFrame = 0;
            _timer = 0;
        }

        public void Stop()
        {
            _timer = 0f;
            _animation.CurrentFrame = 0;
        }

        /// <summary>
        /// GameTime stores the amount of time that has passed since the last Update or the last Draw
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (_animation is null)
                return;
            
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0f;
                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.Frames.Count)
                    _animation.CurrentFrame = 0;
            }
        }
    }
}
