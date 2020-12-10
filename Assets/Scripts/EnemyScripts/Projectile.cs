using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector3 target;

    public bool followingProjectile;

    private RangedEnemy _rangedEnemy;
    private int _damageToInflict;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _damageToInflict = _rangedEnemy.damage;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    private void Update()
    {
        if (followingProjectile == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else if (followingProjectile)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if (transform.position == target) DestroyProjectile();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")) DestroyProjectile();
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHealth>().TakeDamage(_damageToInflict);
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}