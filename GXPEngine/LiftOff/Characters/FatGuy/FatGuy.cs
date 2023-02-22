using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class FatGuy : CharacterBase
    {
        AfterImage[] afterImages = new AfterImage[50];

        bool isCharging = false;

        float storedDamage;

        AttackCollider ultCol;

        public FatGuy(Enums.players player, bool controller) : base("Fatguy.png", 10, 6, player, controller)
        {
            isEmpowered = game.currentLevel.match == 2 ? true : false;

            groundLevel = 350;
            ultCol = new AttackCollider(width, x, y, 100, height, player, false);
            attackColliders.Add(ultCol);
            AddChild(ultCol);

            for(int i = 0; i < 50; i++)
            {
                afterImages[i] = new AfterImage(GFX);
                game.gameLevel.AddChildAt(afterImages[i], 0);
                Console.WriteLine("Added " + i);
            }
            afterImages = afterImages.Reverse().ToArray();

            Console.WriteLine(game.gameLevel.GetChildCount());
        }

        new void OnCollision(GameObject collider)
        {
            base.OnCollision(collider);
        }

        new void Update()
        {
            base.Update();
        }

        public override async Task Ultimate()
        {
            isCharging = true;
            for (int i = 0; i < 50; i++)
            {
                afterImages[i].Next();


                await Task.Delay(100);
            }



            isCharging = false;

            isUlting = true;

            GFX.SetCycle(53, 7, 8);
            Console.WriteLine("Charged");

            for(int i = 0; i < 10;i++)
            {
                xVelocity = isFlipped ? -3 : 3;
                if (ultCol.CheckHit(this, (game.config.characterStats.fatStats.flatDamage + storedDamage) * (float)(isEmpowered ? 1.1 : 1), 3))
                {
                    break;
                }
                await Task.Delay(50);
            }


            isUlting = false;
        }

        public override async Task TakeHit(float amount, bool left, float knockBack)
        {
            if (!isCharging)
            {
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
            else
            {
                amount = amount * game.config.characterStats.fatStats.damageResistance;
                health -= amount;

                storedDamage += amount;
            }



            if (health <= 0)
            {
                game.LoadNextLevel();
                Console.WriteLine("End");
                return;
            }



        }

    }
}
