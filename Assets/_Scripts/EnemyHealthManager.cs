using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    //Health variable
    private float currentHealth;
    public float maxHealth;

    //Damage Flash Variables
    private SpriteRenderer sr;
    private Color originalColor;
    public float flashTime = 0.05f;

    private Animator anim;

    //Important Initializations
    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalColor = sr.color;

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Deactivation if health is 0
        if (currentHealth <= 0)
        {
            Death();
        }

        //Makes sure that current health does not go above and below min and max
        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

    }

    public void TakeDamage(float playerDamage)
    {
        currentHealth -= playerDamage;
        DamageFlashEffect();
    }

    void Death()
    {
        gameObject.SetActive(false);
        Debug.Log(gameObject.name + " is dead!");
    }

    void DamageFlashEffect()
    {
        sr.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        sr.color = originalColor;
    }


}
