using GXPEngine.Core;
using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Level : AnimationSprite
    {
        #region properties

        public List<GameObject> levelColliders = new List<GameObject>();

        Random rand = new Random();

        float time;

        #endregion

        public Level(string filename, int cols, int rows) : base(filename, cols, rows, addCollider:false)
        {

            LevelCollider collider = new LevelCollider("colors.png");
            collider.SetXY(0, game.height - 100);
            collider.scaleX = game.width / 2;
            collider.Mirror(false, true);
            levelColliders.Add(collider);
            AddChild(collider);
            SetCycle(0, 1, 6);
            
        }

        void Update()
        {
            AnimateFixed();

            if(time <= 0)
            {
                SetCycle(0, 14, 6);
                time = rand.Next(2000, 10000);
            }
            else
            {
                time -= Time.deltaTime ;
            }
            if (_doneAnimating)
            {
                SetCycle(0, 1, 7);
            }

        }
    }
}
