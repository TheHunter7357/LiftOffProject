using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class HealthBarOverlay : Sprite
    {
        public HealthBarOverlay(Enums.players player) : base("GUIFrame.png", false, false)
        {
            switch(player)
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
        }
    }
}
