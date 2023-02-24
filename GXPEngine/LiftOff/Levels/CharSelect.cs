using System;
using GXPEngine.Core;

namespace GXPEngine
{
    public class CharSelect : Level
    {
        Enums.characters player1;

        bool player1Selected = false;

        Enums.characters player2;

        bool player2Selected = false;

        bool player1Changed;
        bool player2Changed;

        EasyDraw p1Select;
        EasyDraw p2Select;

        public CharSelect(string filename, int cols, int rows, int numOfFrames) : base(filename, cols, rows, numOfFrames)
        {
            p1Select = new EasyDraw(1366, 768, false);
            p2Select = new EasyDraw(1366, 768, false);

            p1Select.Stroke(255, 0, 0, 255);
            p1Select.StrokeWeight(10);
            p1Select.NoFill();
            p1Select.ShapeAlign(CenterMode.Min, CenterMode.Min);
            p1Select.Rect(217, 207, 245, 345);
            //217

            p2Select.Stroke(0, 0, 255, 255);
            p2Select.StrokeWeight(10);
            p2Select.NoFill();
            p2Select.ShapeAlign(CenterMode.Min, CenterMode.Min);
            p2Select.Rect(207, 197, 265, 365);

            AddChild(p1Select);
            AddChild(p2Select);
        }

        void Update()
        {
            if (player1Selected && player2Selected)
            {
                game.LoadGameLevel(player1, player2);
            }

            if (ArduinoInput.GetAxisHorizontal(Enums.players.player1) == 1 || Input.GetKey(Key.D))
            {
                if (!player1Changed && !player1Selected)
                {
                    switch (player1)
                    {
                        case Enums.characters.fireGirl:
                            player1 = Enums.characters.rootsGuy;
                            p1Select.ClearTransparent();
                            p1Select.Rect(560, 207, 245, 345);

                            break;

                        case Enums.characters.fatGuy:
                            player1 = Enums.characters.fireGirl;
                            p1Select.ClearTransparent();
                            p1Select.Rect(217, 207, 245, 345);
                            break;

                        case Enums.characters.rootsGuy:
                            player1 = Enums.characters.fatGuy;
                            p1Select.ClearTransparent();
                            p1Select.Rect(900, 207, 245, 345);
                            break;
                    }
                    player1Changed = true;
                }


            }

            if (ArduinoInput.GetAxisHorizontal(Enums.players.player1) == -1 || Input.GetKey(Key.A))
            {
                if (!player1Changed && !player1Selected)
                {
                    switch (player1)
                    {
                        case Enums.characters.fireGirl:
                            player1 = Enums.characters.fatGuy;
                            p1Select.ClearTransparent();
                            p1Select.Rect(900, 207, 245, 345);
                            break;

                        case Enums.characters.fatGuy:
                            player1 = Enums.characters.rootsGuy;
                            p1Select.ClearTransparent();
                            p1Select.Rect(560, 207, 245, 345);
                            break;

                        case Enums.characters.rootsGuy:
                            player1 = Enums.characters.fireGirl;
                            p1Select.ClearTransparent();
                            p1Select.Rect(217, 207, 245, 345);
                            break;
                    }
                    player1Changed = true;
                }


            }

            if (ArduinoInput.GetAxisHorizontal(Enums.players.player2) == -1 || Input.GetKey(Key.LEFT))
            {
                if (!player2Changed && !player2Selected)
                {
                    switch (player2)
                    {
                        case Enums.characters.fireGirl:
                            player2 = Enums.characters.fatGuy;
                            p2Select.ClearTransparent();
                            p2Select.Rect(890, 197, 265, 365);
                            break;

                        case Enums.characters.fatGuy:
                            player2 = Enums.characters.rootsGuy;
                            p2Select.ClearTransparent();
                            p2Select.Rect(550, 197, 265, 365);
                            break;

                        case Enums.characters.rootsGuy:
                            player2 = Enums.characters.fireGirl;
                            p2Select.ClearTransparent();
                            p2Select.Rect(207, 197, 265, 365);
                            break;
                    }
                    player2Changed = true;
                }


            }

            if (ArduinoInput.GetAxisHorizontal(Enums.players.player2) == 1 || Input.GetKey(Key.RIGHT))
            {
                if (!player2Changed && !player2Selected)
                {
                    switch (player2)
                    {
                        case Enums.characters.fireGirl:
                            player2 = Enums.characters.rootsGuy;
                            p2Select.ClearTransparent();
                            p2Select.Rect(550, 197, 265, 365);
                            break;

                        case Enums.characters.fatGuy:
                            player2 = Enums.characters.fireGirl;
                            p2Select.ClearTransparent();
                            p2Select.Rect(207, 197, 265, 365);
                            break;

                        case Enums.characters.rootsGuy:
                            player2 = Enums.characters.fatGuy;
                            p2Select.ClearTransparent();
                            p2Select.Rect(890, 197, 265, 365);
                            break;
                    }

                    player2Changed = true;
                }

            }

            if (/*ArduinoInput.GetAxisHorizontal(Enums.players.player1) == 0 ||*/ Input.GetKeyUp(Key.A) || Input.GetKeyUp(Key.D))
            {
                player1Changed = false;
            }
            if (/*ArduinoInput.GetAxisHorizontal(Enums.players.player2) == 0 ||*/ Input.GetKeyUp(Key.LEFT) || Input.GetKeyUp(Key.RIGHT))
            {
                player2Changed = false;
            }

            if (/*ArduinoInput.GetButtonDown("B1", Enums.players.player1) ||*/ Input.GetKeyDown(Key.ENTER))
            {
                player1Selected = !player1Selected;
            }

            if (Input.GetKeyDown(Key.ENTER))
            {
                player2Selected = !player2Selected;
            }
        }
    }
}
