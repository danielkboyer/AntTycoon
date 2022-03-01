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

        public void DestroyGameObjects()
        {
            foreach(var blockInfo in _blockInfos)
            {
                if(blockInfo.UnityObject != null)
                    GameObject.DestroyImmediate(blockInfo.UnityObject,true);

            }
            _blockInfos = new List<BlockInfo>();
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
    }
}
