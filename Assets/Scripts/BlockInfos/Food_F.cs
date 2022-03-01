using System;
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
      
        public bool  DeleteMe()
        {
            return false;
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
