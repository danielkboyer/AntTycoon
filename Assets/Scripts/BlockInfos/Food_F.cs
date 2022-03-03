using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockInfos
{
    [Serializable]
    public class Food_F : BlockInfo
    {
        [SerializeField]
        private bool _deleteMe = false;
        [SerializeField]
        private float _expiryTime;





        public Food_F(Vector3 position, float expiryTime, Transform parent)
        {
            this._expiryTime = expiryTime;
            this.CreatedAt = DateTime.UtcNow;
            Position = new Vector3(position.x, position.y, position.z);
            CreateGameObject(parent);
        }
        public float GetExpiryTime()
        {
            return _expiryTime;
        }
        public override void CreateGameObject(Transform parent)
        {
            _parent = parent;
            UnityObject = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/Food_F"), Position, Quaternion.identity, _parent);
        }

        public override bool DeleteMe()
        {
            return _deleteMe;
        }

        public override void Update(float deltaTime)
        {
            _expiryTime -= deltaTime;
            if (_expiryTime < 0)
            {
                GameObject.Destroy(UnityObject);
                _deleteMe = true;
            }
        }
    }
}
