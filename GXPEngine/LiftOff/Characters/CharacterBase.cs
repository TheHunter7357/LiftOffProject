using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class CharacterBase : Sprite
    {
        #region properties

        Enums.players player;
        int speed = 3;
        int jumpForce = 5;
        float health;

        float gravity = 0.09f;
        bool Grounded;


        bool jumpedThisFrame;

        bool isAttacking;

        float jumpTimer;
        float jumpedTime = 1;

        // For moves dependant on key pressed, use ENUM

        float moveX;
        float velocityY;

        AttackCollider lightAttackCol;

        AnimationSprite GFX;

        #endregion

        public CharacterBase(string filename, int cols, int rows, Enums.players player) : base("transparant.png") 
        {
            this.player = player;
            lightAttackCol = new AttackCollider(width, height / 2, 0.5f, 0.5f);
            AddChild(lightAttackCol);

            AddChild(new GroundedCollider(this));

            GFX = new AnimationSprite(filename, cols, rows);
            AddChild(GFX);
            GFX.SetOrigin(GFX.width / 2, 0);
            GFX.SetXY(width/2, y);
            GFX.SetFrame(0);
            GFX.SetCycle(0, 1, 5);

            GFX.Mirror(player == Enums.players.player1 ? false : true, false);
        }

        public void Update()
        {
            AttackInputs();
            Playermove();
            GFX.AnimateFixed();
            if (!Grounded)
            { MoveDown(); }
            Grounded = false;
            jumpedThisFrame = false;
            jumpTimer -= Time.deltaTime;
            Console.WriteLine(moveX);

        }

        void AttackInputs()
        {
            if(Input.GetKeyDown(player == Enums.players.player1 ? Key.G : Key.M))
            {
                _ = Attack();
            }
        }

        void Playermove() // controls of the player
        {
            if (player == Enums.players.player1 ? Input.GetKeyDown(Key.D) : Input.GetKeyDown(Key.RIGHT))
            {
                moveX += 1;
            }
            if (player == Enums.players.player1 ? Input.GetKeyDown(Key.A) : Input.GetKeyDown(Key.LEFT))
            {
                moveX -= 1;
            }
            if (player == Enums.players.player1 ? Input.GetKeyUp(Key.D) : Input.GetKeyUp(Key.RIGHT))
            {
                moveX -= 1;
            }
            if (player == Enums.players.player1 ? Input.GetKeyUp(Key.A) : Input.GetKeyUp(Key.LEFT))
            {
                moveX += 1;
            }
            if (player == Enums.players.player1 ? Input.GetKeyDown(Key.W) : Input.GetKeyDown(Key.UP))
            {
                if (!Grounded)
                    return;
                velocityY = -jumpForce;
                y -= jumpForce;
                jumpedThisFrame = true;
                jumpTimer = jumpedTime;
            }
            if(!isAttacking)
                MoveUntilCollision(moveX * speed, 0, game.players);
            
        }
        void MoveDown()
        {
            // This is the gravity of the player wich increases over time and has a maximum increase

            if (velocityY < 5 && !jumpedThisFrame)
            {
                velocityY += gravity;
            }
            y += velocityY;
        }

        public void GroundCollision(GameObject collider)
        {
            if (velocityY >= 0 && !jumpedThisFrame && jumpTimer <= 0)
            {
                if (velocityY > 0)
                {
                    y = collider.y - height;
                }
                Grounded = true;
                velocityY = 0;
            }
        }

        //TODO: light attack, light down attack, block, heavy attack, special attack

        async Task Attack()
        {
            if (isAttacking)
                return;
            isAttacking = true;
            GFX.SetCycle(0, 3, 20);
            await Task.Delay(1000);

            GFX.SetCycle(0, 1, 5);
            isAttacking = false;
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
        }
    }
}
