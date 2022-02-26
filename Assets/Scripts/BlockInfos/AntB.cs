using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BlockInfos
{
    public class AntB : IBlockInfo
    {
        public NavigationStatus NavStatus;
        public AntStatus Status;
        public AntB(Ant ant)
        {
            this.Status = ant.Status;
            this.NavStatus = ant.NavStatus;
            this.CreatedAt = DateTime.UtcNow;
        }
        public DateTime CreatedAt
        {
            get; set;
        }
        public bool DeleteMe()
        {
            return true;
        }

        public void Update(float deltaTime)
        {
            return;
        }
    }
}
