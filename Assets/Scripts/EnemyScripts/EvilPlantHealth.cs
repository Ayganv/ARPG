using System;
using Player;
using Units;

namespace EnemyScripts{
    public class EvilPlantHealth:UnitHealth{
        private void FixedUpdate()
        {
            if (Health <= 0){
                Destroy(gameObject);
                PlayerManager.Instance.RangedAttack.hasATarget = false;
            }
        }
    }
}