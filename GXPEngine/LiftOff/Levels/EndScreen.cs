using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class EndScreen : Level
    {
        EasyDraw RematchButton;

        EasyDraw BackButton;

        EasyDraw selectedButton;

        bool changedButtons;

        public EndScreen() : base("Win_Lose_screen.png", 2, 1, 1)
        {
            RematchButton = new EasyDraw(260, 97);
            RematchButton.SetXY(width / 2 - 140, height / 2 - 50);
            RematchButton.Clear(255, 255, 255, alpha: 55);
            AddChild(RematchButton);

            BackButton = new EasyDraw(260, 97);
            BackButton.SetXY(width / 2 - 140, height / 2 + 90);
            BackButton.Clear(255, 255, 255, alpha: 100);
            AddChild(BackButton);
            selectedButton = RematchButton;
        }

        void Update()
        {
            if(game.player1.health > 0)
            {
                currentFrame = 0;
            }
            else
            {
                currentFrame = 1;
            }

            if (ArduinoInput.GetAxisVertical(Enums.players.player1) == 1 || ArduinoInput.GetAxisVertical(Enums.players.player1) == -1 || Input.GetKey(Key.UP) || Input.GetKey(Key.DOWN))
            {
                if (changedButtons)
                {
                    return;
                }
                if (selectedButton == RematchButton)
                {
                    selectedButton = BackButton;
                }
                else
                {
                    selectedButton = RematchButton;
                }
                changedButtons = true;
            }

            if (BackButton == selectedButton)
            {
                BackButton.alpha = 100;
                RematchButton.alpha = 0;
            }
            else
            {
                BackButton.alpha = 0;
                RematchButton.alpha = 100;
            }

            if (Input.GetKeyUp(Key.UP) || Input.GetKeyUp(Key.DOWN))
            {
                changedButtons = false;
            }
            //if (ArduinoInput.GetAxisVertical(Enums.players.player1) == 0)
            //{
            //    changedButtons = false;
            //}

            if (Input.GetKeyDown(Key.ENTER))
            {
                if (selectedButton == BackButton)
                {
                    game.LoadBeginLevel();
                }
                else
                {
                    game.ReloadLevel();
                }
            }


            base.Update();
            currentFrame = 0;

        }
    }
}
