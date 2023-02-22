using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class HealthBar : Sprite
    {
        Enums.players player;

        float maxHealth;

        float currentHealth;

        float healthPercentage;

        public HealthBar(Enums.players playerchar) : base("HealthBar.png", false, false)
        {
            player = playerchar;
            maxHealth = game.player2.health;
            currentHealth = game.player2.health;
            healthPercentage = 100;

            switch (playerchar)
            {
                case Enums.players.player1:
                    SetOrigin(0, 0);
                    SetXY(150, 32);
                    break;
                case Enums.players.player2:
                    SetOrigin(width, 0);
                    SetXY(game.width - 150, 32);
                    break;
            }
        }

        void Update()
        {
            switch (player)
            {
                case Enums.players.player1:
                    healthPercentage = game.player1.health / maxHealth;
                    break;
                case Enums.players.player2:
                    healthPercentage = game.player2.health / maxHealth;
                    break;
            }

            scaleX = healthPercentage;
        }
    }
}
