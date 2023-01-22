using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class Admanageringame : MonoBehaviour
{
	private RewardBasedVideoAd adReward;

	private string idApp, idBanner, idInterstitial, idReward;

	[SerializeField] Button BtnReward;
	[SerializeField] Score addPlusGunToPlayer;
	[SerializeField] Button presentButton;

	void Start()
	{
		idApp = "ca-app-pub-8552035843311566~9277185376";
		idReward = "ca-app-pub-8552035843311566/2935138305";

		adReward = RewardBasedVideoAd.Instance;

		MobileAds.Initialize(idApp);
	}

	#region Reward video methods ---------------------------------------------

	public void RequestRewardAd()
	{
		AdRequest request = AdRequestBuild();
		adReward.LoadAd(request, idReward);

		adReward.OnAdLoaded += this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded += this.HandleOnAdRewarded;
		adReward.OnAdClosed += this.HandleOnRewardedAdClosed;
	}

	public void ShowRewardAd()
	{
		if (adReward.IsLoaded())
			adReward.Show();
	}
	//events
	public void HandleOnRewardedAdLoaded(object sender, EventArgs args)
	{//ad loaded
		ShowRewardAd();

	}

	public void HandleOnAdRewarded(object sender, EventArgs args)
	{//user finished watching ad
		addPlusGunToPlayer.AdPlusGun();
		addPlusGunToPlayer.GetInformation();
		presentButton.interactable = false;
}

	public void HandleOnRewardedAdClosed(object sender, EventArgs args)
	{//ad closed (even if not finished watching)
		BtnReward.interactable = true;

		adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded -= this.HandleOnAdRewarded;
		adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;
	}

	#endregion

	//other functions
	//btn (more points) clicked
	public void OnGetMorePointsClicked()
	{
		BtnReward.interactable = false;
		RequestRewardAd();
	}

	//------------------------------------------------------------------------
	AdRequest AdRequestBuild()
	{
		return new AdRequest.Builder().Build();
	}

	void OnDestroy()
	{
		adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded -= this.HandleOnAdRewarded;
		adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;
	}
}
