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
        float yPos;
        float xScale;
        float yScale;
        bool blockable;

        public AttackCollider(float normalx, float flippedx, float y, float width, float height, Enums.players player, bool blockable, bool debug = false) : base(debug ? "greenDot.png" : "transDot.png")
        {
            this.normalx = normalx;
            this.flippedx = flippedx;
            this.yPos = y;
            this.xScale = width;
            this.yScale = height;
            this.blockable = blockable;
            SetOrigin(player == Enums.players.player1 ? 0 : width, 0);
            SetXY(normalx, yPos);
            SetScaleXY(width, height);

        }

        public bool CheckHit(CharacterBase owner, float damage, float knockBack)
        {
            foreach (CharacterBase cha in game.players)
            {
                if (cha != owner)
                {
                    if (HitTest(cha))
                    {
                        if (cha.isBlocking)
                        {
                            cha.TakeHit(blockable ? damage * 0.3f : damage, parent.x > cha.x, knockBack);
                        }
                        else
                        {
                            cha.TakeHit(damage, parent.x > cha.x, knockBack);
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        public void Flip(bool flip)
        {
            if (flip)
            {
                SetOrigin(0, 0);
                SetXY(normalx, y);

            }
            else
            {
                SetOrigin(width / xScale, 0);
                SetXY(flippedx, y);
            }
        }
    }
}
