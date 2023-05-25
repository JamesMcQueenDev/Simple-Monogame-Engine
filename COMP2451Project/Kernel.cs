using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using COMP2451Project.Asset;

using COMP2451Project.EntityManagement;
using COMP2451Project.SceneManagement;
using COMP2451Project.CollidableManagement;
using COMP2451Project.InputManagement;
using COMP2451Project.AssetInterface;

namespace COMP2451Project
{
    public class Kernel : Game
    {
        //Local Variables to take in the dimensions of screen
        int screenHeight, screenWidth;

        GraphicsDeviceManager graphics;

        GraphicsDevice graphicsDevice;
        
        SpriteBatch spriteBatch;

        //Interfaces
        ISceneManager sceneManager;

        IEntityManager entityManager;

        ISceneGraph sceneGraph;

        ICollisionManager collisionManager;

        //Only using the keyboard input
        IKeyboardPublisher inputManager;

        //Local Dictionary to hold Entities
        IDictionary<string, IEntity> entities;


        public Kernel()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;

            //Instantiation of Interfaces
            sceneGraph = new SceneGraph();

            entityManager = new EntityManager();

            collisionManager = new CollisionManager();

            inputManager = new InputManager();

            //Calls and Assigns GetDictionaryInstance property in EntityManager
            entities = entityManager.GetDictionaryInstance;
        }

        /// <summary>
        /// Initialising the game state
        /// </summary>
        protected override void Initialize()
        {
            screenHeight = GraphicsDevice.Viewport.Height;
            screenWidth = GraphicsDevice.Viewport.Width;

            sceneManager = new SceneManager(screenWidth, screenHeight, sceneGraph);

            //----------Creates and Entity via EntityMangager and Returns It--------------//

            //----------PADDLE 1 (Left)----------//
            sceneManager.Spawn("paddle1", entityManager.Create<Paddle>("paddle1"));
            (entities["paddle1"] as Entity).Position = new Vector2(0 + 50, (screenHeight / 2));
            (entities["paddle1"] as Entity).Player = PlayerIndex.One;
            inputManager.Subscribe("paddle1", (entities["paddle1"] as IKeyboardListener));
                        

            //----------PADDLE 2 (Right)----------//
            sceneManager.Spawn("paddle2", entityManager.Create<Paddle>("paddle2"));
            (entities["paddle2"] as Entity).Position = new Vector2(screenWidth - 100, (screenHeight / 2));
            (entities["paddle2"] as Entity).Player = PlayerIndex.Two;
            inputManager.Subscribe("paddle2", (entities["paddle2"] as IKeyboardListener));

            //-------------BALL------------//
            sceneManager.Spawn("ball1", entityManager.Create<Ball>("ball1"));
            (entities["ball1"] as Entity).Position = new Vector2(screenWidth / 2, screenHeight / 2);

            //Initialising Collision Manager
            sceneManager.Initialise(collisionManager);

            base.Initialize();
        }

        /// <summary>
        /// Loads Textures to Entity
        /// </summary>
        protected override void LoadContent()
        {
            //-------------Passes object as an IEntity throught to Scene Manager------------//  

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Local Dictionary is set up to pass thorugh textures to Entity
            IDictionary<string, IEntity> accessDictionary;

            accessDictionary = sceneManager.SetToDictionary;

            //------------Paddle 1 - Texture Contents---------------------//
            accessDictionary["paddle1"].Texture = Content.Load<Texture2D>("paddle");

            //------------Paddle 2 - Texture Contents---------------------//
            accessDictionary["paddle2"].Texture = Content.Load<Texture2D>("paddle");

            //------------Ball 1 - Texture Contents---------------------//
            accessDictionary["ball1"].Texture = Content.Load<Texture2D>("square");

            sceneManager.SetToDictionary = accessDictionary;
        }

        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Updates the Managers
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //------------Call to Update Scene Manager-----------------//
            sceneManager.Update(gameTime);

            //------------Call to Update To Collision Manager---------//           
            collisionManager.Update(gameTime);

            //--------- --Call to Update To Input Manager-------------//
            inputManager.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// Calls Draw in SceneManager
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //----------------------Call to Draw All Entites----------------------//

            spriteBatch.Begin();

            sceneManager.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}