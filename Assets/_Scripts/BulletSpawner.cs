using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    float timer;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3f)
        {
            SpawnProjectile();
            timer = 0;
            Debug.Log("Spawned Projectile");
        }
    }
    void SpawnProjectile()
    {

        GameObject newProjectile = Instantiate(bullet, transform) as GameObject;
        newProjectile.transform.position = transform.position;

    }
}
