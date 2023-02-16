using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.IO.Ports;

public class MyGame : Game {

	#region properties

    #endregion

    public MyGame() : base(1366, 768, false)     // Create a window that's 800x600 and NOT fullscreen
	{
        Level level = new Level("Background1_Anim.png", 4, 4);
        AddChild(level);
        currentLevel = level;
        //config = ConfigParser.ReadConfig("Config.xml");
        CharacterBase cha = new CharacterBase("First_test_anim.png", 6, 3, Enums.players.player1);
		players.Add(cha);
		AddChild(cha);
        CharacterBase cha2 = new CharacterBase("First_test_anim.png", 6, 3, Enums.players.player2);
		cha2.SetXY(1000, 0);
		players.Add(cha2);
        AddChild(cha2);


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