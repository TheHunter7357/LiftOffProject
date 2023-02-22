using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.IO.Ports;
using System.Collections.Generic;

public class MyGame : Game {

	#region properties

    #endregion

    public MyGame() : base(1366, 768, false)     // Create a window that's 800x600 and NOT fullscreen
	{
		config = ConfigParser.ReadConfig("Config.xml");

		startLevel = new StartLevel("Title_screen.png", 5, 4, 19);
		AddChild(startLevel);
		currentLevel= startLevel;
		levels.Add(startLevel);

		charSelect = new CharSelect("Charachter_Screen.png", 5, 4, 19);
		levels.Add(charSelect);
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