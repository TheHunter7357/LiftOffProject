using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class ManaBar : Sprite
    {
        Enums.players player;

        float maxMana;

        float currentMana;

        float manaPercentage;

        public ManaBar(Enums.players playerchar) : base("manaBar.png", false, false)
        {
            player = playerchar;
            maxMana = game.player1.requiredUltCharge;
            currentMana = game.player1.ultCharge;
            manaPercentage = 100;

            switch (playerchar)
            {
                case Enums.players.player1:
                    SetOrigin(0, 0);
                    SetXY(161, 49);
                    break;
                case Enums.players.player2:
                    Mirror(true, false);
                    SetOrigin(width, 0);
                    SetXY(game.width - 161, 49);
                    break;
            }
        }

        void Update()
        {
            switch (player)
            {
                case Enums.players.player1:
                    manaPercentage = game.player1.ultCharge / maxMana;
                    break;
                case Enums.players.player2:
                    manaPercentage = game.player2.ultCharge / maxMana;
                    break;
            }

            scaleX = manaPercentage;
        }
    }
}
