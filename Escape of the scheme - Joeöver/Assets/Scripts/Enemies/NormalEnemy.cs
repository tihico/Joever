using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Enemies
{
    internal class NormalEnemy : EnemyInheritance
    {
        //nothin to add here this solely exists due to the fact that enemyinheritance is an abstract class
        public void DmgTanking()
        {
            base.DmgTaken();
        }

    }
}
