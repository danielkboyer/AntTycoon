using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockInfos
{
    public class AntB : BlockInfo
    {
        public NavigationStatus NavStatus;
        public AntStatus Status;

     
        public AntB(Ant ant)
        {
            this.Status = ant.Status;
            this.NavStatus = ant.NavStatus;
            this.CreatedAt = DateTime.UtcNow;
            Position = new Vector3(ant.transform.position.x, ant.transform.position.y, ant.transform.position.z);
        }

        public override void CreateGameObject(Transform map)
        {
            
        }

        public override bool DeleteMe()
        {
            return true;
        }

        public override void Update(float deltaTime)
        {
            return;
        }
    }
}
