using Player;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public float Speed;

    [Space]
    public float Damage;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += Vector3.forward * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.Instance.PlayerHealth.TakeDamage(Damage);
            Destroy(this.gameObject);
        }
    }
}