using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IBlockInfo
    {
        public DateTime CreatedAt { get; set; }

        bool DeleteMe();

        void Update(float deltaTime);
    }
}
