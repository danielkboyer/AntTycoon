using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockInfos
{
    [Serializable]
    public class Food : BlockInfo
    {
        
        public bool AtHive;
        public override bool DeleteMe()
        {
            if (AtHive)
            {
                GameObject.Destroy(UnityObject);
            }
            return AtHive;
        }
        public Food()
        {
            
        }
        public Food(Vector3 position)
        {
            _parent = GameObject.FindObjectOfType<Map>().transform;
            Position = position;
            UnityObject = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/Food"), position, Quaternion.identity);
            CreatedAt = DateTime.UtcNow;
        }
        public override void Update(float deltaTime)
        {
            
        }
        

        public override void CreateGameObject(Transform parent)
        {
            _parent = parent;
            UnityObject = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/Food"), Position, Quaternion.identity, _parent);
        }
    }
}
