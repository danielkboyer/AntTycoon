using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockInfos
{
    [Serializable]
    public class Food : BlockInfo,ISerializationCallbackReceiver
    {

        public bool AtHive;
        private Transform _parent { get; set; }
        public new bool DeleteMe()
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
        public new void Update(float deltaTime)
        {
            
        }

        public void OnBeforeSerialize()
        {
            GameObject.DestroyImmediate(UnityObject,true);
        }

        public void OnAfterDeserialize()
        {
            _parent = GameObject.FindObjectOfType<Map>().transform;
            UnityObject = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/Food"), Position, Quaternion.identity, _parent);
        }
    }
}
