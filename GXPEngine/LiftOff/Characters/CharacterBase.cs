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

        public bool isEmpowered = false;

        Sound Jump;

        Sound Hit;

        protected Sound GetHit;

        bool controllerInput = true;

        protected float groundLevel = 300;

        Enums.players player;
        public float health { get; protected set; } = 100;

        public bool Grounded { get; private set; }
        public bool isBlocking { get; private set; }

        float airFriction = .03f;
        float groundFriction = 0.2f;

        public bool isStunned { get; protected set; } = false;

        bool jumpedThisFrame;

        public bool isAttacking { get; protected set; }

        internal bool isUlting = false;

        // For moves dependant on key pressed, use ENUM

        public float xVelocity { get; protected set; } = 0f;
        public float yVelocity { get; protected set; } = 0f;

        AttackCollider lightAttackCol;
        AttackCollider lightDownAttackCol;

        protected List<AttackCollider> attackColliders = new List<AttackCollider>();

        Pivot groundCheck;

        internal AnimationSprite GFX;

        public float ultCharge { get; private set; } = 0;

        public float requiredUltCharge { get; private set; } = 100;

        public bool isFlipped { get; private set; }

        #endregion

        public CharacterBase(string filename, int cols, int rows, Enums.players player, bool controller) : base("transparant.png")
        {
            
            Jump = new Sound("Jump.wav");
            Hit = new Sound("chr_hit3.wav");
            GetHit = new Sound("AttackWhoosh1.wav");

            controllerInput = controller;
            groundCheck = new Pivot();
            AddChild(groundCheck);
            groundCheck.SetXY(width / 2, 0);

            this.player = player;

            lightAttackCol = new AttackCollider(width, x, y, 110, height, player, true);
            AddChild(lightAttackCol);
            attackColliders.Add(lightAttackCol);

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


            if (yVelocity > 2.1)
            {
                GFX.SetCycle(40, 1, 10);
            }
            else if(yVelocity < 0.5 && jumpedThisFrame)
            {
                GFX.SetCycle(38, 3, 10);
                //if (GFX._doneAnimating && !jumpedThisFrame)
                //{
                //    GFX.SetCycle(40, 1, 10);
                //}
            }

            if(isBlocking && GFX._doneAnimating)
            {
                GFX.SetCycle(19, 1, 10);
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
                        isFlipped = false;
                    }
                    else
                    {
                        GFX.Mirror(false, false);
                        foreach (AttackCollider col in attackColliders)
                        {
                            col.Flip(false);
                        }
                        isFlipped = true;
                    }
                }
            }
        }

        void Move()
        {
            if (controllerInput)
            {
                if (ArduinoInput.GetAxisHorizontal(player) > 0 && !isAttacking && !isStunned && !isBlocking && !isUlting)
                {
                    if (!isFlipped)
                    {
                        GFX.SetCycle(43, 10, 7);
                    }
                    else
                    {
                        GFX.SetCycle(28, 10, 7);
                    }
                    xVelocity = -1;
                }
                if (ArduinoInput.GetAxisHorizontal(player) < 0 && !isAttacking && !isStunned && !isBlocking && !isUlting)
                {
                    if (isFlipped)
                    {
                        GFX.SetCycle(43, 10, 7);
                    }
                    else
                    {
                        GFX.SetCycle(28, 10, 7);
                    }
                    xVelocity = 1;
                }
                if (ArduinoInput.GetAxisVertical(player) < 0 && Grounded && !isAttacking && !isStunned && !isBlocking && !isUlting)
                {
                    Jump.Play();
                    jumpedThisFrame = true;
                    yVelocity = -game.config.generalStats.jumpForce;
                }
            }
            else
            {
                if (Input.GetKey(player == Enums.players.player1 ? Key.A : Key.LEFT) && !isAttacking && !isStunned && !isBlocking && !isUlting)
                {
                    if (!isFlipped)
                    {
                        GFX.SetCycle(43, 10, 7);
                    }
                    else
                    {
                        GFX.SetCycle(28, 10, 7);
                    }
                    xVelocity = -1;
                }
                if (Input.GetKey(player == Enums.players.player1 ? Key.D : Key.RIGHT) && !isAttacking && !isStunned && !isBlocking && !isUlting)
                {
                    if (isFlipped)
                    {
                        GFX.SetCycle(43, 10, 7);
                    }
                    else
                    {
                        GFX.SetCycle(28, 10, 7);
                    }
                    xVelocity = 1;
                }
                if (Input.GetKey(player == Enums.players.player1 ? Key.W : Key.UP) && Grounded && !isAttacking && !isStunned && !isBlocking && !isUlting)
                {
                    Jump.Play();
                    jumpedThisFrame = true;
                    yVelocity = -game.config.generalStats.jumpForce;
                }
            }


            if (xVelocity > -0.1f && xVelocity < 0.1f && !isAttacking && !isStunned && !isBlocking && !isUlting)
            {
                GFX.SetCycle(0, 5, 10);
            }

            x += xVelocity * game.config.generalStats.speed;

            if (x < 0)
            {
                x = 0;
            }
            if (x + width > game.width)
            {
                x = game.width - width;
            }
        }

        void MoveDown()
        {
            // This is the gravity of the player wich increases over time and has a maximum increase
            if (yVelocity < 5 && !jumpedThisFrame)
            {
                if(yVelocity < 0)
                {
                    yVelocity += game.config.generalStats.gravity * 0.5f;
                }
                else
                {
                    yVelocity += game.config.generalStats.gravity;
                }
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

            if (controllerInput)
            {
                if (player == Enums.players.player1 ? ArduinoInput.GetButtonDown("B1", Enums.players.player1) : ArduinoInput.GetButtonDown("B1", Enums.players.player2))
                {
                    _ = LightNormalAttack();
                }
                else if (player == Enums.players.player1 ? ArduinoInput.GetButtonDown("B2", Enums.players.player1) : ArduinoInput.GetButtonDown("B2", Enums.players.player2))
                {
                    _ = LightDownAttack();
                }
                if (player == Enums.players.player1 ? ArduinoInput.GetButtonDown("B3", Enums.players.player1) : ArduinoInput.GetButtonDown("B3", Enums.players.player2) && !isAttacking && !isStunned && !isUlting)
                {
                    Block();
                }
                else
                {
                    isBlocking = false;

                }

                if (ArduinoInput.GoingFast(player) && !isAttacking && !isStunned && !isBlocking && !isUlting && ultCharge >= requiredUltCharge)
                {
                    Ultimate();
                    ultCharge = 0;
                }
            }
            else
            {
                if (Input.GetKeyDown(player == Enums.players.player1 ? Key.G : Key.M))
                {
                    _ = LightAttack();
                }
                if (Input.GetKey(player == Enums.players.player1 ? Key.Z : Key.N) && !isAttacking && !isStunned && !isUlting)
                {
                    Block();
                }
                else
                {
                    isBlocking = false;

                }

                if (Input.GetKey(player == Enums.players.player1 ? Key.Q : Key.DOT) && !isAttacking && !isStunned && !isBlocking && !isUlting && ultCharge >= requiredUltCharge)
                {
                    Ultimate();
                    ultCharge = 0;
                }
            }

        }

        void Block()
        {
            GFX.SetCycle(17, 3, 10);

            if (GFX._doneAnimating)
            {
                GFX.SetCycle(19, 1, 10);
            }
            //TODO: 
            isBlocking = true;
        }

        async Task LightAttack()
        {
            if (isAttacking || isBlocking || isUlting)
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
            if (isAttacking || isBlocking || isUlting)
                return;
            isAttacking = true;
            GFX.SetCycle(13, 4, 10);
            Hit.Play();
            await Task.Delay(333);
            if (isStunned)
            {
                return;
            }
            if(lightAttackCol.CheckHit(this, game.config.generalStats.punchDamage * (float)(isEmpowered ? 1.1 : 1), game.config.generalStats.hitKnockback))
            {
                ultCharge += 50;
                ultCharge = Mathf.Clamp(ultCharge, 0, requiredUltCharge);
            }
            await Task.Delay(333);
            GFX.SetCycle(0, 5, 10);
            isAttacking = false;
        }

        async Task LightDownAttack()
        {
            if (isAttacking || isBlocking || isUlting)
                return;
            isAttacking = true;
            GFX.SetCycle(5, 5, 10);
            Hit.Play();
            await Task.Delay(555);
            if (lightAttackCol.CheckHit(this, game.config.generalStats.kickDamage * (float)(isEmpowered ? 1.1 : 1), game.config.generalStats.hitKnockback))
            {
                ultCharge += 50;
                ultCharge = Mathf.Clamp(ultCharge, 0, requiredUltCharge);
            }
            await Task.Delay(300);
            GFX.SetCycle(0, 5, 10);
            isAttacking = false;
        }

        public virtual async Task Ultimate()
        {

        }

        public void Reset()
        {
            health = 100;
            ultCharge = 0;
            SetXY(player == Enums.players.player1 ? 0 : 1000, 0);
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

        public void OnCollision(GameObject collider)
        {
            if(collider is FireGirl || collider is FatGuy || collider is RootsGuy)
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
                    x = cha.x + cha.width;
                    return;
                }
                if (x + width >= cha.x && x + width < cha.x + (cha.width / 2))
                {
                    x = cha.x - width;
                    return;
                }
            }
        }
    }
}