using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    private PlayerHealthManager playerHealth;

    public GameObject healthImageOne;
    public GameObject healthImageTwo;
    public GameObject healthImageThree;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealthManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.currentPlayerHealth == 2)
        {
            healthImageThree.SetActive(false);
        }

        if (playerHealth.currentPlayerHealth == 1)
        {
            healthImageTwo.SetActive(false);
        }

        if (playerHealth.currentPlayerHealth < 1)
        {
            healthImageOne.SetActive(false);
        }

    }
}
