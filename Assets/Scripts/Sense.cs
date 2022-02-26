using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Sense
    {
        /// <summary>
        /// navigation cares more about enemy than food
        /// </summary>
        public static int[] NavigatePriority = { 0, 1, 1, 0, 5, 4, 4, 5, 0 };
        public static int[] HivePriority = { 0, 1, 2, 5, 4, 0, 0, 5, 4 };
        public static int[] AttackPriority = { 0, 1, 2, 5, 4, 0, 0, 5, 4 };
        public float Distance;
        public GridType HitType;
        public float Angle;


    }
}
