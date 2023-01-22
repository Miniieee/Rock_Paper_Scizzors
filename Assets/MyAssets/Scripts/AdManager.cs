using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
	private BannerView adBanner;
	private RewardBasedVideoAd adReward;

	private string idApp, idBanner, idInterstitial, idReward;

	[SerializeField] Button BtnReward;
	[SerializeField] MenuUIText gunAmmount;

	void Start()
	{

		idApp = "ca-app-pub-8552035843311566~9277185376";
		idBanner = "ca-app-pub-8552035843311566/1796837528";
		idReward = "ca-app-pub-8552035843311566/2935138305";

		adReward = RewardBasedVideoAd.Instance;

		MobileAds.Initialize(idApp);
		RequestBannerAd();
	}



	#region Banner Methods --------------------------------------------------

	public void RequestBannerAd()
	{
		adBanner = new BannerView(idBanner, AdSize.Banner, AdPosition.Bottom);
		AdRequest request = AdRequestBuild();
		adBanner.LoadAd(request);
	}

	public void DestroyBannerAd()
	{
		if (adBanner != null)
			adBanner.Destroy();
	}

	#endregion


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
		int currentGunPoint = PlayerPrefs.GetInt("gunAmmount", 0);
		currentGunPoint++;
		PlayerPrefs.SetInt("gunAmmount", currentGunPoint);
		gunAmmount.Start();
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
		DestroyBannerAd();


		adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded -= this.HandleOnAdRewarded;
		adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;

	}
}
