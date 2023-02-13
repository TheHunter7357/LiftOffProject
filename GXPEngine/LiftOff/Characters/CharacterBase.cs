using GXPEngine.Core;
using GXPEngine.LiftOff.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class CharacterBase : AnimationSprite
    {
        #region properties

        Enums.players player;
        int speed = 3;
        int jumpForce = 5;
        int health;

        float gravity = 0.09f;
        bool Grounded;

        bool jumpedThisFrame;

        // For moves dependant on key pressed, use ENUM

        float moveX;
        float velocityY;

        #endregion

        public CharacterBase(string filename, int cols, int rows, Enums.players player) : base(filename, cols, rows)
        {
            this.player = player;
        }

        public void Update()
        {
            Playermove();
            Animate();
            if (!Grounded)
            { MoveDown(); }
            Grounded = false;
            jumpedThisFrame = false;

            
        }


        void Playermove() // controls of the player
        {
            if (player == Enums.players.player1 ? Input.GetKeyDown(Key.D) : Input.GetKeyDown(Key.RIGHT))
            {
                moveX += 1;
                Mirror(false, false);
            }
            if (player == Enums.players.player1 ? Input.GetKeyDown(Key.A) : Input.GetKeyDown(Key.LEFT))
            {
                moveX -= 1;
                Mirror(true, false);
            }
            if (player == Enums.players.player1 ? Input.GetKeyUp(Key.D) : Input.GetKeyUp(Key.RIGHT))
            {
                moveX -= 1;
            }
            if (player == Enums.players.player1 ? Input.GetKeyUp(Key.A) : Input.GetKeyUp(Key.LEFT))
            {
                moveX += 1;
            }
            if (player == Enums.players.player1 ? Input.GetKeyDown(Key.W) : Input.GetKeyDown(Key.UP)) // w
            {
                if (!Grounded)
                    return;
                velocityY = -jumpForce;
                jumpedThisFrame = true;
            }
            MoveUntilCollision(moveX, 0, game.players);
            
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

        void OnCollision(GameObject collider)
        {
            if (collider is LevelCollider && velocityY >= 0)
            {
                Grounded = true;
                velocityY = 0;
            }
        }
    }
}
