using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
    public Transform winScreen;

    public GameObject UI;

   void Start()
    {
        UI = GameObject.Find("UI");
        winScreen = UI.transform.Find("WinState");
    }
   void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "WinState")
        {
            Debug.Log("Winner");
            winScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
