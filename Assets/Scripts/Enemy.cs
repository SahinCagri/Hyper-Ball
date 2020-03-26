using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CameraShake cameraShake;
    private GameController gameController;

    [SerializeField] GameObject skullPrefab;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
     
    }
    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.transform.tag == "Player")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0)+1);
            gameController.scoreText.text = (PlayerPrefs.GetInt("Score") * 6).ToString();

            Instantiate(skullPrefab, transform.position, Quaternion.identity);
            gameController.CheckEnemyball();
            cameraShake.shouldShake = true;
            this.gameObject.SetActive(false);
            
        }
    }

}
