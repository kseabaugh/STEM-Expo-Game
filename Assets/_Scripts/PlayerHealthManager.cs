using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxPlayerHealth;
    public float flashTime = 0.5f;
    public int currentPlayerHealth;

    private GameObject childWithHitBox;

    private BoxCollider2D hitBox;

    private Animator anim;

    private PlayerMovement controller;

    private Color originalColor;
    private SpriteRenderer sr;

    void Awake()
    {
        anim = GetComponent<Animator>();

        controller = GetComponent<PlayerMovement>();

        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;

        childWithHitBox = transform.Find("Hitbox").gameObject;

        if (childWithHitBox != null)
        {
            hitBox = childWithHitBox.GetComponent<BoxCollider2D>();
        }
        else
        {
            Debug.Log("Could not find child with that name");
        }
           
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayerHealth == 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    public void TakeDamage(int enemyDamage)
    {
        anim.SetTrigger("hurt");
        currentPlayerHealth -= enemyDamage;
        controller.playerRB.AddForce(new Vector2(2f, 3f), ForceMode2D.Impulse);
        DeactivateHitBox();
        DamageFlashEffect();
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

    void DeactivateHitBox()
    {
        childWithHitBox.SetActive(false);
        Invoke("ReactivateHitBox", 2);
    }

    void ReactivateHitBox()
    {
        childWithHitBox.SetActive(true);
    }

}
