using GXPEngine.Core;
using GXPEngine.LiftOff.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GXPEngine
{
    public class CharacterBase : Sprite
    {
        #region properties

        float groundLevel = 400;

        Enums.players player;
        int speed = 3;
        int jumpForce = 30;
        float health = 100;

        float gravity = 0.7f;
        public bool Grounded;

        float airFriction = .03f;
        float groundFriction = 0.2f;

        bool jumpedThisFrame;

        bool isAttacking;

        // For moves dependant on key pressed, use ENUM

        private float xVelocity = 0f;
        private float yVelocity = 0f;

        AttackCollider lightAttackCol;

        Pivot groundCheck;

        AnimationSprite GFX;

        #endregion

        public CharacterBase(string filename, int cols, int rows, Enums.players player) : base("transparant.png")
        {
            groundCheck = new Pivot();
            AddChild(groundCheck);
            groundCheck.SetXY(width / 2, 0);

            this.player = player;

            lightAttackCol = new AttackCollider(width , x - 32, height / 2, 0.5f, 0.5f, player);
            AddChild(lightAttackCol);

            GFX = new AnimationSprite(filename, cols, rows);
            AddChild(GFX);
            GFX.SetOrigin(GFX.width / 2, 0);
            GFX.SetXY(width / 2, y);
            GFX.SetFrame(0);
            GFX.SetCycle(0, 1, 5);

            GFX.Mirror(player != Enums.players.player1, false);
        }

        public void Update()
        {
            FaceEnemy();
            Grounded = CheckGrounded();
            Move();
            AttackInputs();
            MoveDown();
            GFX.AnimateFixed();

            if (Grounded)
            {
                xVelocity = Mathf.Lerp(xVelocity, 0, groundFriction);
            }
            else
            {
                xVelocity = Mathf.Lerp(xVelocity, 0, airFriction);
                yVelocity = Mathf.Lerp(yVelocity, 0, airFriction);
            }
            Grounded = false;
            jumpedThisFrame = false;
        }

        void FaceEnemy()
        {
            foreach (CharacterBase cha in game.players)
            {
                if (cha != this)
                {
                    if(cha.x > x)
                    {
                        GFX.Mirror(false, false);
                        lightAttackCol.Flip(true);
                    }
                    else
                    {
                        GFX.Mirror(true, false);
                        lightAttackCol.Flip(false);
                    }
                }
            }
        }

        void Move()
        {
            if (Input.GetKey(player == Enums.players.player1 ? Key.A : Key.LEFT) && !isAttacking)
            {
                xVelocity = -1;
            }
            if (Input.GetKey(player == Enums.players.player1 ? Key.D : Key.RIGHT) && !isAttacking)
            {
                xVelocity = 1;
            }
            if (Input.GetKey(player == Enums.players.player1 ? Key.W : Key.UP) && Grounded && !isAttacking)
            {
                jumpedThisFrame = true;
                yVelocity = -jumpForce;
            }

            x += xVelocity * speed;
        }

        void MoveDown()
        {
            // This is the gravity of the player wich increases over time and has a maximum increase
            


            if (yVelocity < 5 && !jumpedThisFrame)
            {
                yVelocity += gravity;
            }

            y += yVelocity;
        }

        bool CheckGrounded()
        {
            if (y >= groundLevel && !jumpedThisFrame) 
            {
                y = groundLevel;
                yVelocity= 0;
                return true;
            }

            return false;
        }

        void AttackInputs()
        {
            if (Input.GetKeyDown(player == Enums.players.player1 ? Key.G : Key.M))
            {
                _ = Attack();
            }
        }



        //TODO: light down attack, block, heavy attack, special attack

        async Task Attack()
        {
            if (isAttacking)
                return;
            isAttacking = true;
            GFX.SetCycle(0, 3, 10);
            await Task.Delay(333);
            lightAttackCol.CheckHit(this, 10);
            await Task.Delay(166);
            GFX.SetCycle(0, 1, 5);
            isAttacking = false;
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            Console.WriteLine(health);
            Console.WriteLine(player);
            if (health <= 0)
            {
                game.RemoveChild(this);
                game.players.Remove(this);
            }
        }

        void OnCollision(GameObject collider)
        {
            if(collider is CharacterBase)
            {
                CharacterBase cha = (CharacterBase)collider;
                if (y + height < cha.y + 10)
                {
                    if (x > cha.x + (cha.width/2))
                    {
                        x = cha.x + (cha.width);
                    }
                    else
                    {
                        x = cha.x - width - 10;
                    }
                    return;
                }
                if (x <= cha.x + width && x > cha.x + (cha.width/2))
                {
                    Console.WriteLine("right");
                    x = cha.x + cha.width;
                    return;
                }
                if (x + width >= cha.x && x + width < cha.x + (cha.width / 2))
                {
                    Console.WriteLine("left");
                    x = cha.x - width;
                    return;
                }
            }
        }
    }
}
