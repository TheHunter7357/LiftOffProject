using GXPEngine.Core;
using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Level : Sprite
    {
        #region properties

        public List<GameObject> levelColliders = new List<GameObject>();

        #endregion

        public Level(string filename) : base(filename, addCollider:false)
        {

            LevelCollider collider = new LevelCollider("colors.png");
            collider.SetXY(0, game.height - 100);
            collider.scaleX = game.width / 2;
            collider.Mirror(false, true);
            levelColliders.Add(collider);
            AddChild(collider);
        }
    }
}
