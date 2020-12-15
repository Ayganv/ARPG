using EnemyScripts;
using UnityEngine;
using UnityEngine.Events;

namespace Player{
    public class MeleeAttack: MonoBehaviour
    {
        public int damage;
        public float timeBetweenAttack;
        public float damageRadius;
        private Transform _player;
        private EvilPlantHealth _enemyTarget;
        private float _timeSinceLastAttack;

        public UnityEvent PlayerMeleeAttack;

        public void InitiateAttack(GameObject enemy){
            _enemyTarget = enemy.GetComponentInParent<EvilPlantHealth>();
        }
        private void Start(){
            _player = PlayerManager.Instance.transform;
        }

        private void FixedUpdate(){
            if (_timeSinceLastAttack <= 0)
            {
                DealDamage();
                _timeSinceLastAttack = timeBetweenAttack;
            }
            else
            {
                _timeSinceLastAttack -= Time.deltaTime;
            }
     
        }

        private void DealDamage(){
            if (_enemyTarget == null){
                return;
            }
            
            if (Vector3.Distance(_enemyTarget.transform.position, _player.position) <= damageRadius){
                PlayerMeleeAttack.Invoke();
                _enemyTarget.TakeDamage(damage);
                Debug.Log(_enemyTarget.Health + "enemy health");
                
            }
        }
    }
}