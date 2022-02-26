using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Block
    {
        public int Activity;
        public bool IsPathway;
        public bool IsVisible;


        private List<IBlockInfo> _blockInfos;
        private float _visibleTime;


        public Block(bool isPathWay, bool isVisible)
        {
            IsPathway = isPathWay;
            IsVisible = isVisible;
            _blockInfos = new List<IBlockInfo>();
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

        public void AddBlockInfo(IBlockInfo info)
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
