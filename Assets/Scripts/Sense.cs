using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Sense
    {
        public float Distance;
        public Block Block;
        public float Angle;

        public Sense(float distance, Block block, float angle)
        {
            this.Distance = distance;
            this.Block = block;
            this.Angle = angle;
        }

    }
}
