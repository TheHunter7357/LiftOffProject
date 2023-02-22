using System;
using GXPEngine.Core;
using GXPEngine.Managers;
using System.Collections.Generic;

namespace GXPEngine
{
	/// <summary>
	/// The Game class represents the Game window.
	/// Only a single instance of this class is allowed.
	/// </summary>
	public class Game : GameObject
	{
		internal static Game main = null;

		private GLContext _glContext;

        protected List<Level> levels = new List<Level>();

        protected int currentLevelIndex;

        public Level gameLevel { get; private set; }

		protected CharSelect charSelect;

        protected StartLevel startLevel;

		protected EndScreen endScreen;

        private UpdateManager _updateManager;
		private CollisionManager _collisionManager;
		public PhysicsManager _physicsManager { get; private set; }

		ArduinoInput arduinoInput;

		public List<CharacterBase> players = new List<CharacterBase>();

		public CharacterBase player1 { get; private set; }
		public CharacterBase player2 { get; private set; }
		
		public Config config { get; protected set; }
		
		public Level currentLevel { get; protected set; }

		public SoundChannel backgroundMusic { get; protected set; }

		public SoundChannel SFX;

		public float musicVolume { get; protected set; }
		public float SFXVolume { get; protected set; }

		/// <summary>
		/// Step delegate defines the signature of a method used for step callbacks, see OnBeforeStep, OnAfterStep.
		/// </summary>
		public delegate void StepDelegate ();
		/// <summary>
		/// Occurs before the engine starts the new update loop. This allows you to define general manager classes that can update itself on/after each frame.
		/// </summary>
		public event StepDelegate OnBeforeStep;
		/// <summary>
		/// Occurs after the engine has finished its last update loop. This allows you to define general manager classes that can update itself on/after each frame.
		/// </summary>
		public event StepDelegate OnAfterStep;

		public delegate void RenderDelegate (GLContext glContext);
		public event RenderDelegate OnAfterRender;

		/// <summary>
		/// Sprites will be rendered if and only if they overlap with this rectangle. 
		/// Default value: (0,0,game.width,game.height). 
		/// You only need to change this when rendering to subwindows (e.g. split screen).
		/// </summary>
		/// <value>The render range.</value>
		public Rectangle RenderRange {
			get {
				return _renderRange;
			}
			set {
				_renderRange = value;
			}
		}

		/// <summary>
		/// Set this to false if you *only* want to render using your own cameras.
		/// (Don't say we didn't warn you if you end up with a black screen...)
		/// </summary>
		public bool RenderMain = true;
		public readonly bool PixelArt;

		private Rectangle _renderRange;
		
		//------------------------------------------------------------------------------------------------------------------------
		//														Game()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="GXPEngine.Game"/> class.
		/// This class represents a game window, containing an openGL view.
		/// </summary>
		/// <param name='width'>
		/// Width of the window in pixels. (As used by all the logic, e.g. the coordinate system)
		/// </param>
		/// <param name='height'>
		/// Height of the window in pixels. (As used by all the logic, e.g. the coordinate system)
		/// </param>
		/// <param name='fullScreen'>
		/// If set to <c>true</c> the application will run in fullscreen mode.
		/// </param>
		/// <param name='vSync'>
		/// If <c>true</c>, the frame rate will sync to the screen refresh rate, so setting targetFps has no effect. 
		/// (It's best to give this the same value as the 'fullScreen' parameter.)
		/// </param>
		/// <param name='realWidth'>
		/// The actual window width. By default (if passing a negative value), this is equal to the 'width' parameter, but using
		/// this parameter you can easily change the window width without having to change any other code.
		/// </param>
		/// <param name='realHeight'>
		/// The actual window height. By default (if passing a negative value), this is equal to the 'height' parameter, but using
		/// this parameter you can easily change the window height without having to change any other code.
		/// </param>
		/// <param name='pixelArt'>
		/// If <c>true</c>, textures will not be interpolated ('blurred'). This way, you can get a typical pixel art look.
		/// </param>
		public Game (int pWidth, int pHeight, bool pFullScreen, bool pVSync = true, int pRealWidth=-1, int pRealHeight=-1, bool pPixelArt=false) : base()
		{
			backgroundMusic = new Sound("BackGroundMusic.wav", true, false).Play();
			if (pRealWidth <= 0) {
				pRealWidth = pWidth;
			}
			if (pRealHeight <= 0) {
				pRealHeight = pHeight;
			}
			PixelArt = pPixelArt;

			if (PixelArt) {
				// offset should be smaller than 1/(2 * "pixelsize"), but not zero:
				x = 0.01f;
				y = 0.01f;
			}
			
			if (main != null) {
				throw new Exception ("Only a single instance of Game is allowed");
			} else {

				main = this;
				_updateManager = new UpdateManager ();
				_collisionManager = new CollisionManager ();
				_physicsManager = new PhysicsManager();
				arduinoInput = new ArduinoInput();
				_glContext = new GLContext (this);
				_glContext.CreateWindow (pWidth, pHeight, pFullScreen, pVSync, pRealWidth, pRealHeight);

				_renderRange = new Rectangle (0, 0, pWidth, pHeight);

				//register ourselves for updates
				Add (this);

			}
		}

