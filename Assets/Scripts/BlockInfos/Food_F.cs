using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BlockInfos
{
    public class Food_F: IBlockInfo
    {
        public DateTime CreatedAt { get; set; }

        public bool  DeleteMe()
        {
            return false;
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
