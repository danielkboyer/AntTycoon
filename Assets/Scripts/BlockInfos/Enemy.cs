using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BlockInfos
{
    public class Enemy : IBlockInfo
    {
        public DateTime CreatedAt
        {
            get => throw new NotImplementedException(); set => throw new NotImplementedException();
        }
        public bool DeleteMe()
        {
            return false;
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
