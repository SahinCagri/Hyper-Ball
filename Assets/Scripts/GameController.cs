using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading;

public class GameController : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;

    [SerializeField] GameObject[] enemyBalls;
    [SerializeField] GameObject vfxFinish;
    [SerializeField] Text levelUpButton;

    [SerializeField] Transform[] posEnemyBalls;
    [SerializeField] AudioSource succesClip;

    public Text scoreText;

   GameObject circlePrefab, ballPrefab;
   CameraShake cameraShake;
    
    private float radius = 1.2f;
    int index;
    private void Awake()
    {
       
        foreach (GameObject enemy in enemyBalls)
        {
            enemy.SetActive(false);
        }

    }
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        SpawnEnemy();
       
    }
   

    public void CheckEnemyball()
    {
        Invoke("InvokeCheck", 1f);
    }
    void InvokeCheck()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            if (PlayerPrefs.GetInt("Level") < 8) PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

            vfxFinish.SetActive(true);
            levelUpButton.gameObject.SetActive(true);
        }
    }
   
    public void SpawnEnemy()
    {
        index = PlayerPrefs.GetInt("Level",1);
        Debug.Log("Index: " + index);
        for (int i = 0; i < index; i++)
        {
            enemyBalls[i].SetActive(true);
            enemyBalls[i].transform.position = posEnemyBalls[Random.Range(0, 13)].position;
        }
        levelUpButton.gameObject.SetActive(false);
    }
    public void LevelUpButton()
    {
        succesClip.Play();
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Skull"))
        {
            Destroy(g);
        }
        rb.transform.position = posEnemyBalls[5].transform.position;
        SpawnEnemy();
    }
    
}
