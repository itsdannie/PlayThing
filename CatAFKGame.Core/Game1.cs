using CatAFKGame.Core.Managers;
using CatAFKGame.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CatAFKGame.Core
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IConfiguration _charactersConfig;
        private IScene _scene;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile($"Config/spritesheetsConfig.json", false, true);
            _charactersConfig = builder.Build();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _scene = new BattleGroundsScene(_charactersConfig);
            _scene.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {       
            _scene.LoadContent(Content, _graphics);     
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit(); 
            
            _scene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _scene.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
