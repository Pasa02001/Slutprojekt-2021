using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        const int BLOCK_SIZE = 96;
        private Texture2D stoneGround;
        private Texture2D stoneWall;
        private Texture2D rock;
        private Texture2D wall;
        Texture2D playertex;
        Vector2 playerPos = new Vector2(40, 100);
        Player player;

        public static int ScreenWidth
        {
            get;
            private set;
        }
        public static int ScreenHeight
        {
            get;
            private set;
        }
        //KOmentar

        static char[,] map = new char[,]
        {
            {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1' },
            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1' },
            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1' },
            {'1','0','0','0','0','0','0','0','0','2','0','0','0','0','2','0','0','0','0','1' },
            {'1','0','0','0','2','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1' },
            {'1','0','0','0','2','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1' },
            {'1','0','0','0','2','0','0','0','0','2','0','0','0','0','0','0','0','0','0','1' },
            {'1','0','0','0','2','0','0','0','0','0','0','0','0','0','0','0','2','0','0','1' },
            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1' },
            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1' },
            {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1' },
        };



        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
            graphics.PreferredBackBufferWidth = ScreenWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = ScreenHeight = GraphicsDevice.DisplayMode.Height;
            graphics.ApplyChanges();


        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            stoneGround = Content.Load<Texture2D>("Brick");
            stoneWall = Content.Load<Texture2D>("StoneWall");
            playertex = Content.Load<Texture2D>("Player");
            rock = Content.Load<Texture2D>("Rock");
            player = new Player(playertex, playerPos);

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            player.Update();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            GraphicsDevice.Clear(Color.Black);

           

            for (int y = 0; y< map.GetLength(0); y++)
            {
                for(int x = 0; x < map.GetLength(1); x++)
                {
                    if(map[y,x] == '0')
                    {

                        spriteBatch.Draw(stoneGround, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }
                    if (map[y,x] == '1')
                    {

                        spriteBatch.Draw(stoneWall, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }
                    if (map[y,x] == '2')
                    {

                        spriteBatch.Draw(rock, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }
                }
            }
            player.Draw(spriteBatch);

            // TODO: Add your drawing code here.
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
