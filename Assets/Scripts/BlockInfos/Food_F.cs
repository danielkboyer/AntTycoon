﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockInfos
{
    [Serializable]
    public class Food_F: BlockInfo
    {
        public override void CreateGameObject(Map map)
        {
            throw new NotImplementedException();
        }

        public new bool  DeleteMe()
        {
            return false;
        }

        public new void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
