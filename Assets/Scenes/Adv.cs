using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Adv : MonoBehaviour, IUnityAdsListener
{
    private int RubinsAds = 20;
    // Start is called before the first frame update
    public void Awake()
    {
        if(!Advertisement.isInitialized)
        {
            Advertisement.Initialize("4444049");
        }
    }
    void Start()
    {
        Advertisement.AddListener(this);
    }

    public void PlayAd()
    {
        if(Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
    }
    public void PlayRewardedAd()
    {
        if(Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            //Debug.Log("Rewarded ad is not ready!");
        }
    }
    public void OnUnityAdsReady(string placementId)
    {
       // Debug.Log("ADS ARE READY!");
    }
    public void OnUnityAdsDidError(string message)
    {
        //Debug.Log("ERROR"+ message);
    }
    public void OnUnityAdsDidStart(string placementId)
    {
        //Debug.Log("VIDEO STARTED");
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            PlayerPrefs.SetInt("Rubins", PlayerPrefs.GetInt("Rubins")+RubinsAds);
        }
    }
}