        public void LoadNextLevel()
        {
            Level levelToLoad = levels[currentLevelIndex + 1];

            AddChild(levelToLoad);
            RemoveChild(currentLevel);
            currentLevel = levelToLoad;
            currentLevelIndex++;
        }

		public void LoadGameLevel(Enums.characters player1, Enums.characters player2)
		{
			CharacterBase cha1;
			CharacterBase cha2;

			Random rand = new Random ();
			int selectedLevel = rand.Next(0, 3);

			switch (selectedLevel)
			{
				case 0:
					gameLevel = new Level("Background1_Anim.png", 4, 4, 14);
					gameLevel.match = 0;
					break;
				case 1:
					gameLevel = new Level("Background2_Anim.png", 6, 5, 26);
                    gameLevel.match = 1;
                    break;
				default:
                    gameLevel = new Level("Dungeon_Background.png", 3, 2, 5);
                    gameLevel.match = 2;
                    break;
            }

			levels.Add(gameLevel);

            AddChild(gameLevel);
            RemoveChild(currentLevel);
            currentLevel = gameLevel;

            switch (player1)
            {
                case Enums.characters.fireGirl:
                    cha1 = new FireGirl(Enums.players.player1, false);
                    break;
                case Enums.characters.fatGuy:
                    cha1 = new FatGuy(Enums.players.player1, false);
                    break;
                case Enums.characters.rootsGuy:
                    cha1 = new RootsGuy(Enums.players.player1, false);
                    break;
                default:
                    cha1 = new FireGirl(Enums.players.player1, false);
                    break;
            }

            switch (player2)
            {
                case Enums.characters.fireGirl:
                    cha2 = new FireGirl(Enums.players.player2, false);
                    break;
                case Enums.characters.fatGuy:
                    cha2 = new FatGuy(Enums.players.player2, false);
                    break;
                case Enums.characters.rootsGuy:
                    cha2 = new RootsGuy(Enums.players.player2, false);
                    break;
                default:
                    cha2 = new FireGirl(Enums.players.player2, false);
                    break;
            }


            cha2.SetXY(400, cha2.y);

            this.player1 = cha1;

            this.player2 = cha2;

            players.Add(cha1);
            players.Add(cha2);

            gameLevel.AddChild(new HealthBarOverlay(Enums.players.player1));
            gameLevel.AddChild(new HealthBarOverlay(Enums.players.player2));

            gameLevel.AddChild(new HealthBar(Enums.players.player2));
            gameLevel.AddChild(new HealthBar(Enums.players.player1));

            gameLevel.AddChild(new ManaBar(Enums.players.player1));
            gameLevel.AddChild(new ManaBar(Enums.players.player2));

            gameLevel.AddChild(cha1);
            gameLevel.AddChild(cha2);
            currentLevelIndex++;

            endScreen = new EndScreen();
            levels.Add(endScreen);
        }

		public void LoadBeginLevel()
		{
            Level levelToLoad = levels[0];

            AddChild(levelToLoad);
            RemoveChild(currentLevel);
            currentLevel = levelToLoad;
            currentLevelIndex = 0;
        }

