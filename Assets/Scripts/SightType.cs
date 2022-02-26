using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public enum SightType
    {
        //On Path
        PATH = 0,
        //Of Path
        OFF_PATH = 1,
        //Another teamate ant
        ANT = 2,
        //An enemy Ant
        ENEMY = 3,
        //Food
        FOOD = 4,
        //Hive
        HIVE = 5,
        //Food Feremones
        FOOD_F = 6,
        //EnemyFeremones
        ENEMY_F = 7,
        //Hive Feremones
        HIVE_F  = 8
    }
}
