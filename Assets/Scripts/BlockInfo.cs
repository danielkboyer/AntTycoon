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





        public bool DeleteMe()
        {
            return false;
        }

        public void Update(float deltaTime)
        {

        }

        
    }
}
