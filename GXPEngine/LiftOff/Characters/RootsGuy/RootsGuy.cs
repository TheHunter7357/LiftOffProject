using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class RootsGuy : CharacterBase
    {

        Roots roots;
        public RootsGuy(Enums.players player, bool controller) : base("Treeman.png", 10, 6, player, controller)
        {
            isEmpowered = game.currentLevel.match == 1 ? true : false;
        }

        void OnCollision(GameObject collider)
        {
            base.OnCollision(collider);
        }

        void Update()
        {
            base.Update();
        }

        public override async Task Ultimate()
        {
            isUlting = true;
            GFX.SetCycle(53, 7, 8);
            if (roots == null)
            {
                roots = new Roots(this);
                game.currentLevel.AddChild(roots);
            }


            await Task.Delay(666);

            roots.Init();

            await Task.Delay(484);

            isUlting = false;
        }

        public virtual async Task TakeHit(float amount, bool left, float knockBack)
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
