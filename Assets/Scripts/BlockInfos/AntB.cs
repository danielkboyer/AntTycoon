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
        public Food Food;
        public bool HasFood;
     
        public AntB(Ant ant)
        {
            this.NavStatus = ant.NavStatus;
            this.CreatedAt = DateTime.UtcNow;
            this.Food = ant.CurrentFood;
            Position = new Vector3(ant.transform.position.x, ant.transform.position.y, ant.transform.position.z);
        }

        public AntB(NavigationStatus status, Food food, Vector3 position, Transform parent)
        {
            _parent = parent;
            this.NavStatus = status;
            this.CreatedAt = DateTime.UtcNow;
            this.Food = food;
            Position = new Vector3(position.x, position.y, position.z);
            CreateGameObject(parent);
        }

        public override void CreateGameObject(Transform parent)
        {
            _parent = parent;
            UnityObject = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/Ant"), Position, Quaternion.identity, _parent);
            var antScript = UnityObject.GetComponent<Ant>();
            antScript.NavStatus = this.NavStatus;
            if(HasFood)
            {
                this.Food.CreateGameObject(parent);
            }
            else
            {
                this.Food = null;
            }
            antScript.CurrentFood = this.Food;
            
           
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
