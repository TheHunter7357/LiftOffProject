using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions

public class MyGame : Game {

    #region properties

    #endregion

    public MyGame() : base(1920, 1080, true)     // Create a window that's 800x600 and NOT fullscreen
	{
		CharacterBase cha = new CharacterBase("checkers.png", 1, 1, Enums.players.player1);
		players.Add(cha);
		AddChild(cha);
        CharacterBase cha2 = new CharacterBase("checkers.png", 1, 1, Enums.players.player2);
		cha2.SetXY(100, 0);
		players.Add(cha2);
        AddChild(cha2);

		Level level = new Level("transparant.png");

        AddChild(level);
		currentLevel = level;
    }

	// For every game object, Update is called every frame, by the engine:
	void Update() {
		// Empty
	}

	static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}