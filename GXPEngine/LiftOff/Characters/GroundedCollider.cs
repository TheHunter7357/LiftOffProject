using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class GroundedCollider : Sprite
    {
        CharacterBase owner;

        public GroundedCollider(CharacterBase owner) : base("triangle.png")
        {
            SetOrigin(width / 2, 0);
            SetXY(owner.x + (owner.width / 2), owner.y + owner.height);
            SetScaleXY(_scaleX, 0.1f);
            owner.AddChild(this);
            this.owner = owner;
        }

        void OnCollision(GameObject collider)
        {
            if (collider is LevelCollider)
            {
              
            }
        }


    }
}
