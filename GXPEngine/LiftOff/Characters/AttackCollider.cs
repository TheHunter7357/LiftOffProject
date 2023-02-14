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
        public AttackCollider(int x, int y, float width, float height) : base("square.png")
        {
            SetOrigin(0, y - height/2);
            SetXY(x, y - height/2);
            SetScaleXY(width, height);
        }

        public void CheckHit(CharacterBase owner)
        {
            foreach(CharacterBase cha in game.players)
            {
                if(cha != owner)
                {
                    if (HitTest(cha))
                    {
                        
                    }
                }
            }
        }
    }
}
