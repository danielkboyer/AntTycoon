using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Sense:IComparable
    {
        public float Distance;
        public Block Block;
        public float Angle;
        NavigationStatus Status;


        public Sense(NavigationStatus status,float distance, Block block, float angle)
        {
            Status = status;
            this.Distance = distance;
            this.Block = block;
            this.Angle = angle;
        }

        /// <summary>
        /// I reversed the compare to because my priority queue is a min priority queue
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            Sense toCompare = (Sense)obj;
            float score = 0;
            if (Status == NavigationStatus.NAVIGATING)
            {
                score = Block.GetNavigationScore(Distance) - toCompare.Block.GetNavigationScore(toCompare.Distance);

                
            }
            else if(Status == NavigationStatus.RETURNING)
            {
                score = Block.GetReturnScore(Distance) - toCompare.Block.GetReturnScore(toCompare.Distance);
            }
            return score > 0 ? -1 : score == 0 ? 0 : 1;
        }
    }
}
