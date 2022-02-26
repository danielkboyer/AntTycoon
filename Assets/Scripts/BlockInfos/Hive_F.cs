using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BlockInfos
{
    public class Hive_F : IBlockInfo
    {
        private bool _deleteMe = false;

        private float _expiryTime;
        public DateTime CreatedAt { get; set; }

        public Hive_F(float expiryTime)
        {
            this._expiryTime = expiryTime;
            this.CreatedAt = DateTime.UtcNow;

        }
        public bool DeleteMe()
        {
            return _deleteMe;
        }

        public void Update(float deltaTime)
        {
            _expiryTime -= deltaTime;
            if(_expiryTime < 0)
            {
                _deleteMe = true;
            }
        }
    }
}
