using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class FireGirl : CharacterBase
    {
        public AttackCollider ultCol { get; private set; }

        Laser laser;

        public FireGirl(Enums.players player, bool controller) : base("First_char_anim.png", 10, 6, player, controller)
        {
            isEmpowered = game.currentLevel.match == 0 ? true : false;

            laser = new Laser();
            laser.SetOrigin(0, height / 2);
            laser.SetXY(x, height/2);
            AddChild(laser);
            ultCol = new AttackCollider(width, x, y +height/2 -10, 1300, 10, player, false);
            attackColliders.Add(ultCol);
            AddChild(ultCol);
            
        }

        void Update()
        {
            base.Update();
        }

        public override async Task Ultimate()
        {
            if (isFlipped)
            {
                laser.Mirror(false, false);
                laser.SetOrigin(laser.width, height/2);
                laser.SetXY(width, height / 2);
            }
            else
            {
                laser.Mirror(true, false);
                laser.SetOrigin(0, height / 2);
                laser.SetXY(0, height / 2);
            }
            isUlting = true;
            laser.Anim();
            GFX.SetCycle(53, 7, 8);
            await Task.Delay(1150);
            isUlting = false;
        }

        void OnCollision(GameObject collider)
        {
            base.OnCollision(collider);
        }

        public override async Task TakeHit(float amount, bool left, float knockBack)
        {
            //TODO: knockback after certain amount of hits

            GetHit.Play();

            health -= amount;

            if (health <= 0)
            {
                game.LoadNextLevel();
                Console.WriteLine("End");
                return;
            }


            isStunned = true;

            xVelocity = left ? -knockBack : knockBack;

            GFX.SetCycle(10, 3, 7);

            isAttacking = false;

            await Task.Delay(500);

            GFX.SetCycle(0, 5, 10);

            isStunned = false;
        }
    }
}
