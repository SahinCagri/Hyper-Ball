using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;


public class GameOverPanel : MonoBehaviour
{
    [SerializeField]GameController gameControlller;
    [SerializeField] AdsManager adsManager;
    void Start()
    {
        PopPanel();
    }

    public void HomeButton()//google ads 
    {
        adsManager.showInterstitialAd();
        PopPanel();
        gameControlller.SpawnEnemy();
    }
    public void ReplayButton()
    {
        PlayerPrefs.DeleteAll();
        
        PopPanel();
    }
     void PopPanel()
    {
        Vector3 pos = transform.localPosition;
        pos.x = 1500f;
        transform.localPosition = pos;
   
    }
}
