using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts.BlockInfos
{
    public class Hive_F : BlockInfo
    {
        private bool _deleteMe = false;

        private float _expiryTime;

      



        public Hive_F(Vector3 position,float expiryTime)
        {
            UnityObject = Resources.Load<GameObject>("Prefabs/Hive_F");
            this._expiryTime = expiryTime;
            this.CreatedAt = DateTime.UtcNow;
            Position = position;

        }

        public override void CreateGameObject(Map map)
        {
            _parent = map.transform;
            UnityObject = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/Hive_F"), Position, Quaternion.identity, _parent);
        }

        public new bool DeleteMe()
        {
            return _deleteMe;
        }

        public new void Update(float deltaTime)
        {
            _expiryTime -= deltaTime;
            if(_expiryTime < 0)
            {
                GameObject.Destroy(UnityObject);
                _deleteMe = true;
            }
        }
    }
}
