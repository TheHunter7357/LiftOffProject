using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class StartLevel : Level
    {
        public StartLevel(string filename, int cols, int rows, int numOfFrames) : base(filename, cols, rows, numOfFrames)
        {
        }

        void Update()
        {
            if (Input.GetKeyDown(Key.ENTER))
            {
                game.LoadNextLevel();
            }


            base.Update();

        }
    }
}
