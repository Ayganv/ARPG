using System;
using Units;

namespace EnemyScripts{
    public class EvilPlantHealth:UnitHealth{
        private void FixedUpdate()
        {
            if (Health <= 0){
                Destroy(gameObject);
            }
        }
    }
}