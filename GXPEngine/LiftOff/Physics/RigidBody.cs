using GXPEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine.LiftOff.Physics
{
    public class RigidBody
    {


        public Sprite owner;

        public Vector2 velocity;

        public Vector2 acceleration;

        public float mass;

        public RigidBody(Sprite owner, float mass) 
        {
            this.owner = owner;
            Game.main._physicsManager.AddBody(this);
            this.mass = mass;
        }

        public void AddForce(Vector2 force)
        {
            // F = m * a
            // a = F/m

            Game.main._physicsManager.AddForce(force, this);

        }

        public void Move() 
        {
            owner.x += velocity.x;
            owner.y -= velocity.y;
        }

        
    }
}
