using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage;

    private EnemyHealthManager enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = FindObjectOfType<EnemyHealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyHitBox")
        {
            enemyHealth.TakeDamage(damage);
        }
    }
}
