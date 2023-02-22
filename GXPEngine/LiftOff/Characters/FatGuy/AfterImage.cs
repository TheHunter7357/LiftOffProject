using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class AfterImage : AnimationSprite
    {
        AnimationSprite GFX;

        int startColor = 0x0000FF;
        int currentColor = 0x0000FF;

        CharacterBase owner;

        public AfterImage(AnimationSprite owner) : base("Fatguy.png", 10, 6, addCollider: false)
        {
            visible = false;
            GFX = owner;
            color = (uint)currentColor;
            currentFrame = GFX.currentFrame;
            this.owner = (CharacterBase)GFX.parent;
        }

        public async Task Next()
        {

            Mirror(!owner.isFlipped, false);
            visible = true;
            SetXY(GFX.parent.x - 100, GFX.parent.y);
            currentColor = startColor;
            currentFrame = GFX.currentFrame;
            color = (uint)currentColor;

            for(int i = 0; i < 10; i++)
            {

                currentColor = (int)Mathf.Lerp(currentColor, 0x00FF00, 0.1f);
                await Task.Delay(100);
                color = (uint)currentColor;
                
            }

            visible = false;

        }
    }
}
