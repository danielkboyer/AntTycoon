using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockInfos
{
    public class HiveB : BlockInfo
    {
        public HiveB(Vector3 position,Transform parent)
        {
            _parent = parent;
            this.CreatedAt = DateTime.UtcNow;
            Position = new Vector3(position.x, position.y, position.z);
            CreateGameObject(parent);
        }
        public override bool DeleteMe()
        {
            return false;
        }

        public override void Update(float deltaTime)
        {
            return;
        }

        
        public override void CreateGameObject(Transform parent)
        {
            _parent = parent;
            UnityObject = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/Hive"), Position, Quaternion.identity, _parent);
        }
    }
}
