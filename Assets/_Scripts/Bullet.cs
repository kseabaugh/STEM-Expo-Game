using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float projSpeed = 3f;
    Rigidbody2D rb;
    float timer = 0;
    bool isDestroyed;
    void Start()
    {
        isDestroyed = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed)
        {
            timer += Time.deltaTime;
            if (timer >= 6f)
            {
                timer = 0;
                Destroy(this.gameObject);
                isDestroyed = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (!isDestroyed)
        {
            rb.AddForce(new Vector2(projSpeed * Time.deltaTime, 0));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit PLayer");

            Destroy(gameObject);
            isDestroyed = true;
            
        }
    }
}
