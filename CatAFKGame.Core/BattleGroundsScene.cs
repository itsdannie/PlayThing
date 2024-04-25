using CatAFKGame.Core.Config.Interfaces;
using CatAFKGame.Core.Models;
using CatAFKGame.Core.Models.Enums;
using CatAFKGame.Core.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAFKGame.Core
{
    public interface IScene
    {
        void Initialize();
        void LoadContent(ContentManager content, GraphicsDeviceManager _graphics);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }

    public class BattleGroundsScene : IScene
    {
        private Texture2D _background;
        private IConfiguration _config;
        private ICollection<ICharacter> _characters;

        public BattleGroundsScene(IConfiguration config)
        {
            _config = config;
        }

        public void Initialize()
        {
            _characters = new HashSet<ICharacter>();
            CharacterConfig[] characters = _config.GetSection("Characters").Get<CharacterConfig[]>();

            _characters.Add(new Character(characters[0], new Vector2(50, 230)));
            _characters.Add(new Character(characters[0], new Vector2(600, 230), Orientation.Left));
        }

        public void LoadContent(ContentManager content, GraphicsDeviceManager _graphics)
        {
            _background = content.Load<Texture2D>("Backgrounds/Battleground");

            foreach (var character in _characters)
            {
                character.LoadContent(content, _graphics);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background,
                new Vector2(0, 0),
                null,
                Color.White,
                0.0f,
                new Vector2(0, 0),
                0.45f,
                SpriteEffects.None,
                0.0f);

            foreach (var character in _characters)
            {
                character.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var character in _characters)
            {
                character.Update(gameTime);
            }
        }
    }
}