		public void ReloadLevel()
		{
            Level levelToLoad = levels[currentLevelIndex - 1];

            AddChild(levelToLoad);
            RemoveChild(currentLevel);
            currentLevel = levelToLoad;
			currentLevelIndex --;

			player1.Reset();
			player2.Reset();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //														SetViewPort()
        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sets the rendering output view port. All rendering will be done within the given rectangle.
        /// The default setting is {0, 0, game.width, game.height}.
        /// </summary>
        /// <param name='x'>
        /// The x coordinate.
        /// </param>
        /// <param name='y'>
        /// The y coordinate.
        /// </param>
        /// <param name='width'>
        /// The new width of the viewport.
        /// </param>
        /// <param name='height'>
        /// The new height of the viewport.
        /// </param>
        public void SetViewport(int x, int y, int width, int height, bool setRenderRange=true) {
			// Translate from GXPEngine coordinates (origin top left) to OpenGL coordinates (origin bottom left):
			//Console.WriteLine ("Setting viewport to {0},{1},{2},{3}",x,y,width,height);
			_glContext.SetScissor(x, game.height - height - y, width, height);
			if (setRenderRange) {
				_renderRange = new Rectangle(x, y, width, height);
			}
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														ShowMouse()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Shows or hides the mouse cursor.
		/// </summary>
		/// <param name='enable'>
		/// Set this to 'true' to enable the cursor.
		/// Else, set this to 'false'.
		/// </param>
		public void ShowMouse (bool enable)
		{
			_glContext.ShowCursor(enable);
		}
		
		//------------------------------------------------------------------------------------------------------------------------
		//														Start()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Start the game loop. Call this once at the start of your game.
		/// </summary>
		public void Start() {
			_glContext.Run();
		}
		
		//------------------------------------------------------------------------------------------------------------------------
		//														Step()
		//------------------------------------------------------------------------------------------------------------------------
		internal void Step ()
		{
			if (OnBeforeStep != null)
				OnBeforeStep ();
			_updateManager.Step ();
			_collisionManager.Step ();
			_physicsManager.Step();
			if (OnAfterStep != null)
				OnAfterStep ();
		}

		bool recurse=true;

		public override void Render(GLContext glContext) {
			if (RenderMain || !recurse) {
				base.Render (glContext);
			}
			if (OnAfterRender != null && recurse) {
				recurse = false;
				OnAfterRender (glContext);
				recurse = true;
			}
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														RenderSelf()
		//------------------------------------------------------------------------------------------------------------------------
		override protected void RenderSelf(GLContext glContext) {
			//empty
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														Add()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Should only be called from the GameObject class!
		/// </summary>
		internal void Add (GameObject gameObject)
		{
			_updateManager.Add (gameObject);
			_collisionManager.Add (gameObject);
		}
		
		//------------------------------------------------------------------------------------------------------------------------
		//														Remove()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Should only be called from the GameObject class!
		/// </summary>
		internal void Remove (GameObject gameObject)
		{
			_updateManager.Remove (gameObject);
			_collisionManager.Remove (gameObject);
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														GetGameObjectCollisions()
		//------------------------------------------------------------------------------------------------------------------------
		internal GameObject[] GetGameObjectCollisions (GameObject gameObject, bool includeTriggers = true, bool includeSolid = true)
		{
			return _collisionManager.GetCurrentCollisions(gameObject, includeTriggers, includeSolid);
		}


		//------------------------------------------------------------------------------------------------------------------------
		//														width
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns the width of the window.
		/// </summary>
		public int width {
			get { return _glContext.width; }
		}
		
		//------------------------------------------------------------------------------------------------------------------------
		//														height
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns the height of the window.
		/// </summary>
		public int height {
			get { return _glContext.height; }
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														Destroy()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Destroys the game, and closes the game window.
		/// </summary>
		override public void Destroy ()
		{
			base.Destroy();
			_glContext.Close();
		}

		public int currentFps {
			get {
				return _glContext.currentFps;
			}
		}

		public int targetFps {
			get { 
				return _glContext.targetFps; 
			}
			set {
				_glContext.targetFps = value;
			}
		}

		public void SetVSync(bool enableVSync) {
			_glContext.SetVSync(enableVSync);
		}

		int CountSubtreeSize(GameObject subtreeRoot) {
			int counter=1; // for the root
			foreach (GameObject child in subtreeRoot.GetChildren()) {
				counter += CountSubtreeSize (child);
			}
			return counter;
		}

		/// <summary>
		/// Returns a string with some internal engine information. Use this for debugging, especially when the game slows down.
		/// </summary>
		/// <returns>Internal engine information.</returns>
		public string GetDiagnostics() {
			string output = "";
			output += "Number of objects in hierarchy: " + CountSubtreeSize (this)+'\n';
			output += "OnBeforeStep delegates: "+(OnBeforeStep==null?0:OnBeforeStep.GetInvocationList().Length)+'\n';
			output += "OnAfterStep delegates: "+(OnAfterStep==null?0:OnAfterStep.GetInvocationList().Length)+'\n';
			output += "OnAfterRender delegates: "+(OnAfterRender==null?0:OnAfterRender.GetInvocationList().Length)+'\n';
			output += Texture2D.GetDiagnostics ();
			output += _collisionManager.GetDiagnostics (); 
			output += _updateManager.GetDiagnostics (); 
			return output;
		}
	}
}

