using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class AttackCollider : Sprite
    {
        float flippedx;
        float normalx;
        float y;
        float width;
        float height;
        public AttackCollider(float normalx, float flippedx, float y, float width, float height, Enums.players player) : base("square.png")
        {
            SetOrigin(player == Enums.players.player1 ? 0 : width, y - height / 2);
            SetXY(normalx, y - height / 2);
            SetScaleXY(width, height);
            this.normalx = normalx;
            this.flippedx = flippedx;
            this.y = y; 
            this.width = width; 
            this.height = height;
        }

        public void CheckHit(CharacterBase owner, float damage)
        {
            foreach (CharacterBase cha in game.players)
            {
                if (cha != owner)
                {
                    if (HitTest(cha))
                    {
                        cha.TakeDamage(damage);
                    }
                }
            }
        }

        public void Flip(bool flip)
        {
            if (flip)
            {
                SetOrigin(0, y - height / 2);
                SetXY(normalx, y - height / 2);

            }
            else
            {
                SetOrigin(width, y - height / 2);
                SetXY(flippedx, y - height / 2);
            }
        }
    }
}
