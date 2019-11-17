using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartUI : MonoBehaviour
{
    private GameObject UI;

    public Transform gameOver;

    private PlayerHealthManager playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UI");
        gameOver = UI.transform.Find("GameOver");
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.currentPlayerHealth == 0)
        {
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
