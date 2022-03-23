using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using TMPro;

public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    private string gameID = "4627267";
    private string bannerID = "Banner_Android";
    private string interstitialID = "Interstitial_Android";
    private string rewardedVideoID = "Rewarded_Android";
    public bool TestMode = false;
    public Button showInterstitial;
    public Button watchRewardAd;

    [SerializeField] private GameObject RewardUI;
    private float currentRewardTimer =30;
    [SerializeField] private  float rewardTimer;

    private deneme Deneme; // coin rewarded
    void Start()
    {
        Advertisement.Initialize(gameID, TestMode);
        showInterstitial.interactable = Advertisement.IsReady(interstitialID);
        watchRewardAd.interactable = Advertisement.IsReady(rewardedVideoID);
        Advertisement.AddListener(this);
    }

    public void ShowInterstitial()
    {
        if (Advertisement.IsReady(interstitialID))
        {
            Advertisement.Show(interstitialID);
        }
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(rewardedVideoID);
    }

    public void ShowBanner()
    {
        if (Advertisement.IsReady(bannerID))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerID);
        }
        else StartCoroutine(nameof(RepeatShowBanner));
    }
    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        ShowBanner();
    }

    public void OnUnityAdsReady(string placementID)
    {
        if (placementID == rewardedVideoID)
        {
            watchRewardAd.interactable = true;
        }

        if (placementID == interstitialID)
        {
            showInterstitial.interactable = true;
        }

      if (placementID == bannerID)
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerID);
        }
    }

    public void OnUnityAdsDidFinish(string placementID, ShowResult showResult)
    {
        if (placementID == rewardedVideoID)
        {
            if (showResult == ShowResult.Finished)
            {
                GetReward();
            }
            else if (showResult == ShowResult.Skipped)
            {
                //Do nothing
            }
            else if (showResult == ShowResult.Failed)
            {
                //tell player ads failed
            }
        }
    }


    public void OnUnityAdsDidError(string message)
    {
        //Show or log the error here
    }

    public void OnUnityAdsDidStart(string placementID)
    {
        //Do this if ads starts
    }

    public void GetReward()
    {
        Deneme = GetComponent<deneme>();
        Deneme.LoadCoins();
        rewardTimer = currentRewardTimer;
    }
    void Update()
    {
        rewardTimer -= Time.deltaTime;
        if (rewardTimer < 0)
            RewardActive();
    }
    private void RewardActive()
    {
        RewardUI.SetActive(true);
        rewardTimer = 1000000;
    }
    public void ResetTimer()
    {
        rewardTimer = currentRewardTimer;
    }
}
