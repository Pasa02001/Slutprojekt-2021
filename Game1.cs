using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private int score;
        private BinaryWriter bw;
        private BinaryReader br;



        //--------------------------- Till Mappen
        const int BLOCK_SIZE = 96; // Storleken på varje block i mappen
        private Texture2D stoneGround;
        private Texture2D stoneWall;
        private Texture2D rock;
        private Texture2D wallRight;
        private Texture2D wallLeft;
        private Texture2D wallBut;
        private Texture2D wallTop;
        private Texture2D chair;
        //------------------------
        /// <summary>
        /// Allt som ska in som textur i svälva mappen förutom block storleken. 
        /// </summary>



        private float angle; // Hållet texturena riktas 
        private Vector2 playerPos = new Vector2(1000, 500); //Positionen där spelaren börjar 
        private Player player; 
        private Vector2 mousePos; 

        private List<Bullet> bullets = new List<Bullet>();
        private WeaponHandler weaponHandler;
        public static GameTime Time;

        private List<Enemy> enemies = new List<Enemy>();
        private EnemySpawner enemySpawner;



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
            {'1','1','1','9','8','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1' },
            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','2','0','3','0','3','1' },
            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','3','0','3','1' },
            {'1','0','0','0','0','0','0','0','0','2','0','0','0','0','2','0','3','0','3','1' },
            {'6','0','0','0','2','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1' },
            {'7','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1' },
            {'1','0','0','0','0','0','0','0','0','2','0','0','0','0','0','0','0','0','0','1' },
            {'1','0','0','0','0','0','0','0','0','0','2','0','0','0','0','0','3','0','3','1' },
            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','3','0','3','1' },
            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','3','0','3','1' },
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

            enemySpawner = new EnemySpawner(enemies, bullets);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Assets.LoadAssets(Content, GraphicsDevice);

            if (File.Exists("Score.bin"))
            {
                br = new BinaryReader(new FileStream("Score.bin", FileMode.OpenOrCreate, FileAccess.Read));
                if (br.BaseStream.Length > 0)
                {
                    score = br.ReadInt32();
                   
                }
                br.Close();
            }
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            stoneGround = Content.Load<Texture2D>("GroundBrick");


            //walls 
            stoneWall = Content.Load<Texture2D>("StoneWall");
            wallLeft = Content.Load<Texture2D>("WallLeft"); // = 102 
            wallTop = Content.Load<Texture2D>("WallTop"); // = 100
            wallBut = Content.Load<Texture2D>("WallBut"); // = 101 
            wallRight = Content.Load<Texture2D>("WallRight"); // = 103

            //walls
            
            
            rock = Content.Load<Texture2D>("Oil");
            chair = Content.Load<Texture2D>("Chair");
            player = new Player(Assets.Player, playerPos, angle, mousePos);


            weaponHandler = new WeaponHandler(bullets);
            player.SetWeaponHandler(weaponHandler);


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

      
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Time = gameTime;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            weaponHandler.Update();
            
            foreach(Enemy item in enemies)
            {
                item.Update();
            }

            enemySpawner.Update(gameTime);


            for (int i=0; i < bullets.Count; i++)
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    if(bullets[i].GetDamage == Damage.player && enemies[j].HitBox.Intersects(bullets[i].HitBox))
                    {
                        enemies.RemoveAt(j);
                        bullets.RemoveAt(i);
                        score++;
                        bw = new BinaryWriter(new FileStream("Score.bin", FileMode.OpenOrCreate, FileAccess.Write));
                        bw.Write(score);
                        bw.Close();
                        i--;
                        j--;

                        break;
                    }
                }
            }

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
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();




            for (int y = 0; y< map.GetLength(0); y++)
            {
                for(int x = 0; x < map.GetLength(1); x++)
                {

                    if(map[y,x] == '0' || map[y,x] == '2' || map[y, x] == '3')// Marken på första bannan 
                    {

                        spriteBatch.Draw(stoneGround, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }



                    //walls
                    if (map[y,x] == '1') //väggen vanlig
                    { 
                        
                        spriteBatch.Draw(stoneWall, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE , BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }

                    if (map[y, x] == '6') //väggen top 
                    {

                        spriteBatch.Draw(wallTop, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }

                    if (map[y, x] == '7') //väggen Button
                    {

                        spriteBatch.Draw(wallBut, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }
                    if (map[y, x] == '8') //väggen Right
                    {

                        spriteBatch.Draw(wallRight, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }
                    if (map[y, x] == '9') //väggen left
                    {

                        spriteBatch.Draw(wallLeft, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE), Color.White);
                    }




                    if (map[y,x] == '2')
                    {

                        spriteBatch.Draw(rock, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE  , BLOCK_SIZE), Color.White);
                    }
                    if (map[y,x] == '3' )
                    {

                        spriteBatch.Draw(chair, new Rectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE  , BLOCK_SIZE), Color.White);
                    }
                }
            }
            foreach (Bullet item in bullets)
            {
                item.Draw(spriteBatch);

            }

            foreach(Enemy item in enemies)
            {
                item.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);

            // TODO: Add your drawing code here.
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
