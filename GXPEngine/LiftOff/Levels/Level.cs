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

        public int match = -1;

        public List<GameObject> levelColliders = new List<GameObject>();

        Random rand = new Random();

        float time;

        int numOfFrames;

        bool animate;

        #endregion

        public Level(string filename, int cols, int rows, int numOfFrames, bool animate = true) : base(filename, cols, rows, addCollider:false)
        {
            this.numOfFrames = numOfFrames;
            this.animate = animate;
        }

        public void Update()
        {
            if (!animate)
            {
                return;
            }
            AnimateFixed();

            if(time <= 0)
            {
                SetCycle(0, numOfFrames, 6);
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
