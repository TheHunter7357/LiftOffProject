using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Roots : AnimationSprite
    {
        CharacterBase owner;

        float speed;

        bool flipped;

        bool hasHit;

        bool isAppearing = true;

        bool isDisappearing = false;

        bool isInit = false;

        public Roots(CharacterBase owner) : base("Roots.png", 4, 2)
        {
            this.owner = owner;
            SetXY(1000, 1000);
            speed = game.config.characterStats.rootStats.ultSpeed;
        }

        void OnCollision(GameObject collider)
        {
            if(collider is CharacterBase && collider != owner && !hasHit)
            {
                CharacterBase other = (CharacterBase)collider;
                _ = other.TakeHit(game.config.characterStats.rootStats.ultDamage * (float)(owner.isEmpowered ? 1.1 : 1), flipped, 4);
                hasHit = true;
            }
        }

        public void Init()
        {
            visible = true;
            isAppearing = true;
            flipped = owner.isFlipped;
            SetXY(owner.x, owner.y);
            SetCycle(0, 2, 10);

            Mirror(!flipped, false);
            isInit = true;
        }

        void Update()
        {
            AnimateFixed();
            if (_doneAnimating && isAppearing)
            {
                Console.WriteLine("in");
                SetCycle(2, 3, 10);
                isAppearing = false;
            }
            if (!flipped)
            {
                x += speed;
            }
            else
            {
                x -= speed;
            }

            if(isDisappearing && _doneAnimating)
            {
                SetXY(1000, 1000);
                isDisappearing= false;
                hasHit= false;
            }

            if(x <= 0 || x + width >= game.width && isInit)
            {
                Console.WriteLine("out");
                SetCycle(5, 2, 10);
                isDisappearing = true;
                isInit= false;
            }

        }
    }
}
