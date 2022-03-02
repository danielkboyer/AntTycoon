using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public abstract class BlockInfo
    {

        [SerializeField]
        public DateTime CreatedAt;
        [NonSerialized]
        public GameObject UnityObject = null;
        [SerializeField]
        public Vector3 Position;

        protected Transform _parent;




        public virtual bool DeleteMe()
        {
            return false;
        }

        public virtual void Update(float deltaTime)
        {

        }

        public abstract void CreateGameObject(Transform map);

        
    }
}
