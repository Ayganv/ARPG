using Player;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    public int plantHealth;
    public int damage;
    public float timeBetweenAttack;
    public float damageRadius;
    private PlayerHealth _playerHealth;
    private Transform _player;
    private float _timeSinceLastAttack;

    private void Start()
    {
        _player = PlayerManager.Instance.transform;
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        DealDamage();
    }

    private void DealDamage()
    {
        if (Vector3.Distance(transform.position, _player.position) <= damageRadius)
        {
            if (_timeSinceLastAttack <= 0)
            {
                _playerHealth.TakeDamage(damage);
                _timeSinceLastAttack = timeBetweenAttack;
            }
            else
            {
                _timeSinceLastAttack -= Time.deltaTime;
            }
        }
    }
}