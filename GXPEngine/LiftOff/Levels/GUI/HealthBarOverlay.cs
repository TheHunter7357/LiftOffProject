using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class HealthBarOverlay : Sprite
    {
        AnimationSprite char1;
        AnimationSprite char2;

        public HealthBarOverlay(Enums.players player) : base("GUIFrame.png", false, false)
        {
            char1 = new AnimationSprite("Icons_of_characters.png", 3, 1);
            char1.SetXY(-5, -5);
            char2 = new AnimationSprite("Icons_of_characters.png", 3, 1);
            char2.SetXY(-180, -5);
            AddChild(player == Enums.players.player1 ? char1 : char2);
            switch (player)
            {
                case Enums.players.player1:
                    SetXY(0,0); 
                    break;
                case Enums.players.player2:
                    Mirror(true, false);
                    SetOrigin(width, 0);
                    SetXY(game.width, 0);
                    break;
                
            }

            if(game.player1 is FireGirl)
            {
                char1.currentFrame = 0;
            }
            else if(game.player1 is FatGuy)
            {
                char1.currentFrame = 1;
            }
            else if(game.player1 is RootsGuy)
            {
                char1.currentFrame = 2;
            }

            if (game.player2 is FireGirl)
            {
                char2.currentFrame = 0;
            }
            else if (game.player2 is FatGuy)
            {
                char2.currentFrame = 1;
            }
            else if (game.player2 is RootsGuy)
            {
                char2.currentFrame = 2;
            }
        }
    }
}
