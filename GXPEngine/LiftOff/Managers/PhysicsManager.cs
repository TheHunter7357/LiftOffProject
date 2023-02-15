using GXPEngine.Core;
using GXPEngine.LiftOff.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class PhysicsManager
    {
        List<RigidBody> rigidBodies= new List<RigidBody>();

        float groundFriction;
        float airFriction;
        float gravity = -9.81f;

        public PhysicsManager() { }

        public void Step()
        {
            foreach(RigidBody rigidBody in rigidBodies)
            {
                CalculateVelocity(rigidBody);

                rigidBody.Move();

                foreach(RigidBody rigidBody1 in rigidBodies)
                {
                    if (rigidBody != rigidBody1 && rigidBody.owner.HitTest(rigidBody1.owner))
                    {

                    }
                }
            }
        }

        void CalculateVelocity(RigidBody body)
        {
            if(body.owner is CharacterBase)
            {

                CharacterBase cha = (CharacterBase)body.owner;
                if (cha.Grounded)
                {
                    body.acceleration.x -= CalculateGroundFriction(body);
                }
                else
                {
                }
            }

            body.velocity.x += body.acceleration.x;
            body.velocity.y += body.acceleration.y;
        }

        float CalculateGroundFriction(RigidBody body)
        {
            float coefficient;

            if(body.velocity.x == 0 && body.velocity.y == 0)
            {
                coefficient = 0.61f;
            }
            else
            {
                coefficient = 0.52f;
            }

            float normalForce = body.mass * gravity;
            float friction = coefficient * normalForce;
            Console.WriteLine(friction);
            return friction;
        }

        public void AddBody(RigidBody body)
        {
            rigidBodies.Add(body);
        }

        public void AddForce(Vector2 force, RigidBody body)
        {
            //     Fapp - coeff*mass*gravity
            // a =  -------------------------
            //                mass

            body.acceleration += (force - (0.52f * body.mass * gravity)) / body.mass;
        }
    }
}
