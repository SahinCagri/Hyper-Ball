using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Skull : MonoBehaviour
{
    private bool isActive = true;
    private float timeStart = 3f;
    private Vector3 posStart;
    private GameObject gameOverPanel;
    
    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        GetComponent<CircleCollider2D>().enabled = false;
        gameOverPanel = GameObject.Find("Canvas/GameOverPanel");
    }


    void Update()
    {
        timeStart -= Time.deltaTime;
        if(timeStart<0 && isActive)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            GetComponent<CircleCollider2D>().enabled = true;
            isActive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("GameOver");
            GameOver();
        }
    }

    public void GameOver()
    {
       posStart= gameOverPanel.transform.localPosition;
        gameOverPanel.transform.localPosition = new Vector3(0, 0, posStart.z);
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Skull"))
        {
            Destroy(g);
        }
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            g.SetActive(false);
        }
    }
}
