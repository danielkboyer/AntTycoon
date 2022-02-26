using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IAnt
    {

        void TakeDamage(int amount);
        void Move();
        AntType GetType();

        void Attack(IAnt toAttack);

        Vector3 GetPos();
    }
}
