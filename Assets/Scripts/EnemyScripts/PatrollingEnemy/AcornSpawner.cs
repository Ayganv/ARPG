using UnityEngine;

public class AcornSpawner : MonoBehaviour
{
    public GameObject acorn;

    [Space]
    public float timeBetweenShots;

    private float timer;

    private void Update()
    {
        UpdateTime();

        Spawn();
    }

    private void Spawn()
    {
        if (timer >= timeBetweenShots)
        {
            Instantiate(acorn, transform.position, transform.rotation);
            timer -= timeBetweenShots;
        }
    }

    private void UpdateTime()
    {
        timer += Time.deltaTime;
    }
}