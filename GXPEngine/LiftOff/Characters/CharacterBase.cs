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
        int jumpForce = 50;
        float health = 100;

        float gravity = 2;

        public bool Grounded { get; private set; }
        public bool isBlocking { get; private set; }

        float airFriction = .03f;
        float groundFriction = 0.2f;

        bool isStunned = false;

        bool jumpedThisFrame;

        bool isAttacking;

        // For moves dependant on key pressed, use ENUM

        private float xVelocity = 0f;
        private float yVelocity = 0f;

        AttackCollider lightAttackCol;
        AttackCollider lightDownAttackCol;

        List<AttackCollider> attackColliders = new List<AttackCollider>();

        Pivot groundCheck;

        AnimationSprite GFX;

        #endregion

        public CharacterBase(string filename, int cols, int rows, Enums.players player) : base("transparant.png")
        {
            groundCheck = new Pivot();
            AddChild(groundCheck);
            groundCheck.SetXY(width / 2, 0);

            this.player = player;

            lightAttackCol = new AttackCollider(width , x - 32, height / 2, 0.5f, 0.5f, player, true);
            AddChild(lightAttackCol);
            attackColliders.Add(lightAttackCol);

            lightDownAttackCol = new AttackCollider(width, x - 32, height + 200, 0.5f, 0.5f, player, false);
            AddChild(lightDownAttackCol);
            attackColliders.Add(lightDownAttackCol);

            GFX = new AnimationSprite(filename, cols, rows);
            AddChild(GFX);
            GFX.SetOrigin(GFX.width / 2, 0);
            GFX.SetXY(width / 2, y);
            GFX.SetFrame(0);
            GFX.SetCycle(0, 5, 10);

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
                        GFX.Mirror(true, false);
                        foreach(AttackCollider col in attackColliders)
                        {
                            col.Flip(true);
                        }                    
                    }
                    else
                    {
                        GFX.Mirror(false, false);
                        foreach (AttackCollider col in attackColliders)
                        {
                            col.Flip(false);
                        }
                    }
                }
            }
        }

        void Move()
        {
            if (Input.GetKey(player == Enums.players.player1 ? Key.A : Key.LEFT) && !isAttacking && !isStunned)
            {
                
                xVelocity = -1;
            }
            if (Input.GetKey(player == Enums.players.player1 ? Key.D : Key.RIGHT) && !isAttacking && !isStunned)
            {
                xVelocity = 1;
            }
            if (Input.GetKey(player == Enums.players.player1 ? Key.W : Key.UP) && Grounded && !isAttacking && !isStunned)
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
            if ( y >= groundLevel && !jumpedThisFrame) 
            {
                y = groundLevel;
                yVelocity= 0;
                return true;
            }

            return false;
        }

        void AttackInputs()
        {
            if (isStunned)
                return;
            if (Input.GetKeyDown(player == Enums.players.player1 ? Key.G : Key.M))
            {
                _ = LightAttack();
            }
            if (Input.GetKey(player == Enums.players.player1 ? Key.LEFT_SHIFT : Key.NUMPAD_INSERT))
            {

            }
        }

        void Block()
        {
            //TODO: 
        }


        //TODO: block, heavy attack, special attack

        async Task LightAttack()
        {
            if (isAttacking)
                return;
            if (Input.GetKey(player == Enums.players.player1 ? Key.S : Key.DOWN))
            {
                LightDownAttack();
            }
            else
            {
                LightNormalAttack();
            }

        }

        async Task LightNormalAttack()
        {
            isAttacking = true;
            GFX.SetCycle(13, 4, 10);
            await Task.Delay(333);
            if (isStunned)
            {
                return;
            }
            lightAttackCol.CheckHit(this, 10);
            await Task.Delay(333);
            GFX.SetCycle(0, 5, 10);
            isAttacking = false;
        }

        async Task LightDownAttack()
        {
            Console.WriteLine("Down");
            isAttacking = true;
            GFX.SetCycle(5, 5, 10);
            await Task.Delay(555);
            lightAttackCol.CheckHit(this, 10);
            await Task.Delay(300);
            GFX.SetCycle(0, 5, 10);
            isAttacking = false;
        }

        public async Task TakeHit(float amount, bool left)
        {
            //TODO: knockback after certain amount of hits

            health -= amount;

            
            if (health <= 0)
            {
                game.RemoveChild(this);
                game.players.Remove(this);
                return;
            }


            isStunned = true;

            xVelocity = left ? -10 : 10;

            GFX.SetCycle(10, 3, 7);

            isAttacking = false;

            await Task.Delay(500);

            GFX.SetCycle(0, 5, 10);

            isStunned = false;
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
