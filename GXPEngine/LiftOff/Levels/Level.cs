using GXPEngine.Core;
using GXPEngine.LiftOff.Levels;
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
            SetXY(0, game.height / 2);
            scaleX = game.width / 2;
            levelColliders.Add(collider);
            AddChild(collider);
        }
    }
}
