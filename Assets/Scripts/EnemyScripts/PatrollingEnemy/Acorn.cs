using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Acorn : MonoBehaviour
{
    public float speed;
    public float damage;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.Instance.playerHealth.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
