using Assets.Scripts.BlockInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Block
    {
        
        public int Activity;
        public bool IsPathway;
        public bool IsVisible;
        [SerializeReference]
        private List<BlockInfo> _blockInfos;
        [SerializeField]
        private float _visibleTime;


        public Block()
        {
            _blockInfos = new List<BlockInfo>();
        }
        public Block(bool isPathWay, bool isVisible)
        {
            IsPathway = isPathWay;
            IsVisible = isVisible;
            _blockInfos = new List<BlockInfo>();
        }

        public float GetReturnScore(float distance)
        {
            if (!IsPathway)
                return float.MinValue;

            if (_blockInfos.Any(t => t is Enemy))
            {
                return 1500 - distance;
            }
            if(_blockInfos.Any(t=> t is HiveB))
            {
                return 1250 - distance;
            }
            if (_blockInfos.Any(t => t is Hive_F))
            {

                return 1000 - _blockInfos.Where(t => t is Hive_F).Select(t => (Hive_F)(t)).Min(t => t.GetExpiryTime());

            }

            return Activity + distance;

        }

        public bool HasFood()
        {
            return _blockInfos.Any(t => t is Food);
        }

        public bool IsHive()
        {
            return _blockInfos.Any(t => t is HiveB);
        }

        public Food GetFood()
        {
            if(_blockInfos.Any(t=>t is Food))
            {
                var food = (Food)_blockInfos.First(t => t is Food);
                _blockInfos.Remove(food);
                return food;
            }
            return null;
        }

        /// <summary>
        /// The higher the navigation score the better chance the ant will choose this block
        /// </summary>
        /// <returns></returns>
        public float GetNavigationScore(float distance)
        {
            if (!IsPathway)
                return float.MinValue;

            if (_blockInfos.Any(t => t is Enemy))
            {
                return 1500 - distance;
            }
            if (_blockInfos.Any(t=> t is Food))
            {
                return 1250 - distance;

            }

            if(_blockInfos.Any(t=> t is Food_F))
            {
                //TODO add time for food pheramones
                return 80 - _blockInfos.Where(t => t is Food_F).Select(t => (Food_F)(t)).Min(t => t.GetExpiryTime());
            }


            return (-Activity) + distance;


        }

        public void DestroyGameObjects()
        {
            if (_blockInfos != null)
            {
                foreach (var blockInfo in _blockInfos)
                {
                    if (blockInfo.UnityObject != null)
                        GameObject.DestroyImmediate(blockInfo.UnityObject, true);

                }
            }
        }

        public void SetVisibility(float time)
        {
            if(time <= 0)
            {
                throw new Exception("Cannot add time less than or equal to zero");
            }
            _visibleTime = time;
            IsVisible = true;
        }

        public void AddBlockInfo(BlockInfo info)
        {
            Activity++;
            _blockInfos.Add(info);
        }

        public void Update(float deltaTime)
        {
            if(_visibleTime > 0)
                _visibleTime -= deltaTime;
            if(_visibleTime < 0)
            {
                IsVisible = false;
            }

            int x = 0;
            while(x < _blockInfos.Count)
            {
                _blockInfos[x].Update(deltaTime);
                if (_blockInfos[x].DeleteMe())
                {
                    _blockInfos.RemoveAt(x);
                }
                else
                {
                    x++;
                }
            }

            

        }

        public void CreateGameObject(Transform parent)
        {
            if (_blockInfos != null)
            {
                foreach (var blockInfo in _blockInfos)
                {
                    blockInfo.CreateGameObject(parent);

                }
            }
        }
    }
}
