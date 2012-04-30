using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TileWorld
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TileWorldGame : Microsoft.Xna.Framework.Game
    {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        Tilesheet _masterTilesheet;
        Texture2D _masterTilesheetTexture;
        World _worldMap;

        public TileWorldGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _masterTilesheet = Content.Load<Tilesheet>("master-tilesheet");
            _masterTilesheetTexture = Content.Load<Texture2D>(_masterTilesheet.TextureName);
            _worldMap = Content.Load<World>("world");

            _graphics.PreferredBackBufferHeight = _masterTilesheet.TileSize.Y * _worldMap.Size.Y;
            _graphics.PreferredBackBufferWidth = _masterTilesheet.TileSize.X * _worldMap.Size.X;
            _graphics.ApplyChanges();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            for (int y = 0; y < _worldMap.Size.Y; y++)
            {
                for (int x = 0; x < _worldMap.Size.X; x++)
                {
                    var groundTileIndex = _worldMap.GetGroundTileIndex(new Point(x, y));
                    var sourceRectange = _masterTilesheet.GetGroundTileRectangle(groundTileIndex);
                    var destinationRectangle = new Rectangle(
                        x * _masterTilesheet.TileSize.X,
                        y * _masterTilesheet.TileSize.Y,
                        _masterTilesheet.TileSize.X,
                        _masterTilesheet.TileSize.Y);

                    _spriteBatch.Draw(
                        _masterTilesheetTexture,
                        destinationRectangle,
                        sourceRectange,
                        Color.White);
                }
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
