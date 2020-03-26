using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour
{
    private BannerView bannerAd;
    private string bannerId = "ca-app-pub-8967561106308787/5772496157";
    

    private InterstitialAd interstitialAd;
    private string interstitialId = "ca-app-pub-8967561106308787/3146332818";

    private GameController gameController;


    void Start()
    {
        MobileAds.Initialize(reklamver => { });
        BannerAds();
        InterstitialAd();
        interstitialAd.OnAdClosed += Interstitial_OnAdClosed;
    }


    public void BannerAds()
    {
        bannerAd = new BannerView(bannerId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest newAd = new AdRequest.Builder().Build();
        bannerAd.LoadAd(newAd);
    }
   

    private void InterstitialAd()
    {
        interstitialAd = new InterstitialAd(interstitialId);
        AdRequest newAd = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(newAd);
    }
    public void showInterstitialAd()
    {
        if (interstitialAd.IsLoaded())
            interstitialAd.Show();
    }


    private void Interstitial_OnAdClosed(object sender, EventArgs e)
    {
        InterstitialAd();
    }

}
