using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Laser : AnimationSprite
    {
        public Laser() : base("Laser.png", 5, 1)
        {
            Mirror(true, false);
            visible = false;
        }

        public async Task Anim()
        {
            visible= true;
            SetCycle(0, 1, 10);
            await Task.Delay(400);
            SetCycle(1, 4, 10);
            FireGirl owner = (FireGirl)parent;
            for(int i = 0; i < game.config.characterStats.fireStats.laserTicks; i++)
            {
                owner.ultCol.CheckHit(owner, game.config.characterStats.fireStats.laserTickDamage * (float)(owner.isEmpowered ? 1.1 : 1), 1);
                await Task.Delay(550/game.config.characterStats.fireStats.laserTicks);
            }
            visible = false;
        }

        void Update()
        {
            AnimateFixed();
        }
    }
}
