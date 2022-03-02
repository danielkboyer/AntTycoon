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

      



        public Hive_F(Vector3 position,float expiryTime,Transform parent)
        {
            this._expiryTime = expiryTime;
            this.CreatedAt = DateTime.UtcNow;
            Position = new Vector3(position.x,position.y,position.z);
            CreateGameObject(parent);
        }

        public override void CreateGameObject(Transform parent)
        {
            _parent = parent;
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
